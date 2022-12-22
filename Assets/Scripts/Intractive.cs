using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Intractive : MonoBehaviour
{
    [SerializeField] private GameObject interactIcon;

    public abstract void Interact();


    private void Start()
    {
        interactIcon.SetActive(false);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            interactIcon.SetActive(false);
    }


    public void ActivateIcon(bool active)
    {
        interactIcon.SetActive(active);
    }
}
