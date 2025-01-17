using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveInvoke : Interactive
{
    public UnityEvent interactAction;
    [SerializeField] private GameObject beforeText;
    [SerializeField] private GameObject afterText;
    protected override void Start()
    {
        base.Start();
        //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //use this to hide pop object
    }
    public override void Interact()
    {
        if (!Singleton.runtime.onMonologue)
        {
            interactAction.Invoke();
        }
    }
    public void ResponseMirror()
    {
        if (!Singleton.runtime.showered)
        {
            beforeText.SetActive(true);
            StartCoroutine(startBeforeText());
        }
        else if (Singleton.runtime.showered)
        {
            afterText.SetActive(true);
            StartCoroutine(startAfterText());
        }
    }
    public void ResponseDoor()
    {
        if (!Singleton.runtime.showered)
        {
            StartCoroutine(startBeforeText());
        }
        if (Singleton.runtime.showered)
        {
            AudioManager.AMinstance.Play("Door");
            Singleton.events.fade_to_scene.Invoke();
        }
    }
    public void ResponsePop()
    {
        StartCoroutine(startPop());
    }
    public void ResponseFade()
    {
        Singleton.events.fade_to_level.Invoke();
        AudioManager.AMinstance.Play("Door");
    }
    public void ResponseShower()
    {
        Singleton.runtime.showered = true;
        Singleton.events.fade_to_level.Invoke();
        AudioManager.AMinstance.Play("Shower");
        Destroy(this.gameObject);
    }
    public void FlipPlayer()
    {
        Singleton.events.flip_player.Invoke();
    }
    public void ResponseWorkdesk()
    {
        StartCoroutine(StartWorkdesk());
    }
    public void ResponseCafetariaDoor()
    {
        Singleton.events.fade_to_cafetaria.Invoke();
        AudioManager.AMinstance.Play("Door");
    }
    public void ResponseBreakroomDoor()
    {
        Singleton.events.fade_to_breakroom.Invoke();
        AudioManager.AMinstance.Play("Door");
    }
    public void ResponseBreakroomDoor2()
    {
        Singleton.events.fade_to_breakroom2.Invoke();
        AudioManager.AMinstance.Play("Door");
    }
    public void ResponseSit()
    {
        Singleton.events.move_position.Invoke(-1.5f);
        Singleton.events.change_sit.Invoke();
        Destroy(this.gameObject);
    }
    IEnumerator startBeforeText()
    {
        if (Singleton.runtime.onMonologue)
        {
            yield break;
        }
        Singleton.runtime.onMonologue = true;
        interactIcon.SetActive(false);
        beforeText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        beforeText.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        Singleton.runtime.onMonologue = false;
    }
    IEnumerator startAfterText()
    {
        if (Singleton.runtime.onMonologue)
        {
            yield break;
        }
        Singleton.runtime.onMonologue = true;
        interactIcon.SetActive(false);
        afterText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        afterText.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        Singleton.runtime.onMonologue = false;
    }
    IEnumerator startPop()
    {
        if (Singleton.runtime.onMonologue)
        {
            yield break;
        }
        Singleton.runtime.onMonologue = true;
        interactIcon.SetActive(false);
        beforeText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        beforeText.SetActive(false);
        Singleton.runtime.onMonologue = false;
        AudioManager.AMinstance.Play("Trash");
        Destroy(this.gameObject);
    }
    IEnumerator StartWorkdesk()
    {
        Singleton.runtime.onMonologue = true;
        beforeText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        beforeText.SetActive(false);
        Singleton.runtime.onMonologue = false;
        Singleton.events.fade_to_work.Invoke();
        Destroy(this.gameObject);
    }
}
