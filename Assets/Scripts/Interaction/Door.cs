using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool Interacted;
    public GameObject Ekey;
    public float cooldownPeriod = 0.5f;
    public float timer;
    void Start()
    {
        Ekey.SetActive(false);
    }

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
        if (Interacted == false)
        {
            if (Ekey.activeInHierarchy == true)
            {
                if (timer == 0)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Ekey.SetActive(false);
                    }
                }
            }
        }
        Interacted = true;
    }
}
