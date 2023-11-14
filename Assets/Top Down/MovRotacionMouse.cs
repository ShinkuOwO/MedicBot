using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Jobs;

public class MovRotacionMouse : MonoBehaviour
{
    [Header("MovimientoCamara")]

    private Vector3 objetivo;

    [SerializeField] private Camera camara;

    [Header("MoviientoJugador")]

    [SerializeField] private float velociddMovimiento;

    private Vector2 direccion;

    private Rigidbody2D rb2D;

    private Vector2 input;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        objetivo = camara.ScreenToWorldPoint(Input.mousePosition);

        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0,0,anguloGrados);

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        direccion = input.normalized;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velociddMovimiento * Time.fixedDeltaTime);
    }
}
