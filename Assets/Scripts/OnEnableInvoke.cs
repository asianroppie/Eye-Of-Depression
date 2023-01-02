using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableInvoke : MonoBehaviour
{
    public UnityEvent interactAction;
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine(WaitInvoke());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitInvoke()
    {
        yield return new WaitForSeconds(1.0f);
        interactAction.Invoke();
        Debug.Log("Active");
    }
}
