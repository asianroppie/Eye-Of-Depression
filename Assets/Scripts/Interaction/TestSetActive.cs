using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSetActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FadeEvent.current.onDoorTrigger += OnDoorEnter;
        FadeEvent.current.onDoorTriggerExit += OnDoorExit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDoorEnter()
    {
        this.gameObject.SetActive(false);
    }
    public void OnDoorExit()
    {
        this.gameObject.SetActive(true);
    }
}
