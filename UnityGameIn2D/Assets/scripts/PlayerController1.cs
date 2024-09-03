using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {
    #region Variables 
    [SerializeField] float m_jump;
    [SerializeField] float m_movement;
    Rigidbody2D m_rb2D;

    bool m_inFloor;
    #endregion

    #region Funciones Privadas
    void Start() {
        m_rb2D = GetComponent<Rigidbody2D>();
    }
    void Update() {
        if (Input.GetKeyUp(KeyCode.Space) && m_inFloor) {
            //m_rb2D.AddForce(new Vector2(0,m_jump), ForceMode2D.Impulse);
            m_rb2D.velocity = new Vector2(m_rb2D.velocity.x, m_jump);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            m_rb2D.velocity = new Vector2(-m_movement, 0);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            m_rb2D.velocity = new Vector2(m_movement, 0);
        }
    }
    /// <summary>
    /// en mi funcion tipo privada de la clase OnCollisionEnter2D
    /// si mi Collision2D que esta sujeto a un gameObject toque y aaceda al tag Floor, estas en el suelo por el booleano
    /// misma historia con el tag Enemy pero este destruye el GAMEOBJECT que es sujeto a este 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Floor")) {
            m_inFloor = true;
        }

        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// llamo esta fucnion privada para hacerle saber que al boleano que se referencia en que verdaderamente estoy en el suelo
    /// le hago saber que estoy fuera de esta colision, osea NO estoy e el suelo y ando "flotando,en el aire o en otro tag" 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionExit2D(Collision2D collision) {
        m_inFloor = false;
    }
    #endregion
}
