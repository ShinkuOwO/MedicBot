using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si la colisión es con un objeto con la etiqueta "Pared"
        if (collision.gameObject.CompareTag("fondo"))
        {
            // Destruye la bala al impactar con la pared
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("compuerta"))
        {
            // Destruye la bala al impactar con la pared
            Destroy(gameObject);
        }

    }
}