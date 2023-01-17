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
        events.move_position = new UnityEvent<float>();
        events.change_outfit = new UnityEvent();
        events.change_character = new UnityEvent();
        events.change_normie_work = new UnityEvent();
        events.play_cutscene = new UnityEvent();
        events.flip_player = new UnityEvent();
        events.train_monologue = new UnityEvent();
        events.bedroom_monologue = new UnityEvent();
        events.change_state = new UnityEvent();
        events.fade_to_work = new UnityEvent();
        events.fade_to_cafetaria = new UnityEvent();
        events.fade_to_office = new UnityEvent();
        events.change_sit = new UnityEvent();
        events.change_height = new UnityEvent();
        events.change_day = new UnityEvent();

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
    public UnityEvent<float> move_position;
    public UnityEvent change_outfit;
    public UnityEvent change_character;
    public UnityEvent change_normie_work;
    public UnityEvent play_cutscene;
    public UnityEvent flip_player;
    public UnityEvent train_monologue;
    public UnityEvent bedroom_monologue;
    public UnityEvent change_state;
    public UnityEvent fade_to_work;
    public UnityEvent fade_to_cafetaria;
    public UnityEvent fade_to_office;
    public UnityEvent change_sit;
    public UnityEvent change_height;
    public UnityEvent change_day;
}


public struct Manifest 
{
    public List<string> dialoguebuf;
    public int sympathy_level;
    public int unlocked_chapter;
    public int chapter;
}