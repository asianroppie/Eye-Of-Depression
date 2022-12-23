using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMonologue : Interactive
{
    [SerializeField] private GameObject text;
    public bool waiting;
    protected override void Start()
    {
        base.Start();
        text.SetActive(false);
    }
    public override void Interact()
    {
        //Singleton.events.monologue_start_request.Invoke(monologue);
        StartCoroutine(StartMonologue());
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
        yield return new WaitForSeconds(2.0f);
        Singleton.runtime.onMonologue = false;
    }
}
