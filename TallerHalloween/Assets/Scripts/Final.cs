using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostWatcher : MonoBehaviour
{
    [Tooltip("Arrastra aquí todos los fantasmas que quieres monitorear")]
    public GameObject[] ghosts;

    [Tooltip("Nombre exacto de la escena a la que quieres cambiar")]
    public string Final;

    private bool sceneLoaded = false;

    void Update()
    {
        if (sceneLoaded) return;

        int remaining = 0;

        foreach (GameObject ghost in ghosts)
        {
            if (ghost != null)
                remaining++;
        }

        if (remaining == 0)
        {
            sceneLoaded = true;
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(Final))
        {
            SceneManager.LoadScene(Final);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el nombre de la siguiente escena en el Inspector.");
        }
    }
}