using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveInvoke : Interactive
{
    public UnityEvent interactAction;
    public override void Interact()
    {
        //Singleton.events.monologue_start_request.Invoke(monologue);
        interactAction.Invoke();
    }
}
