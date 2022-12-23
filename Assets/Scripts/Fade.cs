using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject autoMonologue;
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
        autoMonologue.SetActive(true);
        if (autoMonologue.activeInHierarchy)
        {
            StartCoroutine(Wait());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }
    public void FadeToScene()
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        /*if (background1.activeInHierarchy == true)
        {
            background1.SetActive(false);
        }
        else
        {
            background1.SetActive(true);
        }
        if (background2.activeInHierarchy == true)
        {
            background2.SetActive(false);
        }
        else
        {
            background2.SetActive(true);
        }*/
        player.transform.position = new Vector2(-6, player.transform.position.y);
        animator.SetTrigger("FadeIn");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        autoMonologue.SetActive(false);
    }
}
