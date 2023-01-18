using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button newGame;
    [SerializeField] private Button loadGame;
    [SerializeField] private Button quitGame;
    private void Start()
    {
        if(!DataPersistenceManager.DPMinstance.HasGameData())
        {
            loadGame.interactable = false;
        }
    }
    public void PlayGame()
    {
        DisableMenuButtons();
        DataPersistenceManager.DPMinstance.NewGame();
        Singleton.events.fade_to_scene.Invoke();
    }
    public void ContinueGame()
    {
        DisableMenuButtons();
        Singleton.events.fade_to_scene.Invoke();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void DisableMenuButtons()
    {
        newGame.interactable = false;
        loadGame.interactable = false;
        quitGame.interactable = false;
    }
}
