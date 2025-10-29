using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponUIActivator : MonoBehaviour
{
    public GameObject canvasUI;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;

    void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grab.selectEntered.AddListener(OnGrabbed);
        grab.selectExited.AddListener(OnReleased);
        canvasUI.SetActive(false);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        canvasUI.SetActive(true);
    }

    void OnReleased(SelectExitEventArgs args)
    {
        canvasUI.SetActive(false);
    }
}