using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteBala : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala")) // Aseg�rate de que la bala tenga el tag "Bala"
        {
            Destroy(collision.gameObject); // Destruye la bala cuando colisiona con el l�mite de la c�mara
        }
    }
}
