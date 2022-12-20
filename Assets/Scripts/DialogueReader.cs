using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    public static DialogueReader instance;

    public void Awake()
    {
        instance = this;
    }

    public DialogueAnswer readRecord(string recordPath)
    {
        if (!File.Exists(recordPath))
            return null;

        BinaryFormatter binForm = new BinaryFormatter();
        FileStream file = File.Open(recordPath, FileMode.Open);
        DialogueAnswer dialogueAnswer = (DialogueAnswer)binForm.Deserialize(file);
        file.Close();

        return dialogueAnswer;
    }
}
