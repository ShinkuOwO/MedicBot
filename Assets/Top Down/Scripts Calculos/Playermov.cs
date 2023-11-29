using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermov : MonoBehaviour
{
    private Rigidbody2D rb;
   
    public float shootRate = 0.5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawner;

    private float vertical;
    private float horizontal;
    private bool shooting;
    private bool canShoot = true;

    private void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update () 
    {
        vertical = InputManager.Vertical;
        horizontal = InputManager.Horizontal;
        shooting = Input.GetButtonDown("Fire1");

        Shoot ();
    }

    private void Shoot () 
    {
        if (shooting && canShoot) 
        {
            StartCoroutine (FireRate ());
        }
    }

    //Definiremos un metodo que se invocará cuando pasemos por un CheckPoint
   
    private IEnumerator FireRate ()
    {
        canShoot = false;

        var bullet = Instantiate (bulletPrefab, bulletSpawner.position,bulletSpawner.rotation);

        Destroy (bullet, 5);

        yield return new WaitForSeconds (shootRate);

        canShoot = true;
    }
}