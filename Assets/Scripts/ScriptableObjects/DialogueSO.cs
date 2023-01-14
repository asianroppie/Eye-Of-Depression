using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "CustomSO/DialogueSO")]
public class DialogueSO : ScriptableObject
{
    [SerializeField] public DialogueData[] data;
}


[Serializable]
public struct DialogueData {
    [TextArea(4,15)] public string text;
    public DialogueOption[] options;
}

[Serializable]
public struct DialogueOption
{
    public string option;
    public DialogueSO next;
    public int points;
}