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
    }

    public void Play()
    {
        director.Play();
    }
    //when cutscene stop, invoke event for dialogue
}
