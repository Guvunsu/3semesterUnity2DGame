using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    LevelManagerState m_currentState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        changeLevelManagerState(LevelManagerState.Game);
    }

    public void changeLevelManagerState(LevelManagerState p_newState)
    {
        if (p_newState == m_currentState)
        {
            return;
        }

        m_currentState = p_newState;

        switch (m_currentState)
        {
            case LevelManagerState.None:
                break;
            case LevelManagerState.Game:
                game();
                break;
            case LevelManagerState.GameOver:
                break;
        }

    }

    void game()
    {
        int temp_newValue = Random.Range(0, 2);

        UIManager.instance.activateNewSign(temp_newValue);
        UIManager.instance.changeUIManagerState(UIState.ActivateNewSign);
    }
}

public enum LevelManagerState
{
    None,
    Game,
    GameOver
}
