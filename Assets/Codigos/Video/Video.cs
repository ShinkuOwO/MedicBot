using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    public int minutosParaCambio = 3;
    public int segundosParaCambio = 0;
    public string nombreDeLaSiguienteEscena = "NombreDeTuSiguienteEscena";

    private float tiempoTranscurrido = 0f;
    private bool textoMostrado = false;

    public TextMeshProUGUI textoMeshPro;

    void Start()
    {
        if (textoMeshPro == null)
        {
            Debug.LogError("TextoMesh Pro no asignado en el Inspector.");
        }

        // Desactivar el texto al inicio
        textoMeshPro.gameObject.SetActive(false);
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (!textoMostrado && tiempoTranscurrido >= ((minutosParaCambio * 60) + segundosParaCambio) / 2)
        {
            MostrarTexto();
        }

        if (textoMostrado && Input.GetKeyDown(KeyCode.Space))
        {
            CambiarEscena();
        }

        if (tiempoTranscurrido >= (minutosParaCambio * 60) + segundosParaCambio)
        {
            CambiarEscena();
        }
    }

    void MostrarTexto()
    {
        // Activar el texto cuando se debe mostrar
        textoMeshPro.gameObject.SetActive(true);
        textoMeshPro.text = "Presiona 'ESPACIO' para saltar historia";
        textoMostrado = true;
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(nombreDeLaSiguienteEscena);
    }
}
