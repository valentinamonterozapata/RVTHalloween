using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public int ghostsKilled = 0;
    public GameObject panelToActivate;
    public AudioSource panelSound; // 🎵 Sonido al activar el panel

    public void RegisterGhostKill()
    {
        ghostsKilled++;

        if (ghostsKilled >= 2 && panelToActivate != null && !panelToActivate.activeSelf)
        {
            panelToActivate.SetActive(true);

            if (panelSound != null)
            {
                panelSound.Play();
            }
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