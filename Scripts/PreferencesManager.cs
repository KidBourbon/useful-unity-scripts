using System.Collections.Generic;
using UnityEngine;

public class PreferencesManager : Singleton<PreferencesManager>
{
    #region Claves
    /// <summary>
    /// Clave para guardar el ancho de la pantalla
    /// </summary>
    private const string _screenWidthKey = "screenWidth";

    /// <summary>
    /// Clave para guardar la altura de la pantalla
    /// </summary>
    private const string _screenHeightKey = "screenHeight";

    /// <summary>
    /// Clave para guardar el modo de pantalla
    /// </summary>
    private const string _fullScreenKey = "fullScreen";

    /// <summary>
    /// Clave para guardar la calidad grafica actual
    /// </summary>
    private const string _graphicQualityKey = "graphicQuality";

    /// <summary>
    /// Clave para guardar el volumen actual
    /// </summary>
    private const string _volumeKey = "volume";

    /// <summary>
    /// Clave para guardar la sensibilidad del mouse
    /// </summary>
    private const string _mouseSensitivityKey = "mouseSensitivity";

    /// <summary>
    /// Clave para saber si es la primera vez que se carga el software
    /// </summary>
    private const string _firstLoadKey = "firstLoad";
    #endregion

    #region Valores
    /// <summary>
    /// Ancho de la pantalla
    /// </summary>
    public int ScreenWidth
    {
        get => PlayerPrefs.GetInt(_screenWidthKey, Screen.width);
        set
        {
            PlayerPrefs.SetInt(_screenWidthKey, value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Altura de la pantalla
    /// </summary>
    public int ScreenHeight
    {
        get => PlayerPrefs.GetInt(_screenHeightKey, Screen.height);
        set
        {
            PlayerPrefs.SetInt(_screenHeightKey, value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// El programa se encuentra en modo de pantalla completo?
    /// </summary>
    public bool FullScreen
    {
        // true == 1 and false == 0
        get => PlayerPrefs.GetInt(_fullScreenKey, Screen.fullScreen ? 1 : 0) == 1;
        set
        {
            PlayerPrefs.SetInt(_fullScreenKey, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Calidad grafica actual
    /// </summary>
    public int GraphicQuality
    {
        get => PlayerPrefs.GetInt(_graphicQualityKey, QualitySettings.GetQualityLevel());
        set {
            PlayerPrefs.SetInt(_graphicQualityKey, value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Volumen maestro
    /// </summary>
    public float Volume
    {
        get => PlayerPrefs.GetFloat(_volumeKey, 0.6f);
        set
        {
            PlayerPrefs.SetFloat(_volumeKey, value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Sensbilidad del mouse
    /// </summary>
    public float MouseSensitivity
    {
        get => PlayerPrefs.GetFloat(_mouseSensitivityKey, 0.6f);
        set
        {
            PlayerPrefs.SetFloat(_mouseSensitivityKey, value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Primera vez que se carga el programa?
    /// </summary>
    public bool IsFirstLoad
    {
        // true == 1 and false == 0
        get => PlayerPrefs.GetInt(_firstLoadKey, 1) == 1;
        set {
            PlayerPrefs.SetInt(_firstLoadKey, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    #endregion

    private void Start()
    {
        // Cargar la resolucion y calidad grafica guardadas
        LoadResolution();
        LoadGraphicQuality();
    }

    #region Cargar configuracion inicial
    /// <summary>
    /// Carga la resolucion salvada
    /// </summary>
    private void LoadResolution()
    {
        Screen.SetResolution(ScreenWidth, ScreenHeight, FullScreen);
    }

    /// <summary>
    /// Carga la calidad grafica salvada
    /// </summary>
    private void LoadGraphicQuality()
    {
        QualitySettings.SetQualityLevel(GraphicQuality);
    }
    #endregion
}
