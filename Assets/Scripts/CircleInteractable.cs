using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInteractable : MonoBehaviour
{
    public bool Interacted;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Response()
    {
        if(Interacted == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2f);
        }
    }
}
