using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostManager : MonoBehaviour
{
    public int ghostsKilled = 0;
    public GameObject panelToActivate;
    public AudioSource panelSound; // 🎵 Sonido al activar el panel
    public float panelDuration = 3f;
    public int[] scareTriggers = { 2, 4 };

    public string finalSceneName = "Final";

    public void RegisterGhostKill()
    {
        ghostsKilled++;

        if (System.Array.Exists(scareTriggers, element => element == ghostsKilled))
        {
            panelToActivate.SetActive(true);

            if (panelSound != null)
            {
                panelSound.Play();
            }

            StartCoroutine(HidePanelAfterDelay());
        }

        if (ghostsKilled >= 6)
        {
            LoadFinalScene();
        }
    }

    IEnumerator HidePanelAfterDelay()
    {
        yield return new WaitForSeconds(panelDuration);

        if (panelToActivate != null)
        {
            panelToActivate.SetActive(false);
        }
    }

    void LoadFinalScene()
    {
        if (!string.IsNullOrEmpty(finalSceneName))
        {
            SceneManager.LoadScene(finalSceneName);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el nombre de la escena final.");
        }
    }

    void Start()
    {
        if (panelToActivate != null)
        {
            panelToActivate.SetActive(false);
        }
    }
}