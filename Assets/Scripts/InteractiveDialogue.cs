using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveDialogue : Interactive
{
    public DialogueSO dialogue;
    public UnityEvent callback;
    protected override void Start()
    {
        base.Start();
        //Singleton.events.dialogue_after_cutscene.AddListener(StartDialogue);
    }
    public override void Interact()
    {
        Singleton.events.dialogue_start_request.Invoke(dialogue);
        Singleton.events.dialogue_end.AddListener(OnDialogueEnd);
    }
    public void OnDialogueEnd()
    {
        Singleton.events.dialogue_end.RemoveListener(OnDialogueEnd);
        callback.Invoke();
    }
}
