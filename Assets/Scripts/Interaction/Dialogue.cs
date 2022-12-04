using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private DialogueObject dialogueObject;
    public DialogueUI DialogueUI => dialogueUI;
    public bool Interacted;
    public GameObject Ekey;
    public float cooldownPeriod = 0.5f;
    public float timer;
    void Start()
    {
        Ekey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = 0;
        }
    }
    public void Response()
    {
        if (Interacted == false)
        {
            if (Ekey.activeInHierarchy == true)
            {
                if (timer == 0)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //Text.SetActive(true);
                        dialogueUI.ShowDialogue(dialogueObject);
                        Ekey.SetActive(false);
                    }
                }
            }
            /*if (Text.activeInHierarchy == true)
            {
                StartCoroutine(Wait());
            }*/
        }
        Interacted = true;
    }
    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        //Text.SetActive(false);
        Ekey.SetActive(true);
        Interacted = false;
        timer = cooldownPeriod;
    }*/
}
