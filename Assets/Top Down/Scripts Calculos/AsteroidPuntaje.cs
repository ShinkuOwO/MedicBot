using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidPuntaje : MonoBehaviour
{
    
    public int puntajePorDestruccion = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            // Destruir el asteroide y sumar puntaje al GameManager
            Destroy(gameObject);
            GameManager.instance.SumarPuntaje(puntajePorDestruccion);

        }
    }
}



