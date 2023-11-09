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


    private Animator An;
    private bool isFacingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        balasEnCartucho = capacidadCartucho;
        cartuchos = cartuchosIniciales;
        ActualizarTextoUI();
        An = GetComponent<Animator>();
        
    }
    public bool puedesaltar()
    {
        return enSuelo;
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
        enSuelo = Physics2D.Raycast(puntoInicioRaycast.position, Vector2.down, longitudRaycast, capasDeSuelo);
        //Animacion de caminar e idle
        if ((horizontalInput > 0 ||horizontalInput < 0)&& enSuelo)
        {
            An.SetInteger("Estado",1);

        }

        else if (!enSuelo)
        {
            An.SetInteger("Estado", 2);
            
        }

        else
        {
            An.SetInteger("Estado", 0);
        }
        if (Input.GetButtonDown("Fire1") && balasEnCartucho > 0 && enSuelo)
        {
            An.SetTrigger("Disparar");
          
            Shoot();

        }

        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            Salto();
        }
        if (Input.GetKeyDown(KeyCode.R) && !recargando && cartuchos > 0 && balasEnCartucho < capacidadCartucho)
        {
            StartCoroutine(Recargar());
        }
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
    public void Salto()
    {
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
        balasEnCartucho = Mathf.Min(capacidadCartucho, 20);
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
