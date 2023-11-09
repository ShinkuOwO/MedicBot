using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfeccionMatar : MonoBehaviour
{
    public int maxHealth = 100; // Vida m�xima del enemigo
    private int currentHealth;   // Vida actual del enemigo
    private Controlador gameController;  // Referencia al GameController

    private void Start()
    {
        currentHealth = maxHealth; // Al inicio, la vida actual es igual a la vida m�xima
        gameController = FindObjectOfType<Controlador>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Restar el da�o recibido a la vida actual

        if (currentHealth <= 0)
        {
            Die(); // Si la vida llega a 0 o menos, el enemigo muere
            gameController.EnemyKilled();
        }
    }

    void Die()
    {
        // Aqu� puedes agregar cualquier acci�n que deseas que ocurra cuando el enemigo muere, como destruir el objeto enemigo.
        Destroy(gameObject);
    }
}
