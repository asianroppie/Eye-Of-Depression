using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeManager : MonoBehaviour
{
    private bool m_freezed = false;
    public bool onMonologue = false;
    public bool showered = false;

    private void Start()
    {
        Singleton.events.dialogue_start.AddListener(Freeze);
        Singleton.events.dialogue_step.AddListener(data => Singleton.manifest.dialoguebuf.Add(data.text));
        Singleton.events.dialogue_end.AddListener(UnFreeze);
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
    }


    public void UnFreeze()
    {
        m_freezed = false;
        Time.timeScale = 1;
    }
}
