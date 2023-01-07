using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMonologue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> monologue = new List<GameObject>();
    void Start()
    {
        Singleton.events.auto_monologue.AddListener(TrainMonologue);
        monologue[0].SetActive(true);
        if (monologue[0].activeInHierarchy)
        {
            StartCoroutine(Wait());
        }
    }
    public void TrainMonologue()
    {
        StartCoroutine(StartTrainMonologue());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        monologue[0].SetActive(false);
    }
    IEnumerator StartTrainMonologue()
    {
        monologue[1].SetActive(true);
        yield return new WaitForSeconds(4f);
        monologue[1].SetActive(false);
        yield return new WaitForSeconds(0.2f);
        monologue[2].SetActive(true);
        yield return new WaitForSeconds(4f);
        monologue[2].SetActive(false);
    }
}
