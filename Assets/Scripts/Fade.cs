using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject background1;
    [SerializeField] private GameObject background2;
    [SerializeField] private GameObject autoMonologue;
    public Animator animator;
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

    }
    public void OnFadeComplete()
    {
        background1.SetActive(false);
        background2.SetActive(true);
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
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        autoMonologue.SetActive(false);
    }
}
