using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableInvoke : MonoBehaviour
{
    public UnityEvent interactAction;
    private void OnEnable()
    {
        Singleton.events.flip_player.Invoke();
    }
    private void Start()
    {
        interactAction.Invoke();
    }
}
