using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Evita duplicados
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persiste entre escenas
    }
}