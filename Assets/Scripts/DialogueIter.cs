using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueIter")]
public class DialogueIter : ScriptableObject
{
    
    private int cursor;
    [SerializeField] private DialogueData[] DataList;
    public DialogueObject Current()
    {
        return DataList[cursor].dialogue;
    }
}
