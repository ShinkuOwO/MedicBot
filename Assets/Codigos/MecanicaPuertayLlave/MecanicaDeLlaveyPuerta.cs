using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaDeLlaveyPuerta : MonoBehaviour
{
    public Camera camaraPersonaje;
    public Camera camaraPuerta;
    public GameObject puerta;

    private bool llaveRecogida = false;
    private bool enTransicion = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !llaveRecogida && !enTransicion)
        {
            llaveRecogida = true;
            enTransicion = true;

            // Desactiva la cámara del personaje y activa la de la puerta (sin usar Cinemachine)
            camaraPersonaje.gameObject.SetActive(false);
            camaraPuerta.gameObject.SetActive(true);

            // Inicia la transición de Cinemachine entre las cámaras
            StartCoroutine(TransicionCamara());
        }
    }

    private IEnumerator TransicionCamara()
    {
        CinemachineConfiner confiner = Camera.main.GetComponent<CinemachineConfiner>();
        if (confiner != null)
        {
            confiner.enabled = false;
        }

        yield return new WaitForSeconds(3f); // Espera 3 segundos y destruye la puerta
        Destroy(puerta);

        yield return new WaitForSeconds(2f); // Espera 2 segundos adicionales

        // Desactiva la llave
        gameObject.SetActive(false);

        // Activa la cámara del personaje y desactiva la de la puerta (sin usar Cinemachine)
        camaraPersonaje.gameObject.SetActive(true);
        camaraPuerta.gameObject.SetActive(false);

        if (confiner != null)
        {
            confiner.enabled = true;
        }

        enTransicion = false;
    }
}
