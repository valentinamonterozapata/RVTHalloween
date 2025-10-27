using UnityEngine;

public class CameraObjectTrigger : MonoBehaviour
{
    [Header("Canvas que simula la vista de cámara")]
    public Canvas ghostCameraCanvas;

    [Header("Objeto visual que representa la cámara activa")]
    public GameObject cameraOverlayUI;

    private bool activado = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            activado = true;

            if (ghostCameraCanvas != null)
                ghostCameraCanvas.enabled = true;

            if (cameraOverlayUI != null)
                cameraOverlayUI.SetActive(true);
        }
    }
}