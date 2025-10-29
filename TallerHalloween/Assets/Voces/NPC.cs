using UnityEngine;
using TMPro;
using System.Collections;

public class NPCDialogueTriggerVR : MonoBehaviour
{
    [Header("Diálogo")]
    public AudioSource npcAudio;
    [TextArea]
    public string dialogueText;
    public TextMeshProUGUI subtitleText;
    public GameObject subtitlePanel;

    [Header("Detección VR")]
    public string triggerTag = "DialogueTrigger";

    [Header("Tipeo")]
    public float typingSpeed = 0.04f;
    public float fallbackDuration = 3f; // Duración si no hay audio

    private bool hasSpoken = false;
    private Coroutine typingCoroutine;

    void OnTriggerEnter(Collider other)
    {
        if (hasSpoken || !other.CompareTag(triggerTag)) return;

        hasSpoken = true;

        // Mostrar panel sí o sí
        if (subtitlePanel != null)
        {
            subtitlePanel.SetActive(true);
        }

        // Reproducir audio si existe
        if (npcAudio != null && npcAudio.clip != null)
        {
            npcAudio.Play();
            Invoke(nameof(ClearSubtitle), npcAudio.clip.length);
        }
        else
        {
            Invoke(nameof(ClearSubtitle), fallbackDuration);
        }

        // Transcribir texto con efecto de tipeo
        if (subtitleText != null)
        {
            subtitleText.text = "";
            typingCoroutine = StartCoroutine(TypeText(dialogueText));
        }
    }

    IEnumerator TypeText(string text)
    {
        foreach (char c in text)
        {
            subtitleText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void ClearSubtitle()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        if (subtitleText != null)
        {
            subtitleText.text = "";
        }

        if (subtitlePanel != null)
        {
            subtitlePanel.SetActive(false);
        }
    }
}