using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInteract : MonoBehaviour
{
    [SerializeField] private FadeBedroom fadeBedroom;
    public bool showered;
    public GameObject Ekey;
    public FadeBedroom FadeBedroom => fadeBedroom;
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
                fadeBedroom.FadeToLevel();
            }
            showered = true;
            Destroy(this.gameObject);
        }
    }
}
