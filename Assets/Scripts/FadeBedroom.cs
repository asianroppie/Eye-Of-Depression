using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBedroom : MonoBehaviour
{
    [SerializeField] private GameObject background1;
    [SerializeField] private GameObject background2;
    public Animator animator;
    
    void Start()
    {
        Singleton.events.fade_to_level.AddListener(FadeToLevel);
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOutBedroom");
    }
    public void OnFadeComplete()
    {
        background1.SetActive(false);
        background2.SetActive(true);
        if (!Singleton.runtime.showered)
        {
            Singleton.events.fade_called.Invoke();
        }
        if (Singleton.runtime.showered)
        {
            Singleton.events.change_outfit.Invoke();
        }
        animator.SetTrigger("FadeInBedroom");
    }

}
