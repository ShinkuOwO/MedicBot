using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class ControladorDeVida : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;
    public Slider sliderDeVida; // Arrastra y suelta el Slider en el Inspector

    private void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarSliderDeVida();
    }

    private void ActualizarSliderDeVida()
    {
        if (sliderDeVida != null)
        {
            float valorVidaNormalizado = (float)vidaActual / vidaMaxima;
            sliderDeVida.value = valorVidaNormalizado; // Actualiza el valor del Slider normalizado
        }
    }

    public void RecibirDano(int cantidadDano)
    {
        vidaActual -= cantidadDano;

        // Asegúrate de que la vida no sea menor que 0
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        ActualizarSliderDeVida();

        if (vidaActual <= 0)
        {
            SceneManager.LoadScene("Pulmon ej");
        }
    }

    public void AumentarVida(int cantidadVida)
    {
        vidaActual += cantidadVida;

        // Asegúrate de que la vida no supere el valor máximo
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        ActualizarSliderDeVida();
    }
}
