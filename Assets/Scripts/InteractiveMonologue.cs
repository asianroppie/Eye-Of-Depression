using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveMonologue : Interactive
{
    [SerializeField] private GameObject text;
    public UnityEvent callback;
    protected override void Start()
    {
        base.Start();
        text.SetActive(false);
    }
    public override void Interact()
    {
        StartCoroutine(StartMonologue());
    }
    public void OnMonologueEnd()
    {
        callback.Invoke();
    }
    IEnumerator StartMonologue()
    {
        if(Singleton.runtime.onMonologue)
        {
            yield break;
        }
        Singleton.runtime.onMonologue = true;
        interactIcon.SetActive(false);
        text.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        text.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        Singleton.runtime.onMonologue = false;
        OnMonologueEnd();
    }
}
