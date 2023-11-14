using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPT : MonoBehaviour
{
    public float puntos;
    public Text textoPuntos;

    private void Update()
    {
        textoPuntos.text = "Puntos: " + puntos.ToString();
    }
}
