using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInteractable : MonoBehaviour
{
    public bool Interacted;
    public GameObject Ekey;
    public GameObject Text;
    public float cooldownPeriod = 0.5f;
    public float timer;
    void Start()
    {
        Ekey.SetActive(false);
        Text.SetActive(false);
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
        if(Interacted == false)
        {
            if (Ekey.activeInHierarchy == true)
            {
                if (timer == 0)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Text.SetActive(true);
                        Ekey.SetActive(false);
                    }
                }
            }
            if (Text.activeInHierarchy == true)
            {
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        Text.SetActive(false);
        Ekey.SetActive(true);
        timer = cooldownPeriod;
    }
}
