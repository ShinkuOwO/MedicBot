using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSumarVida : MonoBehaviour
{
    public int cantidadSumaVida = 20; // Cantidad de vida que suma

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorDeVida controladorDeVida = other.GetComponent<ControladorDeVida>();

            if (controladorDeVida != null)
            {
                controladorDeVida.AumentarVida(cantidadSumaVida);
            }

            // Destruye el �tem despu�s de recogerlo
            Destroy(gameObject);
        }
    }
}
