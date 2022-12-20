using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    //public string[] test = { "test1", "test2", "test3" };
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private DialogueObject dialogueObject;
    public DialogueUI DialogueUI => dialogueUI;
    public DialogueObject DialogueObject => dialogueObject;
    public bool Interacted;
    public GameObject Ekey;
    public float cooldownPeriod = 0.5f;
    public float timer;
    void Start()
    {
        Ekey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = 0;
        }
    }
    public void Response()
    {
        if (!Interacted)
        {
            if (Ekey.activeInHierarchy)
            {
                if (timer == 0)
                {
                    //Text.SetActive(true);
                    dialogueUI.ShowDialogue(dialogueObject);
                    //Array.ForEach(dialogueObject.Dialogue, Debug.Log);
                    Ekey.SetActive(false);
                }
            }
            /*if (Text.activeInHierarchy == true)
            {
                StartCoroutine(Wait());
            }*/
        }
        Interacted = true;
        //Destroy(this);
    }
    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        //Text.SetActive(false);
        Ekey.SetActive(true);
        Interacted = false;
        timer = cooldownPeriod;
    }*/
}
