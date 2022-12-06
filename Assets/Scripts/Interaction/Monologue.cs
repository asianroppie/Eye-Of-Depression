using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monologue : MonoBehaviour
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
        if (!Interacted)
        {
            if (Ekey.activeInHierarchy)
            {
                if (timer == 0)
                {
                    Text.SetActive(true);
                    Ekey.SetActive(false);
                    Interacted = true;
                }
            }
            if (Text.activeInHierarchy)
            {
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Text.SetActive(false);
        Ekey.SetActive(true);
        Interacted = false;
        timer = cooldownPeriod;
    }
}
