using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableInvoke : MonoBehaviour
{
    public UnityEvent interactAction;
    private void OnEnable()
    {
        StartCoroutine(WaitInvoke());
    }
    IEnumerator WaitInvoke()
    {
        yield return new WaitForSeconds(0.1f);
        interactAction.Invoke();
        Singleton.events.flipPlayer.Invoke();
    }
}
