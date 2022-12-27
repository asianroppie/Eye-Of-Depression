using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjects : MonoBehaviour
{
    [SerializeField] private FadeInteract fadeInteract;
    [SerializeField] private Fade fade;
    public bool Interacted;
    public GameObject Ekey;
    public GameObject beforeText;
    public GameObject afterText;
    public float cooldownPeriod = 0.5f;
    public float timer;
    public FadeInteract FadeInteract => fadeInteract;
    public Fade Fade => fade;
    void Start()
    {
        Ekey.SetActive(false);
        beforeText.SetActive(false);
        //afterText.SetActive(false);
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
    public void ResponseMirror()
    {
        if (!Interacted)
        {
            if (Ekey.activeInHierarchy)
            {
                if (timer == 0)
                {
                    if (fadeInteract.showered == false)
                    {
                        beforeText.SetActive(true);
                    }
                    else if (fadeInteract.showered == true)
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
                StartCoroutine(WaitMirror());
            }
        }
    }
    public void ResponseDoor()
    {
        if (!Interacted)
        {
            if (Ekey.activeInHierarchy)
            {
                if (timer == 0)
                {
                    if (!fadeInteract.showered)
                    {
                        beforeText.SetActive(true);
                        Ekey.SetActive(false);
                        Interacted = true;
                    }
                    if (fadeInteract.showered)
                    {
                        Ekey.SetActive(false);
                        //fade.FadeToScene();
                    }
                }
            }
            if (beforeText.activeInHierarchy)
            {
                StartCoroutine(Wait());
            }
        }
    }
    public void ResponsePop()
    {
        if (!Interacted)
        {
            if (Ekey.activeInHierarchy)
            {
                if (timer == 0)
                {
                    Ekey.SetActive(false);
                    beforeText.SetActive(true);
                }
            }
            if (beforeText.activeInHierarchy)
            {
                StartCoroutine(WaitPop());
            }
        }
    }
    IEnumerator WaitMirror()
    {
        yield return new WaitForSeconds(2f);
        beforeText.SetActive(false);
        afterText.SetActive(false);
        Ekey.SetActive(true);
        Interacted = false;
        timer = cooldownPeriod;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        beforeText.SetActive(false);
        Ekey.SetActive(true);
        Interacted = false;
        timer = cooldownPeriod;
    }
    IEnumerator WaitPop()
    {
        yield return new WaitForSeconds(2f);
        beforeText.SetActive(false);
        Destroy(this.gameObject);
        timer = cooldownPeriod;
    }
}
