using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterChanger : MonoBehaviour
{
    public UnityEvent interactAction;
    private void OnEnable()
    {
        interactAction.Invoke();
    }
    public void ChangeToNormie()
    {
        Singleton.runtime.normie = true;
        Singleton.runtime.gloomie = false;
        Singleton.events.change_character.Invoke();
    }
    public void ChangeToGloomie()
    {
        Singleton.runtime.normie = false;
        Singleton.runtime.gloomie = true;
        Singleton.events.change_character.Invoke();
    }
    public void ChangeToNormieWork()
    {
        Singleton.runtime.normie = true;
        Singleton.runtime.gloomie = false;
        Singleton.events.change_outfit.Invoke();
    }
}
