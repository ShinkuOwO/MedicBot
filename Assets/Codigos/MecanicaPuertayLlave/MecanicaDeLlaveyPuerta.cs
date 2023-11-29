using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaDeLlaveyPuerta : MonoBehaviour
{
    public CinemachineVirtualCamera camaraPersonaje;
    public CinemachineVirtualCamera camaraPuerta;
    public GameObject puerta;
    public GameObject objetoConAnimacion;  // Referencia al objeto con la animación
    private Animator animacionPuertaAnimator;

    private bool llaveRecogida = false;
    private bool enTransicion = false;

    private void Start()
    {
        // Obtén el Animator del objeto con la animación
        animacionPuertaAnimator = objetoConAnimacion.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !llaveRecogida && !enTransicion)
        {
            llaveRecogida = true;
            enTransicion = true;

            // Desactiva la cámara virtual del personaje y activa la de la puerta
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

        yield return new WaitForSeconds(2f); // Espera 3 segundos y ejecuta la animación de la puerta
        if (animacionPuertaAnimator != null)
        {
            animacionPuertaAnimator.SetTrigger("AbrirPuerta");
            // Puedes agregar un evento de animación para llamar a un método específico cuando la animación de apertura termine.
            // Por ejemplo, puedes agregar un evento llamado "OnPuertaAbierta" en la animación de la puerta.
      
        }
        yield return new WaitForSeconds(1f); // Espera 2 segundos adicionales

        // Destruye la puerta al finalizar la animación
        Destroy(puerta);

        // Desactiva la llave
        gameObject.SetActive(false);

        // Activa la cámara virtual del personaje y desactiva la de la puerta
        camaraPersonaje.gameObject.SetActive(true);
        camaraPuerta.gameObject.SetActive(false);

        if (confiner != null)
        {
            confiner.enabled = true;
        }

        enTransicion = false;
    }
}
