using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_rbPlayer;
    [SerializeField] float m_jump;
    [SerializeField] float m_move;

    bool m_isJumping;
    void Start()
    {
        m_isJumping = false;
        m_rbPlayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !m_isJumping)
        {
            print("test");
            //m_rbPlayer.AddForce(new Vector2 (0f,m_jump ),ForceMode2D.Impulse); 
            // sirve para plataformeros y que se patinan como en el hielo
            m_rbPlayer.velocity = new Vector2(0f, m_jump);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_rbPlayer.velocity = new Vector2(-m_move, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_rbPlayer.velocity = new Vector2(m_move, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // no es necesario el comparetag poprque seria redundante
        m_isJumping = false;

    }
}
