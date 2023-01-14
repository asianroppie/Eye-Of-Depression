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
    public UnityEvent workAction;
    public UnityEvent lunchAction;
    public UnityEvent secondSceneAction;
    public UnityEvent officeAction;
    void Start()
    {
        Singleton.events.fade_to_scene.AddListener(FadeToScene);
        Singleton.events.fade_to_level.AddListener(FadeToLevel);
        Singleton.events.fade_to_work.AddListener(FadeToWork);
        Singleton.events.fade_to_cafetaria.AddListener(FadeToCafetaria);
        Singleton.events.fade_to_office.AddListener(FadeToOffice);
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
        workAction.Invoke();
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
        Singleton.runtime.UnFreeze();
        background1.SetActive(false);
        background2.SetActive(true);
        Singleton.events.move_position.Invoke(1.5f);
        secondSceneAction.Invoke();
    }
    public void FadeToOffice()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutOffice");
    }
    public void OnFadeOfficeComplete()
    {
        animator.SetTrigger("FadeIn");
        Singleton.runtime.UnFreeze();
        background2.SetActive(false);
        background1.SetActive(true);
        officeAction.Invoke();
        Singleton.events.move_position.Invoke(5.4f);
        Singleton.events.flip_player.Invoke();
    }
    public void FadeToLunch2()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutLunch2");
    }
    public void OnFadeLunch2Complete()
    {
        animator.SetTrigger("FadeIn");
        Singleton.runtime.UnFreeze();
        Singleton.events.move_position.Invoke(5.4f);
        lunchAction.Invoke();
    }
    public void FadeToBreakroom()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutBreakroom");
    }
    public void OnFadeBreakroomComplete()
    {
        animator.SetTrigger("FadeIn");
        Singleton.runtime.UnFreeze();
        background1.SetActive(false);
        background2.SetActive(true);
        Singleton.events.move_position.Invoke(7.5f);
        Singleton.events.flip_player.Invoke();
        secondSceneAction.Invoke();
    }
}
