using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSumarVida : MonoBehaviour
{
    public int cantidadSumaVida = 20; // Cantidad de vida que suma
    [SerializeField] private AudioClip Vida;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorDeVida controladorDeVida = other.GetComponent<ControladorDeVida>();

            if (controladorDeVida != null && !controladorDeVida.TieneTodaLaVida())
            {
                controladorDeVida.AumentarVida(cantidadSumaVida);
                Sonidos.Instance.EjecutarSonido(Vida);

                // Destruye el ítem después de recogerlo
                Destroy(gameObject);
            }
        }
    }
}
