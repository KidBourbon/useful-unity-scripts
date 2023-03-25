using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Estados del sistema
/// </summary>
public enum States { Pause }

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// Estado actual del videojuego
    /// </summary>
    [SerializeField] private States _currentState;

    /// <summary>
    /// Propiedad public del estado actual del videojuego
    /// </summary>
    public States CurrentState 
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    /// <summary>
    /// Estado anterior del videojuego
    /// </summary>
    private States _prevState;

    /// <summary>
    /// Pausa el videojuego
    /// </summary>
    public void Pause()
    {
        // Detener el paso del tiempo
        Time.timeScale = 0;

        // Guardar el estado actual
        _prevState = GameManager.Instance.CurrentState;

        // Cambiar hacia el estado Pause
        GameManager.Instance.CurrentState = States.Pause;
    }

    /// <summary>
    /// Reanuda el videojuego
    /// </summary>
    public void Reanude()
    {
        // Reestablecer el paso normal del tiempo
        Time.timeScale = 1;

        // Cambiar hacia el estado previo antes de mostrar el menu de pausa
        CurrentState = _prevState;
    }

    /// <summary>
    /// Carga una escena dado un nombre
    /// </summary>
    /// <param name="name">Nombre de la escena</param>
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// Cierra el videojuego
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
