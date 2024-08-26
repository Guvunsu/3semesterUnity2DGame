using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] List<GameObject> m_listOfSign;

    UIState m_currentState;

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

    public void changeUIManagerState(UIState p_newState)
    {
        if (p_newState == m_currentState)
        {
            return;
        }

        m_currentState = p_newState;

        switch (m_currentState)
        {
            case UIState.None:
                break;
            case UIState.ActivateNewSign:
                //activateNewSign();
                break;
            case UIState.DesactivateSign:
                break;
        }

    }


    public void activateNewSign(int p_newSign)
    {
        m_listOfSign[p_newSign].SetActive(true);
        StartCoroutine(TimeToTurnOffSign(p_newSign));
    }

    IEnumerator TimeToTurnOffSign(int p_newSign)
    {
        yield return new WaitForSeconds(3);
        m_listOfSign[p_newSign].SetActive(false);
        changeUIManagerState(UIState.DesactivateSign);
    }
}

public enum UIState
{
    None,
    ActivateNewSign,
    DesactivateSign
}
