using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;// aguregue este para el load

public class LevelManager : MonoBehaviour {
    #region Variables 
    // instancia para mi nivel
    public static LevelManager instance;
    // para el tiempo
    [SerializeField] private float timerTotal = 90;
    [SerializeField] private TextMeshProUGUI textoUGUI;

    //variables para que funcione el timer 
    private bool timerUp = false;

    //variables primitivas (para el GUI)
    int minutes;
    int seconds;
    string timerString;
    // para el panel de derrota
    bool losePanelIsOpen = false;
    bool isGameLose = false;
    // variable de tipo de libreria Enum 
    LevelManagerState m_currentState { get; set; }
    #endregion

    #region Funciones Publicas
    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(instance);
        }
    }

    void Start() {
        losePanelIsOpen = false;
        changeLevelManagerState(LevelManagerState.CreateNewEnemy);
    }
    /// <summary>
    /// Hago una fucnion publica que llama una libreria de tipo Enum p_newState llamandola igualmente m_currentState, se sale 
    /// hacemos una funcion de cambio y pasara por cada caso del estado de LevelManagerState que accedera a una lista enum
    /// al llegar en la lista de Game , se llamara la funcion game(), al terminar y llamar GameOver se termina de ejecutar
    /// </summary>
    /// <param name="p_newState"></param>
    public void changeLevelManagerState(LevelManagerState p_newState) {
        if (p_newState == m_currentState) {
            return;
        }

        m_currentState = p_newState;

        switch (m_currentState) {
            case LevelManagerState.None:
                break;
            case LevelManagerState.CreateNewEnemy:
                game();
                break;
            case LevelManagerState.GameOver:
                break;
        }

    }
    #endregion

    #region Funciones Privadas
    /// <summary>
    /// llamaremos una variable de tipo entero temp_newValue que sera igual una generacion aleatoria de un rango de 3 opciones
    /// llamaremos a un scrip UIManager donde llamara aparecera una nueva posicion random de 3 opciones
    /// Luego de nuevo, pero ahora aaccedera a la funcin que activara la señal y desaparecera accediendo a nuestra lista de enum que llama esta
    /// </summary>
    void game() {

        int temp_newValue = Random.Range(0, 2);

        UIManager.instance.setNewRandomPosition(temp_newValue);
        UIManager.instance.changeUIManagerState(UIState.ActivateNewSign);
        changeLevelManagerState(LevelManagerState.None);
    }
    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public string timeFormat() {
        minutes = Mathf.FloorToInt(timerTotal / 60f);
        seconds = Mathf.FloorToInt(timerTotal - minutes * 60f);

        timerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        return timerString;
    }

    public void timer() {
        if (timerTotal > 0 && !timerUp) {
            timerTotal -= Time.deltaTime;
        } else timerUp = true;

        textoUGUI.text = timeFormat();
    }

    //para resetear el timer
    public float ReturnTimer() {
        return timerTotal;
    }

    public bool TimerUp {
        // regresa un valor que esta afuera del script

        get => timerUp;

        //establece un nuevo valor en una variable

        set => timerUp = value;
    }
    public void activateLosePanel() {
        //esta sirve para activar la escena de muerte/derrota cuando hayas perdido

        losePanelIsOpen = true;
    }
    public bool IsGameLose {
        get => IsGameLose;
        set => isGameLose = value;


    }
    public void sceneSwitch(string sceneName) {

        //esto me hace cambiar de UI´s 

        losePanelIsOpen = true;
        isGameLose = true;
        SceneManager.LoadScene(sceneName);
    }
    #endregion
}

/// <summary>
/// llamaos un enum de tipo LevelManagerState donde nombrarmeos los estados dentro del gameplay
/// </summary>
public enum LevelManagerState {
    None,
    CreateNewEnemy,
    GameOver
}