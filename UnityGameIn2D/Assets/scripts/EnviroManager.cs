using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{
    #region Variables 
    public static EnviroManager Instance;
    // mi intancia 
    public static EnviroManager instance;

    // mis variables que vere desde mi jerarquia
    [SerializeField] GameObject m_map;
    [SerializeField] float m_speed;
    [SerializeField] Transform m_leftSpawnPosition;
    [SerializeField] Transform m_rightSpawnPosition;
    [SerializeField] Transform m_UpSpawnPosition;
    [SerializeField] EnvironmentState m_currentState;
    Rigidbody2D m_rb2D;
    public GameObject Enemy;

    #endregion

    #region Funciones Publicas
    void Start()
    {

        changeEnvironmentManagerState(EnvironmentState.ReadyToSpawnEnemy);

    }
    public void Awake()
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
    /// <summary>
    /// Hacemos una fucnion que llama un enum que podemos ver desde el Inspector de Unity anclado a un gameObject llamandolo aqui como p_newState y se sale
    /// ese p_newState lo igualaremos con una variante del mismo enum pero afuera de la funcion y seran iguales
    /// con un switch indicamos los casos que debe pasar el codigo, al llegar a funcion game(),
    /// se ejecutara todo lo de esa funcion y psara all siguient evento si uno muere se ejecuta funcion gameOver() y se rompe(termina)
    /// </summary>
    /// <param name="p_newState"></param>
    public void changeEnvironmentManagerState(EnvironmentState p_newState)
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
            case EnvironmentState.ReadyToSpawnEnemy:
                createEnemy();
                break;
            case EnvironmentState.GameOver:
                gameOver();
                break;
        }

    }

    public EnvironmentState getEnviromentState()
    {
        return m_currentState;
    }



    #endregion

    #region Funciones Privadas 

    /// <summary>
    /// Hardcodereo mi codigo con ifs para que instancie señal arrastrando mis gameObjects vacios que posiblemente tendran aleatoriamente hasta mi herachy  
    /// </summary>
    void createEnemy()
    {

        if (Instantiate(Enemy, m_rightSpawnPosition.position, Quaternion.identity))
        {
            changeEnvironmentManagerState(EnvironmentState.ReadyToSpawnEnemy);
            LevelManager.instance.changeLevelManagerState(LevelManagerState.CreateNewEnemy);
            if (Instantiate(Enemy, m_leftSpawnPosition.position, Quaternion.identity))
            {
                changeEnvironmentManagerState(EnvironmentState.ReadyToSpawnEnemy);
            }
            if (Instantiate(Enemy, m_UpSpawnPosition.position, Quaternion.identity))
            {
                changeEnvironmentManagerState(EnvironmentState.ReadyToSpawnEnemy);
            }
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        #endregion
    }
    void gameOver()
    {
    }
}

/// <summary>
/// mi lista de mi maquina de esatdo llamado EnvironmentState para mis esatdos dentro del gameplay
/// </summary>
public enum EnvironmentState
{
    None,
    ReadyToSpawnEnemy,
    GameOver
}
