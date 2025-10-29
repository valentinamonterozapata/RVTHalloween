using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    public GameObject deathEffect;
    public Animator ghostAnimator;
    public float destroyDelay = 1f;

    private bool isDying = false;

    public void Eliminate()
    {
        if (isDying) return;
        isDying = true;

        if (ghostAnimator != null)
        {
            ghostAnimator.SetTrigger("Die");
        }

        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Notificar al gestor
        GhostManager manager = FindObjectOfType<GhostManager>();
        if (manager != null)
        {
            manager.RegisterGhostKill();
        }

        Destroy(gameObject, destroyDelay);
    }
}