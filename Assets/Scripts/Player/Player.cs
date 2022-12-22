using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_body;
    private List<GameObject> m_proximityGO;

    public KeyCode interactKey;
    public float runSpeed = 10.0f;

    
    void Start()
    {
        m_body = GetComponent<Rigidbody2D>();
        m_proximityGO = new List<GameObject>();
    }


    private void Update()
    {
        if (!Singleton.runtime.Freezed)
        {
            // All input code shall be on this block....

            if (Input.GetKeyDown(interactKey))
            {
                m_proximityGO.First().SendMessage("Interact");
            }
        }
    }


    private void FixedUpdate()
    {
        var dir = Input.GetAxisRaw("Horizontal");
        m_body.velocity = new Vector2(dir * runSpeed, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
            m_proximityGO.Add(collision.gameObject);
    }


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

            m_proximityGO.First().SendMessage("ActivateIcon", true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
            m_proximityGO.Remove(collision.gameObject);
    }
}
