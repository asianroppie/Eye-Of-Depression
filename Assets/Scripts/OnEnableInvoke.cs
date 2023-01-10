using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableInvoke : MonoBehaviour
{
    public UnityEvent interactAction;
    public UnityEvent interactEvent;
    private void OnEnable()
    {
        //StartCoroutine(WaitInvoke());
        Singleton.events.flip_player.Invoke();
        //interactAction.Invoke();
        Singleton.events.work_dialogue.AddListener(Disable);
    }
    private void Start()
    {
        interactAction.Invoke();
    }
    /*IEnumerator WaitInvoke()
    {
        Singleton.events.flip_player.Invoke();
        yield return new WaitForSeconds(0.1f);
        interactAction.Invoke();
    }*/
    public void Disable()
    {
        interactEvent.Invoke();
        this.gameObject.SetActive(false);
    }
}
