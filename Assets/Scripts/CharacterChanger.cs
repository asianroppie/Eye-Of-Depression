using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterChanger : MonoBehaviour
{
    public UnityEvent interactAction;
    private void OnEnable()
    {
        //StartCoroutine(Wait());
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
    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        interactAction.Invoke();
    }*/
}
