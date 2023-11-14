using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public GameObject controladorDePuntos;
    public float PuntosPorItem;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        { 
            controladorDePuntos.GetComponent<ControladorPT>().puntos += PuntosPorItem;

            Destroy(gameObject);
        }

    }
}
