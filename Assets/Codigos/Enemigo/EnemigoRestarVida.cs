using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRestarVida : MonoBehaviour
{
    public int cantidadRestaVida = 10; // Cantidad de vida que resta

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorDeVida controladorDeVida = other.GetComponent<ControladorDeVida>();

            if (controladorDeVida != null)
            {
                controladorDeVida.RecibirDano(cantidadRestaVida);
            }
        }
    }
}
