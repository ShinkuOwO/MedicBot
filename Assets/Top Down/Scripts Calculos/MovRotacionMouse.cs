using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Jobs;

public class MovRotacionMouse : MonoBehaviour
{

    //[Header("MovimientoCamara")]

    //private Vector3 objetivo;

    //[SerializeField] private Camera camara;

    //[Header("MoviientoJugador")]

    //[SerializeField] private float velociddMovimiento;

    //private Vector2 direccion;

    //private Rigidbody2D rb2D;

    //private Vector2 input;

    // private void Start()
    // {
    //rb2D = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    // objetivo = camara.ScreenToWorldPoint(Input.mousePosition);

    // float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
    //float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
    // transform.rotation = Quaternion.Euler(0,0,anguloGrados);

    // input.x = Input.GetAxisRaw("Horizontal");
    //input.y = Input.GetAxisRaw("Vertical");
    //direccion = input.normalized;
    // }

    // private void FixedUpdate()
    //{
    //rb2D.MovePosition(rb2D.position + direccion * velociddMovimiento * Time.fixedDeltaTime);
    // }
    public float speed = 5f; // Velocidad de movimiento

    void Update()
    {
        // Obtener la entrada del teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 movement = new Vector3(horizontal, vertical, 0f);

        // Normalizar el vector de movimiento para evitar movimientos más rápidos en diagonal
        movement.Normalize();

        // Mover el personaje
        transform.Translate(movement * speed * Time.deltaTime);

        // Obtener la posición del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección hacia la posición del ratón
        Vector3 lookDirection = mousePosition - transform.position;
        lookDirection.z = 0f; // Mantener solo la componente z en 0 para un movimiento en 2D

        // Rotar el personaje hacia la dirección del ratón
        transform.up = lookDirection.normalized;
    }

}
