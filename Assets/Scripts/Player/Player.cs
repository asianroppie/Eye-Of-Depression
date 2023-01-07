using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_body;
    private List<GameObject> m_proximityGO;
    public Animator animator;
    public static Player instance;

    public KeyCode interactKey;
    public float runSpeed = 10.0f;
    private bool m_FacingRight = true;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        m_body = GetComponent<Rigidbody2D>();
        m_proximityGO = new List<GameObject>();
        Singleton.events.fade_called.AddListener(MovePosition);
        Singleton.events.change_outfit.AddListener(ChangeOutfit);
        Singleton.events.change_character.AddListener(ChangeCharacter);
        Singleton.events.flip_player.AddListener(Flip);
    }


    private void Update()
    {
        if (!Singleton.runtime.Freezed)
        {
            // All input code shall be on this block....

            if (Input.GetKeyDown(interactKey))
            {
                if (m_proximityGO.First() == null)
                {
                    m_proximityGO.RemoveAt(0);
                }
                if (m_proximityGO.Count > 0)
                {
                    m_proximityGO.First().SendMessage("Interact");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        var dir = Input.GetAxisRaw("Horizontal");
        m_body.velocity = new Vector2(dir * runSpeed, 0);
        animator.SetFloat("Speed", Mathf.Abs(dir));
        if (dir > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (dir < 0 && m_FacingRight)
        {
            Flip();
        }
    }

    public void MovePosition()
    {
        this.gameObject.transform.position = new Vector2(-6, this.gameObject.transform.position.y);
        this.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        m_FacingRight = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
            m_proximityGO.Add(collision.gameObject);
    }

    public void ChangeOutfit()
    {
        if(Singleton.runtime.normie)
        {
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(1, 1);
        }
        if(Singleton.runtime.gloomie)
        {
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(3, 1);
        }
    }
    public void ChangeCharacter()
    {
        if (Singleton.runtime.normie)
        {
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(0, 1);
        }
        if (Singleton.runtime.gloomie)
        {
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(2, 1);
        }
    }
    /*public void ChangeNormieWork()
    {
        animator.SetLayerWeight(1, 1);
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (m_proximityGO.Count > 0)
        {
            m_proximityGO.Sort((GameObject a, GameObject b) => { // Sort by closest
                a.SendMessage("ActivateIcon", false);
                b.SendMessage("ActivateIcon", false);
                var distance_to_a = Mathf.Abs(a.transform.position.x - transform.position.x);
                var distance_to_b = Mathf.Abs(b.transform.position.x - transform.position.x);

                if (distance_to_a > distance_to_b) return 1;
                if (distance_to_b > distance_to_a) return -1;
                return 0; // equal distance
            });

            m_proximityGO.First().SendMessage("ActivateIcon", true && !Singleton.runtime.onMonologue);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
            m_proximityGO.Remove(collision.gameObject);
    }
    public void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
