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
    public Animator animator;
    
    void Start()
    {
        Singleton.events.fade_to_level.AddListener(FadeToLevel);

        autoMonologue.SetActive(true);
        if (autoMonologue.activeInHierarchy)
        {
            StartCoroutine(Wait());
        }
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOutBedroom");
    }
    public void OnFadeComplete()
    {
        background1.SetActive(false);
        background2.SetActive(true);
        if (!Singleton.runtime.showered)
        {
            Singleton.events.fade_called.Invoke();
        }
        if (Singleton.runtime.showered)
        {
            //change character sprite with singleton event with player as a listener
            Singleton.events.change_sprite.Invoke();
        }
        animator.SetTrigger("FadeInBedroom");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        autoMonologue.SetActive(false);
    }
}
