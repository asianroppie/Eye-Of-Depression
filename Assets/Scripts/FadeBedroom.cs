using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBedroom : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject background1;
    [SerializeField] private GameObject background2;
    [SerializeField] private GameObject autoMonologue;
    [SerializeField] private FadeInteract fadeInteract;
    public FadeInteract FadeInteract => fadeInteract;
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
        animator.SetTrigger("FadeOutBedroom");
        fadeInteract.showered = false;
    }
    public void OnFadeComplete()
    {
        background1.SetActive(false);
        background2.SetActive(true);
        if (!fadeInteract.showered)
        {
            player.transform.position = new Vector2(-6, player.transform.position.y);
        }
        if (fadeInteract.showered)
        {
            //change character sprite
        }
        animator.SetTrigger("FadeInBedroom");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        autoMonologue.SetActive(false);
    }
}
