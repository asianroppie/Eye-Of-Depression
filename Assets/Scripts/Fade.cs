using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator animator;
    public static Fade instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Singleton.events.fade_to_scene.AddListener(FadeToScene);
    }
    public void FadeToScene()
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        Singleton.events.fade_called.Invoke();
        Singleton.runtime.showered = false;
        animator.SetTrigger("FadeIn");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
