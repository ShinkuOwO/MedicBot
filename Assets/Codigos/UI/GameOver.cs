using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Variable p�blica para especificar el nombre de la escena a la que quieres cambiar en el Inspector
    public string nombreDeLaEscena;

    // M�todo que se ejecutar� cuando se presione el bot�n
    public void CambiarDeEscena()
    {
        // Invocar el cambio de escena despu�s de 1 segundo (puedes ajustar el tiempo seg�n sea necesario)
        Invoke("CargarEscena", 1f);
    }

    // M�todo para cargar la escena especificada
    private void CargarEscena()
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
