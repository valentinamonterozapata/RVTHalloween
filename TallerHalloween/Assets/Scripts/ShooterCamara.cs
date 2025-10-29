using UnityEngine;
using UnityEngine.InputSystem;

public class GhostShooterRaycast : MonoBehaviour
{
    [Header("Input Action")]
    public InputActionReference shootAction; // Gatillo derecho

    [Header("Raycast")]
    public Transform rayOrigin; // Punto desde donde se lanza el raycast
    public float rayDistance = 50f;

    [Header("Audio")]
    public AudioSource fireSound;

    private bool canShoot = true;

    void Update()
    {
        if (shootAction == null || shootAction.action == null) return;

        float triggerValue = shootAction.action.ReadValue<float>();

        if (canShoot && triggerValue > 0.75f)
        {
            ShootRay();
            canShoot = false;
        }

        if (triggerValue < 0.1f)
        {
            canShoot = true;
        }
    }

    void ShootRay()
    {
        if (fireSound != null)
        {
            fireSound.Play();
        }

        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            GhostBehavior ghost = hit.collider.GetComponent<GhostBehavior>();
            if (ghost != null)
            {
                ghost.Eliminate();
            }
        }
    }
}