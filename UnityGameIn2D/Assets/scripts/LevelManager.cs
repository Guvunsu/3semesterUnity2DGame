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
    [SerializeField] private float timerTotal = 60;
    [SerializeField] private TextMeshProUGUI textoUGUI;

    //variables primitivas (para el GUI)
    int minutes;
    int seconds;
    string timerString;
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
    ///hago 2 variables tipo entero llamado minutos y segundos y me debe regresar de manera 
    ///flotante sobre 60 y en segundos minutos * 60
    ///en un string darle un formato de mnutos y segundos y me debe regresar ese formato {
    ///cuando termine
    /// </summary>
    /// <returns></returns>
    public string timeFormat() {
        minutes = Mathf.FloorToInt(timerTotal / 60f);
        seconds = Mathf.FloorToInt(timerTotal - minutes * 60f);

        timerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        return timerString;
    }
    /// <summary>
    /// el texto vinculado a este scrip le dara la capacidad de tener acceso a la funcion 
    /// del formato del string del tiempo 
    /// mi floatante que es igual a 60f se le restara -1 
    /// si mi tiempo total es menor o igual a 0 se termina el programa
    /// </summary>
    public void timer() {

        textoUGUI.text = timeFormat();
        timerTotal -= 1 * Time.deltaTime;
        if (timerTotal >= 0) {
        } else return;

    }

}
#endregion


/// <summary>
/// llamaos un enum de tipo LevelManagerState donde nombrarmeos los estados dentro del gameplay
/// </summary>
public enum LevelManagerState {
    None,
    CreateNewEnemy,
    GameOver
}