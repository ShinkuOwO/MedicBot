using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaLlave : MonoBehaviour
{
    public CinemachineVirtualCamera camaraPersonaje;
    public Camera camaraPuerta;
    public GameObject puerta;
    public float tiempoEspera = 5f;

    private bool llaveRecogida = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !llaveRecogida)
        {
            llaveRecogida = true;

            // Desactiva la cámara de personaje y activa la de la puerta
            camaraPersonaje.Priority = 0;
            camaraPuerta.enabled = true;

            // Destruye la puerta después del tiempo especificado
            StartCoroutine(DestruirPuerta());
        }
    }

    private IEnumerator DestruirPuerta()
    {
        yield return new WaitForSeconds(tiempoEspera);

        // Destruye la puerta
        Destroy(puerta);
    }
}
