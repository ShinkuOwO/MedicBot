using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSalmonella : MonoBehaviour
{
    public int timer = 1;

    public int damage = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
        }
        // Verificar si la colisión es con un enemigo
        if (collision.CompareTag("Enemigo"))
        {
            EnemigoVida enemyHealth = collision.GetComponent<EnemigoVida>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Aplicar daño al enemigo
            }

            // Destruir la bala después de la colisión
            Destroy(gameObject);
        }
        if (collision.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }
}
