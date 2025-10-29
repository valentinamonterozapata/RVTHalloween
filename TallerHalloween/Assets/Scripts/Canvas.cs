using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0); // Opcional: para que no esté al revés
        }
    }
}