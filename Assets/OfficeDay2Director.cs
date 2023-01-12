using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class OfficeDay2Director : MonoBehaviour
{
    public PlayableDirector director;
    //public UnityEvent firstAction;
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Singleton.runtime.Freeze();
        Singleton.events.move_position.Invoke(-3f);
        Singleton.events.flip_player.Invoke();
        director.Play();
    }
}
