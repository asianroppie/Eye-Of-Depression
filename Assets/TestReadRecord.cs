using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReadRecord : MonoBehaviour
{
    void Start()
    {
        var ans = DialogueReader.instance.readRecord(Application.persistentDataPath + "/TestData.dat");
        var dview = new DialogueView(ans);

        while (dview.hasNext())
        {
            Debug.Log(dview.getDialogue());
            Debug.Log(dview.getResponse());
            Debug.Log("---------------");
            dview.next();
        }
    }
}
