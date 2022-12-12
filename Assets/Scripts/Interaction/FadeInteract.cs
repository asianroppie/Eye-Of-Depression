using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInteract : MonoBehaviour
{
    [SerializeField] private Fade fade;
    public bool showered;
    public GameObject Ekey;
    public Fade Fade => fade;
    void Start()
    {
        Ekey.SetActive(false);
    }

    void Update()
    {

    }
    public void Response()
    {
        if (!showered)
        {
            if (Ekey.activeInHierarchy)
            {
                Ekey.SetActive(false);
                fade.FadeToLevel();
            }
            showered = true;
            Destroy(this.gameObject);
        }
    }
}
