using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorCalculo : MonoBehaviour
{
    // Etiqueta del jugador y del enemigo
    private const string PLAYER_TAG = "Player";
    private const string ENEMY_TAG = "Enemy";

    // Método llamado cuando otro collider entra en contacto con este collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si la colisión involucra al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Permitir que el jugador colisione
            // Puedes agregar aquí cualquier otra lógica para el jugador
        }

        // Comprobar si la colisión involucra al enemigo
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Evitar que el enemigo colisione
            // Puedes agregar aquí cualquier otra lógica para el enemigo
            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            // Verificar si el componente Rigidbody2D existe
            if (enemyRigidbody != null)
            {
                // Invertir la velocidad del enemigo para simular un rebote
                enemyRigidbody.velocity = -enemyRigidbody.velocity;
            }
            // Por ejemplo, puedes detener el movimiento del enemigo o hacer que rebote
        }
    }
}

