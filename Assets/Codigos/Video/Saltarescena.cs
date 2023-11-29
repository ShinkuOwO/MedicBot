using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saltarescena : MonoBehaviour
{
    // Nombre de la escena configurable desde el Inspector de Unity
    public string nombreDeLaEscena = "NombreDeTuEscena";

    void Update()
    {
        // Verificar si se presiona la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cambiar a la escena especificada
            SceneManager.LoadScene(nombreDeLaEscena);
        }
    }
}
