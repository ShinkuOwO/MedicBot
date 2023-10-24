using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionConSlider : MonoBehaviour
{
    public Slider slider; // Arrastra el Slider que deseas controlar en el Inspector.

    void Start()
    {
        // Deshabilita la interacción del Slider al iniciar el juego.
        slider.interactable = false;
    }
}
