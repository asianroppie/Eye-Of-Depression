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
        AudioManager.AMinstance.Stop("Train");
        AudioManager.AMinstance.Stop("Theme");
        AudioManager.AMinstance.Play("Office");
        Singleton.events.play_cutscene.AddListener(Play);
        firstAction.Invoke();
    }

    public void Play()
    {
        director.Play();
    }
    public void Day2()
    {
        Singleton.events.move_position.Invoke(-3f);
        Singleton.events.flip_player.Invoke();
        director.Play();
    }
    public void Day3()
    {
        Singleton.events.move_position.Invoke(-8f);
        director.Play();
    }
    public void Breakroom()
    {
        StartCoroutine(StartBreakroom());
    }
    IEnumerator StartBreakroom()
    {
        yield return new WaitForSeconds(0.3f);
        director.Play();
    }
    public void Disable()
    {
        Singleton.events.disable.Invoke();
    }
    public void Enable()
    {
        Singleton.events.enable.Invoke();
    }
    public void Move()
    {
        Singleton.events.move_position.Invoke(-5f);
    }
    public void PlayCafetariaAudio()
    {
        AudioManager.AMinstance.Stop("Office");
        AudioManager.AMinstance.Play("Cafetaria");
    }
    public void PlayOfficeAudio()
    {
        AudioManager.AMinstance.Stop("Cafetaria");
        AudioManager.AMinstance.Play("Office");
    }
    public void PlayTheme()
    {
        AudioManager.AMinstance.Stop("Office");
        AudioManager.AMinstance.Play("Theme");
    }
}
