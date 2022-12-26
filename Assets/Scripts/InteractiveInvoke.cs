using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveInvoke : Interactive
{
    public UnityEvent interactAction;
    [SerializeField] private GameObject beforeText;
    [SerializeField] private GameObject afterText;
    public override void Interact()
    {
        //Singleton.events.monologue_start_request.Invoke(monologue);
        interactAction.Invoke();
    }
    public void ResponseMirror()
    {
        if (!Singleton.runtime.showered)
        {
            beforeText.SetActive(true);
            StartCoroutine(startBeforeText());
        }
        else if (Singleton.runtime.showered)
        {
            afterText.SetActive(true);
            StartCoroutine(startAfterText());
        }
    }
    public void ResponseDoor()
    {
        if (!Singleton.runtime.showered)
        {
            StartCoroutine(startBeforeText());
        }
        if (Singleton.runtime.showered)
        {
            //fade.FadeToScene();
        }
    }
    public void ResponsePop()
    {
        StartCoroutine(startPop());
    }
    IEnumerator startBeforeText()
    {
        if (Singleton.runtime.onMonologue)
        {
            yield break;
        }
        Singleton.runtime.onMonologue = true;
        interactIcon.SetActive(false);
        beforeText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        beforeText.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        Singleton.runtime.onMonologue = false;
    }
    IEnumerator startAfterText()
    {
        if (Singleton.runtime.onMonologue)
        {
            yield break;
        }
        Singleton.runtime.onMonologue = true;
        interactIcon.SetActive(false);
        afterText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        afterText.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        Singleton.runtime.onMonologue = false;
    }
    IEnumerator startPop()
    {
        if (Singleton.runtime.onMonologue)
        {
            yield break;
        }
        Singleton.runtime.onMonologue = true;
        interactIcon.SetActive(false);
        beforeText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        beforeText.SetActive(false);
        Destroy(this.gameObject);
        Singleton.runtime.onMonologue = false;
    }
}
