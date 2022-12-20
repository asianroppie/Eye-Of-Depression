using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class DialogueRecorder : MonoBehaviour
{
    public static DialogueRecorder instance;
    private DialogueAnswer dialogueAnswer;
    private string dialogueText;
    private string responseText;

    public string recordPath;


    private void Awake()
    {
        instance = this;
    }

    public void saveRecord() 
    {
        BinaryFormatter binForm = new BinaryFormatter();
        FileStream file = File.Create(recordPath);
        binForm.Serialize(file, dialogueAnswer);
        file.Close();
        Debug.Log("File saved to " + recordPath);
    }

    public void setDialogue(string dialogueText)
    {
        this.dialogueText = dialogueText;
    }


    public void loadRecordFile() 
    {
        if (!File.Exists(recordPath))
        {
            dialogueAnswer = new DialogueAnswer();
            return;
        }

        BinaryFormatter binForm = new BinaryFormatter();
        FileStream file = File.Open(recordPath, FileMode.Open);
        dialogueAnswer = (DialogueAnswer)binForm.Deserialize(file);
        file.Close();
    }

    public void resetRecord()
    {
        if (!File.Exists(recordPath))
            return;

        if (dialogueAnswer == null)
            return;

        File.Delete(recordPath);
        dialogueAnswer.reset();
        saveRecord();
    }

    public void setResponse(string responseText)
    {
        this.responseText = responseText;
    }

    public void commit()
    {
        dialogueAnswer.addAnswer(dialogueText, responseText);
        dialogueText = string.Empty;
        responseText = string.Empty;
    }
}


[Serializable]
public class DialogueAnswer
{
    [Serializable]
    private class Answer
    {
        public string dialogue;
        public string answer;
    }
    [SerializeField] private List<Answer> answerList;

    public DialogueAnswer() 
    {
        answerList = new List<Answer>();
    }

    public string getDialogue(int index)
    {
        return answerList[index].dialogue;
    }

    public string getAnswer(int index)
    {
        return answerList[index].answer;
    }

    public int answerCount()
    {
        return answerList.Count;
    }

    public void addAnswer(string dialogue, string answer)
    {
        Answer ans = new Answer();
        ans.dialogue = dialogue;
        ans.answer = answer;
        answerList.Add(ans);
    }
    public void reset() 
    {
        answerList.Clear();
    }
}
