using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public int score = 0;
    public GameObject[] enemySpawns;
    private int currentSpawnIndex = 0;

    void Start()
    {
        // Desactivar todos los spawns excepto el primero.
        for (int i = 1; i < enemySpawns.Length; i++)
        {
            enemySpawns[i].SetActive(false);
        }
    }

    void Update()
    {
        // Actualizar puntaje
        // Aquí debes tener tu lógica para aumentar el puntaje cuando algo sucede en tu juego.

        // Verificar si se ha alcanzado un múltiplo de 100 en el puntaje.
        if (score % 100 == 0 && score != 0)
        {
            // Desactivar el spawn actual
            enemySpawns[currentSpawnIndex].SetActive(false);

            // Destruir el spawn actual
            Destroy(enemySpawns[currentSpawnIndex]);

            // Aumentar el índice del spawn
            currentSpawnIndex++;

            // Verificar si hemos alcanzado el límite de spawns (6 en este caso)
            if (currentSpawnIndex < enemySpawns.Length)
            {
                // Activar el siguiente spawn
                enemySpawns[currentSpawnIndex].SetActive(true);
            }
            else
            {
                // Aquí puedes manejar lo que sucede cuando se alcanzan los 600 puntos.
                Debug.Log("¡Has alcanzado 600 puntos!");
            }
        }
    }
}
