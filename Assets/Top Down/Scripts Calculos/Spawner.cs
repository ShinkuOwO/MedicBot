using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public int cantidadDeSpawneo = 5;
    public float timeToSpawn;
    public GameObject[] Calculo;
    public Transform[] spawners;

    void Start()
    {
        // Inicia la corutina para spawnear objetos
        StartCoroutine(SpawnearAsteroides());
    }
    IEnumerator SpawnearAsteroides()
    {
        
        for (int i = 0; i < cantidadDeSpawneo; i++)
        {
            // Instancia el objeto
            Instantiate(Calculo[Random.Range(0, Calculo.Length)],spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);

            // Espera un tiempo antes de spawnear el siguiente objeto
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}