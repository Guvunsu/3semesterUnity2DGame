using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] float m_jump;
    [SerializeField] float m_movement;
    Rigidbody2D m_rb2D;

    bool m_inFloor;

    void Start()
    {
        m_rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && m_inFloor)
        {
            //m_rb2D.AddForce(new Vector2(0,m_jump), ForceMode2D.Impulse);
            m_rb2D.velocity = new Vector2(m_rb2D.velocity.x, m_jump);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_rb2D.velocity = new Vector2(-m_movement, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_rb2D.velocity = new Vector2(m_movement, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            m_inFloor = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        m_inFloor = false;
    }

}
