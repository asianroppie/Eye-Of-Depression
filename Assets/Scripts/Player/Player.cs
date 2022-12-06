using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    Rigidbody2D body;
    float horizontal;
    public float runSpeed = 10.0f;
    public int sympathyLevel = 0;
    public int chapterUnlocked = 0;
    public int SceneOnChapter = 0;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (dialogueUI.IsOpen)
        {
            body.velocity = new Vector2(0, 0);
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontal * runSpeed, 0);
    }   
}
