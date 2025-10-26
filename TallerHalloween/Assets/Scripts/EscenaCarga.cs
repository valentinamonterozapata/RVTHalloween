using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingBarController : MonoBehaviour
{
    [Header("Configuración de la barra de carga")]
    public Slider loadingSlider;
    [Tooltip("Nombre exacto de la escena a cargar")]
    public string sceneToLoad = "NombreDeTuEscena";
    [Tooltip("Velocidad visual de llenado del slider")]
    public float fillSpeed = 0.2f;

    private float targetProgress = 0f;
    private AsyncOperation operation;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float realProgress = Mathf.Clamp01(operation.progress / 0.9f);
            targetProgress = realProgress;

            if (loadingSlider.value < targetProgress)
            {
                loadingSlider.value += fillSpeed * Time.deltaTime;
            }

            if (loadingSlider.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}