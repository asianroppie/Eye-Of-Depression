using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeEvent : MonoBehaviour
{
    public static FadeEvent current;
    public void Awake()
    {
        current = this;
    }
    public event Action onDoorTrigger;
    public void DoorTrigger()
    {
        if(onDoorTrigger != null)
        {
            onDoorTrigger();
        }
    }
    public event Action onDoorTriggerExit;
    public void DoorTriggerExit()
    {
        if (onDoorTrigger != null)
        {
            onDoorTriggerExit();
        }
    }
}
