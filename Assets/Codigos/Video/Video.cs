using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    // Variables públicas para establecer los minutos, segundos y nombre de la escena deseados
    public int minutosParaCambio = 2;
    public int segundosParaCambio = 0;
    public string nombreDeLaSiguienteEscena = "NombreDeTuSiguienteEscena";

    // Variables privadas para realizar un seguimiento del tiempo transcurrido
    private float tiempoTranscurrido = 0f;

    void Update()
    {
        // Aumentar el tiempo transcurrido en cada frame
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si ha pasado el tiempo deseado
        if (tiempoTranscurrido >= (minutosParaCambio * 60) + segundosParaCambio)
        {
            // Cambiar a la escena especificada
            SceneManager.LoadScene(nombreDeLaSiguienteEscena);
        }
    }
}
