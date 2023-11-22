using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ControladorDeVida : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;
    public Slider sliderDeVida;

    private void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarSliderDeVida();

        // Desactivar la interacción con el Slider al inicio
        DesactivarInteraccionSlider();
    }

    private void Update()
    {
        // Puedes agregar cualquier lógica adicional aquí si es necesario.
    }

    private void ActualizarSliderDeVida()
    {
        if (sliderDeVida != null)
        {
            float valorVidaNormalizado = (float)vidaActual / vidaMaxima;
            sliderDeVida.value = valorVidaNormalizado;
        }
    }

    private void DesactivarInteraccionSlider()
    {
        if (sliderDeVida != null)
        {
            sliderDeVida.interactable = false;
        }
    }

    public void RecibirDano(int cantidadDano)
    {
        vidaActual -= cantidadDano;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
        ActualizarSliderDeVida();

        if (vidaActual <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void AumentarVida(int cantidadVida)
    {
        vidaActual += cantidadVida;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
        ActualizarSliderDeVida();
    }
    public bool TieneTodaLaVida()
    {
        return vidaActual == vidaMaxima;
    }
}
