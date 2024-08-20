using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_rbPlayer;
    int m_jump;
    void Start()
    {
        m_rbPlayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            m_rbPlayer.AddForce(new Vector2 (0f, ),ForceMode2D.Force);
        }
    }
}
