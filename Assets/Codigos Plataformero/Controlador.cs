using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public int enemiesToKill = 10;
    private int enemiesKilled = 0;
    private void Start()
    {
        // Puedes inicializar tu juego aquí

    }
    // Este método se llama cuando un enemigo es destruido
    public void EnemyKilled()
    {
        enemiesKilled++;

        // Verifica si se han matado a los 10 enemigos
        if (enemiesKilled >= enemiesToKill)
        {
            // Muestra un mensaje de victoria en la consola
            Debug.Log("¡Ganaste!");
        }
    }
}
