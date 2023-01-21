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
        Singleton.events.fade_to_breakroom.AddListener(FadeToBreakroom);
        Singleton.events.fade_to_breakroom2.AddListener(FadeToBreakroom2);
        Singleton.events.fade_from_menu.AddListener(MenuFade);
    }
    public void OnFadeInComplete()
    {
        Singleton.events.change_day.Invoke();
    }
    public void MenuFade()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutMenu");
    }
    public void OnFadeMenuComplete()
    {
        animator.SetTrigger("FadeIn");
        if (Singleton.runtime.day == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (Singleton.runtime.day == 2)
        {
            SceneManager.LoadScene(5);
        }
        else if (Singleton.runtime.day == 3)
        {
            SceneManager.LoadScene(8);
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Singleton.runtime.UnFreeze();
    }
    public void FadeToScene()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOut");
        Singleton.events.change_height.Invoke();
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
        Singleton.runtime.Freeze();
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
        Singleton.runtime.UnFreeze();
        workAction.Invoke();
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
        Singleton.events.flip_player.Invoke();
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
    public void FadeToBreakroom2()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutBreakroom2");
    }
    public void OnFadeBreakroom2Complete()
    {
        animator.SetTrigger("FadeIn");
        Singleton.runtime.UnFreeze();
        background1.SetActive(false);
        background2.SetActive(true);
        Singleton.events.move_position.Invoke(-3.75f);
        Singleton.events.change_sit.Invoke();
        secondSceneAction.Invoke();
    }
    public void FadeToEnding()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutEnding");
    }
    public void OnFadeEndingComplete()
    {
        animator.SetTrigger("FadeIn");
        if (Singleton.runtime.sympathyScore >= 7)
        {
            SceneManager.LoadScene(11);
        }
        else if (Singleton.runtime.sympathyScore <= 6)
        {
            SceneManager.LoadScene(12);
        }
        Singleton.events.change_sit_ending.Invoke();
    }
    public void FadeToMenu()
    {
        Singleton.runtime.Freeze();
        animator.SetTrigger("FadeOutToMenu");
    }
    public void OnFadeToMenuComplete()
    {
        animator.SetTrigger("FadeIn");
        Singleton.runtime.UnFreeze();
        workAction.Invoke();
        Singleton.events.destroy_player.Invoke();
        SceneManager.LoadScene(0);
    }
}