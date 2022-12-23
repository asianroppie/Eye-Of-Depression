using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDialogue : Interactive
{
    public DialogueSO dialogue;

    public override void Interact()
    {
        Singleton.events.dialogue_start_request.Invoke(dialogue);
    }
}
