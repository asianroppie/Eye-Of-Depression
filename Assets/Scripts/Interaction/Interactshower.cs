using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactshower : MonoBehaviour
{
    [SerializeField] private FadeInteract fadeInteract;
    public bool Interacted;
    public GameObject Ekey;
    public GameObject beforeText;
    public GameObject afterText;
    public float cooldownPeriod = 0.5f;
    public float timer;
    public FadeInteract FadeInteract => fadeInteract;
    void Start()
    {
        Ekey.SetActive(false);
        beforeText.SetActive(false);
        afterText.SetActive(false);
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
                    if(fadeInteract.showered == false)
                    {
                        beforeText.SetActive(true);
                    }
                    else if(fadeInteract.showered == true)
                    {
                        afterText.SetActive(true);
                    }
                    Ekey.SetActive(false);
                    Interacted = true;
                    //Debug.Log(fadeInteract.showered);
                }
            }
            if (beforeText.activeInHierarchy || afterText.activeInHierarchy)
            {
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        beforeText.SetActive(false);
        afterText.SetActive(false);
        Ekey.SetActive(true);
        Interacted = false;
        timer = cooldownPeriod;
    }
}
