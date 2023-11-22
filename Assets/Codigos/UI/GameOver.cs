using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Variable pública para especificar el nombre de la escena a la que quieres cambiar en el Inspector
    public string nombreDeLaEscena;

    // Método que se ejecutará cuando se presione el botón
    public void CambiarDeEscena()
    {
        // Invocar el cambio de escena después de 1 segundo (puedes ajustar el tiempo según sea necesario)
        Invoke("CargarEscena", 1f);
    }

    // Método para cargar la escena especificada
    private void CargarEscena()
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
