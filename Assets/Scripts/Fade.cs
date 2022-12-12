using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject background1;
    [SerializeField] private GameObject background2;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        if(background1.activeInHierarchy == true)
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
        }
        player.transform.position = new Vector2(-6, player.transform.position.y); //set character to spawnPoint
        animator.SetTrigger("FadeIn");
    }
}
