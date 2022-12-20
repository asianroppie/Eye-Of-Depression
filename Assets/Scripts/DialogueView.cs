using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueView 
{
    private DialogueAnswer dialogueAnswer;
    private int index = 0;

    public DialogueView(DialogueAnswer dialogueAnswer)
    {
        this.dialogueAnswer = dialogueAnswer;
    }

    public void next() 
    {
       ++index;
    }

    public bool hasNext() 
    {
        return index < dialogueAnswer.answerCount(); 
    }

    public string getDialogue()
    {
        return dialogueAnswer.getDialogue(index);
    }

    public string getResponse()
    {
        return dialogueAnswer.getAnswer(index);
    }
}
