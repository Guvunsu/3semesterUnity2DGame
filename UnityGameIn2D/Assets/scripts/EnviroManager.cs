using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{
    // //[SerializeField] GameObject m_map;
    //[SerializeField] float m_speed;
    //Rigidbody2D m_rb2D;
    public GameObject Enemy;

    [SerializeField] Transform m_leftSpawnPosition;
    [SerializeField] Transform m_rightSpawnPosition;
    [SerializeField] Transform m_UpSpawnPosition;

    [SerializeField] EnvironmentState m_currentState;

    //void Start()
    //{
    //    changeEnvironmentManagerState(EnvironmentState.Game);
    //}

    void changeEnvironmentManagerState(EnvironmentState p_newState)
    {
        if (p_newState == m_currentState)
        {
            return;
        }

        m_currentState = p_newState;

        switch (m_currentState)
        {
            case EnvironmentState.None:
                break;
            case EnvironmentState.Game:
                game();
                break;
            case EnvironmentState.GameOver:
                gameOver();
                break;
        }

    }

    void game()
    {
        Instantiate(Enemy, m_rightSpawnPosition.position, Quaternion.identity);
    }

    void gameOver()
    {

    }

}

public enum EnvironmentState
{
    None,
    Game,
    GameOver
}
