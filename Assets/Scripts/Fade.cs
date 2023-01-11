using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField] private GameObject background1;
    [SerializeField] private GameObject background2;
    public Animator animator;
    public UnityEvent lunchAction;
    void Start()
    {
        Singleton.events.fade_to_scene.AddListener(FadeToScene);
        Singleton.events.fade_to_level.AddListener(FadeToLevel);
        Singleton.events.fade_to_work.AddListener(FadeToWork);
    }
    public void FadeToScene()
    {
        animator.SetTrigger("FadeOut");
        Singleton.runtime.Freeze();
    }
    public void OnFadeComplete()
    {
        Singleton.events.move_position.Invoke(-6f);
        Singleton.runtime.showered = false;
        animator.SetTrigger("FadeIn");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Singleton.runtime.UnFreeze();
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOutLevel");
    }
    public void OnFadeLevelComplete()
    {
        background1.SetActive(false);
        background2.SetActive(true);
        if (!Singleton.runtime.showered)
        {
            Singleton.events.move_position.Invoke(-6f);
        }
        if (Singleton.runtime.showered)
        {
            Singleton.events.change_outfit.Invoke();
        }
        animator.SetTrigger("FadeIn");
    }
    public void FadeToWork()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutWork");
    }
    public void OnFadeWorkComplete()
    {
        animator.SetTrigger("FadeIn");
        Singleton.events.move_position.Invoke(5.4f);
        Singleton.runtime.UnFreeze();
        Singleton.events.work_dialogue.Invoke();
    }
    public void FadeToLunch()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutLunch");
    }
    public void OnFadeLunchComplete()
    {
        animator.SetTrigger("FadeIn");
        Singleton.events.move_position.Invoke(5.4f);
        Singleton.runtime.UnFreeze();
        lunchAction.Invoke();
        Singleton.events.flip_player.Invoke();
    }
    public void FadeToCafetaria()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutCafetaria");
    }
    public void OnFadeCafetariaComplete()
    {
        animator.SetTrigger("FadeIn");
        Singleton.events.move_position.Invoke(-6f);
        Singleton.runtime.UnFreeze();
    }
}
