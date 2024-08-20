using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] GameObject m_gameObject;
    Rigidbody2D m_Rigidbody2D;

    [SerializeField] float m_speed;

    [SerializeField] Transform m_leftSpawnPosition;
    [SerializeField] Transform m_rightSpawnPosition;
    [SerializeField] Transform m_upSpawnPosition;

    [SerializeField] EnviromentState m_currentState;
    void Start()
    {
        ChangeEnviromentState(EnviromentState.Game);
    }
    private void ChangeEnviromentState(EnviromentState p_newState)
    {
        if (p_newState == m_currentState)
        {
            return;
        }
        m_currentState = p_newState;

        switch (m_currentState)
        {
            case EnviromentState.None: break;
            case EnviromentState.Game:
                break;
                game();
            case EnviromentState.GameOver:
                break;
                gameOver();
        }
    }
    void game()
    {
        Instantiate(enemy, m_leftSpawnPosition.position, Quaternion.identity);
    }
    void gameOver()
    {

    }
    void Update()
    {

    }
    public enum EnviromentState
    {
        None,
        Game,
        GameOver
    }
}
