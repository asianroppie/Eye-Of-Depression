using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactables : MonoBehaviour
{
    public Monologue monologue;
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
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
        if (!isInRange)
        {
            Ekey.SetActive(false);
        }
        if (monologue.Interacted)
        {
            Ekey.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Ekey.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
