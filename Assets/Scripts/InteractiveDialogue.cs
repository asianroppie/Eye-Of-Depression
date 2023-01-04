using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveDialogue : Interactive
{
    public DialogueSO dialogue;
    public UnityEvent callback;
    public DialogueSO temp;
    protected override void Start()
    {
        base.Start();
        //Singleton.events.dialogue_after_cutscene.AddListener(StartDialogue);
        Singleton.events.office_cutscene.AddListener(Interact);
    }
    public override void Interact()
    {
        Singleton.events.dialogue_start_request.Invoke(dialogue);
        Singleton.events.dialogue_end.AddListener(OnDialogueEnd);
    }
    public void OnDialogueEnd()
    {
        Singleton.events.dialogue_end.RemoveListener(OnDialogueEnd);
        callback.Invoke();
    }
    public void DialogueInvoke()
    {
        if(Singleton.runtime.tempOption.points == 0)
        {
            temp = (DialogueSO)AssetDatabase.LoadAssetAtPath("Assets/DialogueData/Office/2.1.1 Response.asset", typeof(DialogueSO));
            Singleton.events.dialogue_start_request.Invoke(temp);
            //Debug.Log(temp.name);
        }
        else if(Singleton.runtime.tempOption.points == 1)
        {
            temp = (DialogueSO)AssetDatabase.LoadAssetAtPath("Assets/DialogueData/Office/2.2.1 Response.asset", typeof(DialogueSO));
            Singleton.events.dialogue_start_request.Invoke(temp);
            //Debug.Log(temp.name);
        }
    }
}
