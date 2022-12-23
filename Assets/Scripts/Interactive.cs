using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    [SerializeField] protected GameObject interactIcon;

    public abstract void Interact();


    protected virtual void Start()
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
