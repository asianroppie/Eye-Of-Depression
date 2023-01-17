using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuntimeManager : MonoBehaviour, IDataPersistence
{
    private bool m_freezed = false;
    public bool onMonologue = false;
    public bool showered = false;
    public bool normie = true;
    public bool gloomie = false;
    public DialogueOption tempOption;
    //public DialogueSO tempSO;
    public int sympathyScore;
    public int day = 1;
    public string activeScene;

    private void Start()
    {
        Singleton.events.dialogue_start.AddListener(Freeze);
        Singleton.events.dialogue_step.AddListener(data => Singleton.manifest.dialoguebuf.Add(data.text));
        Singleton.events.dialogue_end.AddListener(UnFreeze);
        Singleton.events.dialogue_option_select.AddListener(IncrementScore);
        Singleton.events.dialogue_option_select.AddListener(DialogueStorage);
        Singleton.events.change_day.AddListener(DayChanger);
    }

    public bool Freezed => m_freezed;

    public void LoadData(GameData data)
    {
        this.sympathyScore = data.sympathyScore;
        this.day = data.day;
    }
    public void SaveData(ref GameData data)
    {
        data.sympathyScore = this.sympathyScore;
        data.day = this.day;
    }
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
        sympathyScore += option.points;
    }
    public void DialogueStorage(DialogueOption option)
    {
        tempOption = option;
        //tempSO = tempOption.next;
    }
    public void DayChanger()
    {
        activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "1 Day 1")
        {
            day = 1;
        }
        else if (activeScene == "1 Day 2")
        {
            day = 2;
        }
        else if (activeScene == "1 Day 3")
        {
            day = 3;
        }
    }
}   