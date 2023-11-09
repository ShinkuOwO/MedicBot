using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SistemaDePuntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh=GetComponent<TextMeshProUGUI>();
    }
    private void Update ()
    {
        textMesh.text = puntos.ToString("Puntos: 0");
    }
    public void SumarPuntos(float puntosEntradas)
    {
        puntos += puntosEntradas;
    }
}
