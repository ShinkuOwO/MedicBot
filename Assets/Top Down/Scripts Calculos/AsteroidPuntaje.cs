using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidPuntaje : MonoBehaviour
{
    
    public int valor = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            // Destruir el asteroide y sumar puntaje al GameManager
            GameManager.Instance.SumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
}



