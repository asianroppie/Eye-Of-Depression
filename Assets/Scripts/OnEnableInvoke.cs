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
        Singleton.events.flip_player.Invoke();
        yield return new WaitForSeconds(0.1f);
        interactAction.Invoke();
        Destroy(this);
    }
}
