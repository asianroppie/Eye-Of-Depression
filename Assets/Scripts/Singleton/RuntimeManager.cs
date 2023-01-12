using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeManager : MonoBehaviour
{
    private bool m_freezed = false;
    public bool onMonologue = false;
    public bool showered = false;
    public bool normie = true;
    public bool gloomie = false;
    public DialogueOption tempOption;
    public DialogueSO tempSO;
    public int totalScore;
    public int day1Score;
    public int day2Score;
    public int day3Score;

    private void Start()
    {
        Singleton.events.dialogue_start.AddListener(Freeze);
        Singleton.events.dialogue_step.AddListener(data => Singleton.manifest.dialoguebuf.Add(data.text));
        Singleton.events.dialogue_end.AddListener(UnFreeze);
        Singleton.events.dialogue_option_select.AddListener(IncrementScore);
        Singleton.events.dialogue_option_select.AddListener(DialogueStorage);
    }

    public bool Freezed => m_freezed;

    public void WriteManifest() 
    {
        // Save data logic. TODO LATER!!!
    }

    public void Freeze()
    {
        m_freezed = true;
        Time.timeScale = 0;
        Singleton.events.change_state.Invoke();
    }

    public void UnFreeze()
    {
        m_freezed = false;
        Time.timeScale = 1;
    }
    public void IncrementScore(DialogueOption option)
    {
        totalScore += option.points;
    }
    public void DialogueStorage(DialogueOption option)
    {
        tempOption = option;
        //tempSO = tempOption.next;
    }
}   
