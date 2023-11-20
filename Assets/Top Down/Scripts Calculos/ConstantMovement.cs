using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstantMovement : MonoBehaviour {
    public float speed;

    void Update () 
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    
    if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destruir el asteroide y sumar puntaje al GameManager
            Destroy(gameObject);
        }
    }

}