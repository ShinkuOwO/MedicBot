using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeCartucho : MonoBehaviour
{
    public int cartuchosExtra = 3; // Cambia esto seg�n cu�ntos cartuchos quieras dar al jugador.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tenga un tag "Player".
        {
            SistemaDeDisparo controlBalas = other.GetComponent<SistemaDeDisparo>();

            if (controlBalas != null)
            {
                controlBalas.AgregarCartuchos(cartuchosExtra);
                Destroy(gameObject); // Destruye el objeto que otorga cartuchos.
            }
        }
    }
}
