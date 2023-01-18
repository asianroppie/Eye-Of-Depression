using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SkipScene : MonoBehaviour
{
    private static SkipScene instance;
    public UnityEvent action;
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
    public void NextScene()
    {
        action.Invoke();
    }
}
