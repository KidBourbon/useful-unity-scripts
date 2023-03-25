using UnityEngine;

/// <summary>
/// Implementación genérica del patrón Singleton que puede ser utilizada 
/// para cualquier clase en Unity
/// </summary>
/// <typeparam name="T">Tipo generico subclase de MonoBehaviour</typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// Instancia unica del objeto Singleton
    /// </summary>
    protected static T s_instance;

    /// <summary>
    /// Propiedad pública que devuelve la única instancia del objeto Singleton
    /// </summary>
    public static T Instance
    {
        get
        {
            // Si la instancia aún no se ha creado, busca el objeto existente
            // en la escena. Si no hay ninguno, crea uno nuevo.
            if (s_instance == null)
            {
                s_instance = FindObjectOfType<T>();
                
                if (s_instance == null)
                {
                    Debug.LogError(message: "The Singleton object is null");
                }
            }

            return s_instance;
        }
    }

    protected virtual void Awake()
    {
        // Si aún no hay una instancia, establece esta instancia como la única
        // y se asegura que persista en la escena
        if (s_instance == null)
        {
            s_instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        // De lo contrario, si ya existe una instancia, destruye esta instancia.
        else
        {
            Destroy(gameObject);
        }
    }
}
