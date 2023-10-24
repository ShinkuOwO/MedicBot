using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 5f;
   
    public Transform arm;
    public Transform punta1; // Punto de disparo 1 (arriba)
    public Transform punta2; // Punto de disparo 2 (abajo)

    private SpriteRenderer characterSpriteRenderer;
    private SpriteRenderer armSpriteRenderer;
    private Vector3 armLocalPosition;
    private bool isFacingRight = true;
    public float fuerzaSalto = 5.0f;
    public Transform puntoInicioRaycast;
    public float longitudRaycast = 0.1f;
    public LayerMask capasDeSuelo;
    private Rigidbody2D rb;

    private bool enSuelo;


    private void Start()
    {
        characterSpriteRenderer = GetComponent < SpriteRenderer>();
        armSpriteRenderer = arm.GetComponent < SpriteRenderer>();
        armLocalPosition = arm.localPosition;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Voltea el personaje y el brazo
        if (horizontalInput < 0 && isFacingRight)
        {
            FlipCharacter();
        }
        else if (horizontalInput > 0 && !isFacingRight)
        {
            FlipCharacter();
        }

        // Mueve al personaje
        float movement = horizontalInput * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(movement, 0, 0));

        // Ajusta la posición del brazo para encajar con el cuerpo
        if (isFacingRight)
        {
            arm.localPosition = armLocalPosition;
            armSpriteRenderer.flipX = false;
        }
        else
        {
            arm.localPosition = new Vector3(-armLocalPosition.x, armLocalPosition.y, armLocalPosition.z);
            armSpriteRenderer.flipX = true;
        }

        enSuelo = Physics2D.Raycast(puntoInicioRaycast.position, Vector2.down, longitudRaycast, capasDeSuelo);

        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            Salto();
        }

    }

    void Salto()
    {
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        characterSpriteRenderer.flipX = !characterSpriteRenderer.flipX;
    }
}
