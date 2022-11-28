using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    public void Start()
    {
        GetComponent<TypewriterEffect>().Run("First line\nSecond line", textLabel);
    }
}
