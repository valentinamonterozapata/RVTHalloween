using UnityEngine;

public class GhostPhotoShooter : MonoBehaviour
{
    [Header("Transform desde donde se lanza el disparo")]
    public Transform shootOrigin;

    [Header("Distancia máxima")]
    public float maxDistance = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Click derecho o botón de disparo
        {
            Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                GhostTarget ghost = hit.collider.GetComponent<GhostTarget>();
                if (ghost != null)
                {
                    ghost.EliminarFantasma();
                }
            }
        }
    }
}