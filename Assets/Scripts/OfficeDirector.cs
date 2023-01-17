using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class OfficeDirector : MonoBehaviour
{
    public PlayableDirector director;
    public UnityEvent firstAction;
    void Start()
    {
        Singleton.events.play_cutscene.AddListener(Play);
        firstAction.Invoke();
    }

    public void Play()
    {
        director.Play();
    }
    public void Day2()
    {
        //StartCoroutine(StartDay2());
        Singleton.events.move_position.Invoke(-3f);
        Singleton.events.flip_player.Invoke();
        director.Play();
    }
    /*IEnumerator StartDay2()
    {
        yield return new WaitForSeconds(0.3f);
        Singleton.events.move_position.Invoke(-3f);
        Singleton.events.flip_player.Invoke();
        director.Play();
    }*/
    public void Day3()
    {
        //StartCoroutine(StartDay3());
        Singleton.events.move_position.Invoke(-8f);
        director.Play();
    }
    /*IEnumerator StartDay3()
    {
        yield return new WaitForSeconds(0.3f);
        Singleton.events.move_position.Invoke(-8f);
        director.Play();
    }*/
    public void Breakroom()
    {
        StartCoroutine(StartBreakroom());
    }
    IEnumerator StartBreakroom()
    {
        yield return new WaitForSeconds(0.3f);
        director.Play();
    }
}
