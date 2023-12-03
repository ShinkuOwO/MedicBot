﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;

    public GameObject[] subAsteroids;
    public int numberOfAsteroids;

    // Start is called before the first frame update
    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
        rb.drag = 0;
        rb.angularDrag = 0;

        rb.velocity = new Vector3 (
            Random.Range (-1f, 1f),
            Random.Range (-1f, 1f),
            Random.Range (-1f, 1f)
        ).normalized * speed;

        rb.angularVelocity = Random.Range (-50f, 50f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.CompareTag("Bala"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            for (var i = 0; i < numberOfAsteroids; i++)
            {
                Instantiate(subAsteroids[Random.Range(0, subAsteroids.Length)],
                            transform.position,
                            Quaternion.identity);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PerderVida();
        }
        
    }
}