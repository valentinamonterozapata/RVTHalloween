using UnityEngine;

public class GhostTarget : MonoBehaviour
{
    public GameObject smokeVFX;

    public void EliminarFantasma()
    {
        if (smokeVFX != null)
        {
            Instantiate(smokeVFX, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}