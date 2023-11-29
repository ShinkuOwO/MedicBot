using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaDeLlaveyPuerta : MonoBehaviour
{
    public CinemachineVirtualCamera camaraPersonaje;
    public CinemachineVirtualCamera camaraPuerta;
    public GameObject puerta;
    public GameObject objetoConAnimacion;  // Referencia al objeto con la animaci�n
    private Animator animacionPuertaAnimator;

    private bool llaveRecogida = false;
    private bool enTransicion = false;

    private void Start()
    {
        // Obt�n el Animator del objeto con la animaci�n
        animacionPuertaAnimator = objetoConAnimacion.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !llaveRecogida && !enTransicion)
        {
            llaveRecogida = true;
            enTransicion = true;

            // Desactiva la c�mara virtual del personaje y activa la de la puerta
            camaraPersonaje.gameObject.SetActive(false);
            camaraPuerta.gameObject.SetActive(true);

            // Inicia la transici�n de Cinemachine entre las c�maras
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

        yield return new WaitForSeconds(2f); // Espera 3 segundos y ejecuta la animaci�n de la puerta
        if (animacionPuertaAnimator != null)
        {
            animacionPuertaAnimator.SetTrigger("AbrirPuerta");
            // Puedes agregar un evento de animaci�n para llamar a un m�todo espec�fico cuando la animaci�n de apertura termine.
            // Por ejemplo, puedes agregar un evento llamado "OnPuertaAbierta" en la animaci�n de la puerta.
      
        }
        yield return new WaitForSeconds(1f); // Espera 2 segundos adicionales

        // Destruye la puerta al finalizar la animaci�n
        Destroy(puerta);

        // Desactiva la llave
        gameObject.SetActive(false);

        // Activa la c�mara virtual del personaje y desactiva la de la puerta
        camaraPersonaje.gameObject.SetActive(true);
        camaraPuerta.gameObject.SetActive(false);

        if (confiner != null)
        {
            confiner.enabled = true;
        }

        enTransicion = false;
    }
}
