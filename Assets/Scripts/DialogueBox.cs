using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TMP_Text m_textLabel;
    [SerializeField] private RectTransform m_optionBox;
    [SerializeField] private GameObject m_optionBtnPF;

    public KeyCode nextKey;

    private void Start()
    {
        Singleton.events.dialogue_start_request.AddListener(OnDialogueStartRequest);

        gameObject.SetActive(false);
        m_optionBox.gameObject.SetActive(false);
    }


    private void AddOptionBtn(DialogueOption option)
    {
        var btn = Instantiate(m_optionBtnPF);
        btn.GetComponentInChildren<TMP_Text>().text = option.option;
        btn.GetComponent<Button>().onClick.AddListener(() => 
        {
            m_optionBox.gameObject.SetActive(false);
            Singleton.events.dialogue_option_select.Invoke(option);
            ClearOptions();

            if (option.next) StartCoroutine(StartDialogue(option.next));
            else EndDialogue();
        });
        btn.transform.SetParent(m_optionBox);
    }


    private void ClearOptions()
    {
        foreach (Transform child in m_optionBox.transform)
            Destroy(child.gameObject);
    }


    private IEnumerator StartDialogue(DialogueSO dialogue)
    {
        foreach (var data in dialogue.data)
        {
            Singleton.events.dialogue_step.Invoke(data);

            yield return GetComponent<TypewriterEffect>().Run(data.text, m_textLabel);

            // Has options
            if (data.options.Length > 0)
            {
                m_optionBox.gameObject.SetActive(true);
                foreach (var option in data.options)
                    AddOptionBtn(option);
            }
            yield return new WaitUntil(() => Input.GetKeyDown(nextKey) || m_optionBox.gameObject.activeSelf);
        }

        if(!m_optionBox.gameObject.activeSelf) EndDialogue();
    }


    private void EndDialogue() 
    {
        Singleton.events.dialogue_end.Invoke();
        gameObject.SetActive(false);
    }


    private void OnDialogueStartRequest(DialogueSO dialogue)
    {
        gameObject.SetActive(true);

        Singleton.events.dialogue_start.Invoke();
        StartCoroutine(StartDialogue(dialogue));
    }
}
