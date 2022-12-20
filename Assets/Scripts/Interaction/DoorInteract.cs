using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorInteract : MonoBehaviour
{
    public InteractObjects door;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject Ekey;
    public Collider2D player;
    void Start()
    {
        Ekey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if(Ekey.activeInHierarchy)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    interactAction.Invoke();
                    //FadeEvent.current.DoorTrigger();
                }
            }
        }
        if (!isInRange)
        {
            Ekey.SetActive(false);
        }
        if (door.Interacted)
        {
            Ekey.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Ekey.SetActive(true);
            //FadeEvent.current.DoorTrigger();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            //FadeEvent.current.DoorTriggerExit();
        }
    }
}
