using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Singleton : MonoBehaviour
{
    private static Singleton m_instance;

    public static Manifest manifest;
    public static GameEvents events;
    public static RuntimeManager runtime;
    
    private void Awake()
    {
        if (m_instance != this && m_instance != null)
        {
            Destroy(this); 
            return;
        }

        m_instance = this;
        manifest = new Manifest();
        events = new GameEvents();
        runtime = GetComponent<RuntimeManager>();

        manifest.dialoguebuf = new List<string>();

        events.dialogue_start_request = new UnityEvent<DialogueSO>();
        events.dialogue_start = new UnityEvent();
        events.dialogue_step = new UnityEvent<DialogueData>();
        events.dialogue_end = new UnityEvent();
        events.dialogue_option_select = new UnityEvent<DialogueOption>();
        events.fade_to_level = new UnityEvent();
        events.fade_to_scene = new UnityEvent();
        events.fade_called = new UnityEvent();
        events.change_sprite = new UnityEvent();
        events.play_cutscene = new UnityEvent();

        DontDestroyOnLoad(gameObject);
    }
}


public struct GameEvents
{
    public UnityEvent<DialogueSO> dialogue_start_request;
    public UnityEvent dialogue_start;
    public UnityEvent<DialogueData> dialogue_step;
    public UnityEvent dialogue_end;
    public UnityEvent<DialogueOption> dialogue_option_select;
    public UnityEvent fade_to_level;
    public UnityEvent fade_to_scene;
    public UnityEvent fade_called;
    public UnityEvent change_sprite;
    public UnityEvent play_cutscene;
}


public struct Manifest 
{
    public List<string> dialoguebuf;
    public int sympathy_level;
    public int unlocked_chapter;
    public int chapter;
}