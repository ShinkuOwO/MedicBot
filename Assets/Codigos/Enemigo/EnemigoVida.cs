using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    public int maxHealth = 100; // Vida máxima del enemigo
    private int currentHealth;   // Vida actual del enemigo
    [SerializeField] private SistemaDePuntaje puntaje;
    

    private void Start()
    {
        currentHealth = maxHealth; // Al inicio, la vida actual es igual a la vida máxima
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Restar el daño recibido a la vida actual

        if (currentHealth <= 0)
        {
            
           
            puntaje.SumarPuntos(cantidadPuntos);
            Die(); // Si la vida llega a 0 o menos, el enemigo muere
        }
    }

    void Die()
    {
        
        // Aquí puedes agregar cualquier acción que deseas que ocurra cuando el enemigo muere, como destruir el objeto enemigo.
        Destroy(gameObject);
    }
}
