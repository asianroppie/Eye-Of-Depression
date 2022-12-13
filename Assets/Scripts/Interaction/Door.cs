using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private FadeInteract fadeInteract;
    [SerializeField] private Fade fade;
    public FadeInteract FadeInteract => fadeInteract;
    public Fade Fade => fade;
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
                    if(!fadeInteract.showered)
                    {
                        Text.SetActive(true);
                        Ekey.SetActive(false);
                        Interacted = true;
                    }
                    if(fadeInteract.showered)
                    {
                        Ekey.SetActive(false);
                        fade.FadeToScene();
                    }
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
