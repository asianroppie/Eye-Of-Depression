using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRecorder : MonoBehaviour
{
    public void Start()
    {
        DialogueRecorder.instance.recordPath = Application.persistentDataPath + "/TestData.dat";
        DialogueRecorder.instance.loadRecordFile();
    }

    public void OnDestroy()
    {
        DialogueRecorder.instance.saveRecord();
    }
}
