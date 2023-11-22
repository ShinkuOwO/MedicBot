using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumarPuntosItems : MonoBehaviour
{
    [Header("Establece una cantidad de puntos")]
    [SerializeField] private float cantidadPuntos;
    [Header("Arrastra el texto del canvas")]
    [SerializeField] private SistemaDePuntaje puntaje;
   
    [SerializeField] private AudioClip Hoja;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Sonidos.Instance.EjecutarSonido(Hoja);
            Destroy(gameObject);

        }
    }
}
