using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class Director : MonoBehaviour
{
    public PlayableDirector director;
    void Start()
    {
        Singleton.events.play_cutscene.AddListener(Play);
        StartCoroutine(Wait());
    }

    public void Play()
    {
        director.Play();
    }
    //when cutscene stop, invoke event for dialogue
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        Singleton.events.office_cutscene.Invoke();
    }
}
