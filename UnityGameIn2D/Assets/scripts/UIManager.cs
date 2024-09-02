using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Esta es la instancia del UIManager
    /// </summary>
    public static UIManager instance;

    [SerializeField] List<GameObject> m_listOfSign;

    UIState m_currentState;
    int m_newPosition;

    #region Funciones Publicas

    /// <summary>
    /// cambia el estado del UIManager
    /// </summary>
    /// <param name="p_newState"></param>

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
                activateNewSign();
                break;
            case UIState.DesactivateSign:
                desactivateNewSign();
                break;
        }

    }

    public void setNewRandomPosition(int p_newSign)
    {
        m_newPosition = p_newSign;
    }
    #endregion


    #region Funciones Privadas
    void Awake()
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

    void activateNewSign()
    {
        m_listOfSign[m_newPosition].SetActive(true);
        StartCoroutine(TimeToTurnOffSign(m_newPosition));
    }
    void desactivateNewSign()
    {
        m_listOfSign[m_newPosition].SetActive(false);
    }

    #endregion

  
    IEnumerator TimeToTurnOffSign(int p_newSign)
    {// cuando tengamos activatodo el activatenewsign le podemos poner que spawne los enemigos cada cierto segundos 
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
