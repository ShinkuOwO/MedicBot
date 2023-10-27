using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DisparoMovimiento : MonoBehaviour
{

    public int capacidadCartucho = 10;
    public int cartuchosIniciales = 3;
    public TextMeshProUGUI textoUIBalas;
    public TextMeshProUGUI textoUICartucho;
    public TextMeshProUGUI textoUIRecargar;
    public TextMeshProUGUI textoUISinBalas;

    private int balasEnCartucho;
    private int cartuchos;
    private bool recargando = false;

    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f; // Agrega esta línea
    public float fuerzaSalto = 5.0f;
    public Transform puntoInicioRaycast;
    public float longitudRaycast = 0.1f;
    public LayerMask capasDeSuelo;

    private bool enSuelo;

    private Rigidbody2D rb;
    //private Animator animator;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        balasEnCartucho = capacidadCartucho;
        cartuchos = cartuchosIniciales;
        ActualizarTextoUI();
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Fire1") && balasEnCartucho > 0)
        {
            Shoot();
        }
        enSuelo = Physics2D.Raycast(puntoInicioRaycast.position, Vector2.down, longitudRaycast, capasDeSuelo);

        if (enSuelo && Input.GetKeyDown(KeyCode.W))
        {
            Salto();
        }
        if (Input.GetKeyDown(KeyCode.R) && !recargando && cartuchos > 0 && balasEnCartucho < capacidadCartucho)
        {
            StartCoroutine(Recargar());
        }

        //animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent <Rigidbody2D>();
        balasEnCartucho--;
        ActualizarTextoUI();
        if (balasEnCartucho == 0)
        {

        }
        if (isFacingRight)
        {
            rbBullet.velocity = firePoint.right * bulletSpeed;
        }
        else
        {
            rbBullet.velocity = -firePoint.right * bulletSpeed;
        }
    }
    void Salto()
    {
        //animator.SetTrigger("Salto"); // Activa la animación de salto
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }
    private void ActualizarTextoUI()
    {
        textoUIBalas.text = $" {balasEnCartucho}";
        textoUICartucho.text = $"{cartuchos}";

        if (cartuchos == 0)
        {
            textoUISinBalas.text = "Te has quedado sin cartuchos.";
            textoUIRecargar.text = "";
        }
        else
        {
            textoUISinBalas.text = "";
            if (balasEnCartucho == 0)
            {
                textoUIRecargar.text = "Presiona 'R' para recargar.";
            }
            else
            {
                textoUIRecargar.text = "";
            }
        }
    }
    private IEnumerator Recargar()
    {
        recargando = true;
        yield return new WaitForSeconds(0.5f);
        balasEnCartucho = Mathf.Min(capacidadCartucho, 10);
        cartuchos--;
        recargando = false;
        ActualizarTextoUI();
    }
    public void AgregarCartuchos(int cantidad)
    {
        cartuchos += cantidad;
        ActualizarTextoUI();
    }
 

}
