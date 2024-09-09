using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnviroManager;

public class UIManager : MonoBehaviour
{
    #region Variables
    //Esta es la instancia del UIManager
    public static UIManager instance;

    [SerializeField] List<GameObject> m_listOfSign;
    [SerializeField] GameObject[] m_ArrayOfSign;

    UIState m_currentState;

    int m_newPosition;

    #endregion

    #region Funciones Publicas

    /// <summary>
    /// cambia el estado del UIManager, FMS donde se dedicara a activar y desactivar la adeventencia con un switch y condicional.
    /// Con el nombre de mi variable de ese llamado de libreria de ENUM y otra variable, si~ es verdaramente igual se regresara a su estado original.
    /// con un switch se ejecutara la funcion TimeToTurnOffSign() y finalizara hasta llegar desactivateNewSign()
    /// para activar el temporizador de la señal y se descativara depsues de que pase el tiempo 
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
    /// <summary>
    /// nombraremos esta funcion para colocar la advertencia de manera random y nombrandola con un variable tipo int 
    /// para asignar uno de nuestras opciones numeradas poscisionadas (3)
    /// </summary>
    /// <param name="p_newSign"></param>
    public void setNewRandomPosition(int p_newSign)
    {
        m_newPosition = p_newSign;
    }
    #endregion



    #region Funciones Privadas
    /// <summary>
    /// si nuestra instancia es verdaderamente algun objeto es referencia en Unity
    /// se llama esra, si no, se destruye a si misma
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            m_listOfSign.Add(gameObject);
            m_listOfSign.Clear();
        }
    }
    /// <summary>
    /// hacemas una funcion para activar la ueva señal en cada inicio de de nueva partida 
    /// ocupando una lirberia de Gameobject se le asignara un lugar random gracias a la funcion setNewRandomPosition y se le activa
    /// empieza nuestra corrutina que activara la funcion de tiempo de espera TimeToTurnOffSign y a su vez setNewRandomPosition()
    /// </summary>
    void activateNewSign()
    {
        m_listOfSign[m_newPosition].SetActive(true);
        StartCoroutine(TimeToTurnOffSign(m_newPosition));
    }
    /// <summary>
    /// se llama la libreria de GameObject m_listOfSign para luego llamar la funcion de setNewRandomPosition y desactivarlo
    /// y ya no estara la advertencia
    /// </summary>
    void desactivateNewSign()
    {
        m_listOfSign[m_newPosition].SetActive(false);
    }

    /// <summary>
    /// CORUTINA
    /// llamamos la libreria Enum llamado TimeToTurnOffSign con una variable tipo entero int 
    /// la corutina se parara y desctivara la advertencia depsues de una esclara de tiempo de 3 segundos 
    /// despues de verificar el gameObject asignado random de nuestras opciones par la advertencia y lo desactivara
    /// se pasara a la funcion changeUIManagerState y se verificara con una condicional y un switch el cambio de estados por la lista enum
    /// </summary>
    /// <param name="p_newSign"></param>
    /// <returns></returns>
    IEnumerator TimeToTurnOffSign(int p_newSign)
    {// cuando tengamos activatodo el activatenewsign le podemos poner que spawne los enemigos cada cierto segundos 
        yield return new WaitForSeconds(3);
        m_listOfSign[p_newSign].SetActive(false);
        changeUIManagerState(UIState.DesactivateSign);
        EnviroManager.instance.changeEnvironmentManagerState(EnvironmentState.ReadyToSpawnEnemy);

    }
    #endregion

}
#region ENUM 
/// <summary>
/// llamamos una lista llamada enum  de una libreria UIState que se dedicara a llamar la funcion changeUIManagerState
/// </summary>
public enum UIState
{
    None,
    ActivateNewSign,
    DesactivateSign
}
#endregion

