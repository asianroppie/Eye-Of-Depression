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
    public bool spoken = false;
    //public GameObject player;
    protected override void Start()
    {
        base.Start();
        //player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Interact()
    {
        if(!spoken)
        {
            Singleton.events.dialogue_start_request.Invoke(dialogue);
            //Flip();
            Singleton.events.dialogue_end.AddListener(OnDialogueEnd);
            this.gameObject.tag = "Untagged";
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
    public void OnDialogueEnd()
    {
        Singleton.events.dialogue_end.RemoveListener(OnDialogueEnd);
        spoken = true;
        callback.Invoke();
    }
    public void DialogueInvoke()
    {
        if(Singleton.runtime.tempOption.points == 0)
        {   
            temp = (DialogueSO)AssetDatabase.LoadAssetAtPath("Assets/DialogueData/Office/2.1.1 Response.asset", typeof(DialogueSO));
            Singleton.events.dialogue_start_request.Invoke(temp);
        }
        else if(Singleton.runtime.tempOption.points == 1)
        {
            temp = (DialogueSO)AssetDatabase.LoadAssetAtPath("Assets/DialogueData/Office/2.2.1 Response.asset", typeof(DialogueSO));
            Singleton.events.dialogue_start_request.Invoke(temp);
        }
        Singleton.events.dialogue_end.AddListener(OnDialogueEnd);
        Destroy(this.gameObject);
    }
    public void CafetariaDialogue()
    {
        if (Singleton.runtime.tempOption.points == 0)
        {
            Singleton.events.fade_to_office.Invoke();
        }
        else if (Singleton.runtime.tempOption.points == 1)
        {
            temp = (DialogueSO)AssetDatabase.LoadAssetAtPath("Assets/DialogueData/Office/6.1 Response.asset", typeof(DialogueSO));
            //Singleton.events.dialogue_start_request.Invoke(temp);
            //Singleton.events.fade_to_office.Invoke();
        }
        //Destroy(this);
    }
    public void OfficeDialogue()
    {
        if (Singleton.runtime.tempOption.points == 0)
        {
            temp = (DialogueSO)AssetDatabase.LoadAssetAtPath("Assets/DialogueData/Office/6.1.2 Response.asset", typeof(DialogueSO));
            Singleton.events.dialogue_start_request.Invoke(temp);
            //Singleton.events.fade_to_office.Invoke();
        }
        else if (Singleton.runtime.tempOption.points == 1)
        {
            temp = (DialogueSO)AssetDatabase.LoadAssetAtPath("Assets/DialogueData/Office/6.1.1 Response.asset", typeof(DialogueSO));
            Singleton.events.dialogue_start_request.Invoke(temp);
        }
        Singleton.events.dialogue_end.AddListener(OnDialogueEnd);
        Destroy(this);
    }
    public void TurnOnSprite()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }
    /*public void Flip()
    {
        Vector3 theScale = transform.localScale;
        if(player.transform.position.x > this.gameObject.transform.position.x)
        {
            theScale.x = 0.6f;
        }
        else if(player.transform.position.x < this.gameObject.transform.position.x)
        {
            theScale.x = -0.6f;
        }
        transform.localScale = theScale;
    }*/
    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}