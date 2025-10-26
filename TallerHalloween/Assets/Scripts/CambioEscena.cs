using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    [Tooltip("EscenaDeCarga")]
    public string nombreEscena = "EscenaDeCarga";

    // Esta función se llama al hacer clic en el botón
    public void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}