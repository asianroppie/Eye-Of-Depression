using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDirector : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4.2f);
        Singleton.events.train_monologue.Invoke();
    }
}
