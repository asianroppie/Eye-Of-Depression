using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] private Player player;
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
        //setActive true / false to objects
        player.transform.position = new Vector3(-5, 0, 0); //set character to spawnPoint
        animator.SetTrigger("FadeIn");
    }
}
