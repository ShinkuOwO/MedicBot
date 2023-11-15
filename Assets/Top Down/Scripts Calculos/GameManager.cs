using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text puntajeTexto;
    private int puntaje = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ActualizarPuntajeTexto();
    }

    public void SumarPuntaje(int cantidad)
    {
        puntaje += cantidad;
        ActualizarPuntajeTexto();

        Debug.Log("Puntaje actualizado. Puntaje actual: " + puntaje);
    }

    void ActualizarPuntajeTexto()
    {
        if (puntajeTexto != null)
        {
            puntajeTexto.text = "Puntaje:" + puntaje;
        }
    }
}

