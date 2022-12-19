using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResponse : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    public DialogueObject DialogueObject => dialogueObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Test()
    {
        Response[] responses = dialogueObject.Responses;
        foreach (Response response in responses)
        {
            Debug.Log(response.ResponseText);
        }
    }
}
