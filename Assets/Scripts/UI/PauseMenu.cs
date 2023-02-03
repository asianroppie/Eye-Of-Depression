using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    private bool iconOn = true;

    void Start()
    {
        Singleton.events.dialogue_start.AddListener(HideButton);
        Singleton.events.dialogue_end.AddListener(ShowButton);
    }
    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            if(iconOn == true)
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Singleton.runtime.Freeze();
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Singleton.runtime.UnFreeze();
    }
    public void HideButton()
    {
        pauseButton.SetActive(false);
        iconOn = false;
    }
    public void ShowButton()
    {
        pauseButton.SetActive(true);
        iconOn = true;
    }
    public void BackToMenu()
    {
        Singleton.events.fade_from_pause.Invoke();
    }
}
