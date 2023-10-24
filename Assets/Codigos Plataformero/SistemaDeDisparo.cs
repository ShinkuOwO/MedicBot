using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeDisparo : MonoBehaviour
{
    public Slider sliderCuras; // Asigna el Slider en el Inspector
    public TextMeshProUGUI advertenciaText; // Asigna el TextMeshProUGUI en el Inspector
    public Image imagenParpadeante; // Asigna la imagen parpadeante en el Inspector
    public int CurasRestantes = 10; // Número inicial de disparos disponibles
    private bool advertenciaActiva = false;
    private bool parpadeoActivo = false;


    [Header("Inserta el brazo que va a disparar")]
    public Transform puntaDelBrazo1;
    public GameObject balaPrefab1;
    public Transform puntaDelBrazo2;
    public GameObject balaPrefab2;
    public float velocidadBala1 = 10f;
    public float velocidadBala2 = 10f;

    public int capacidadCartucho = 10;
    public int cartuchosIniciales = 3;
    public TextMeshProUGUI textoUIBalas;
    public TextMeshProUGUI textoUICartucho;
    public TextMeshProUGUI textoUIRecargar;
    public TextMeshProUGUI textoUISinBalas;

    private int balasEnCartucho;
    private int cartuchos;
    private bool recargando = false;
    private void Start()
    {
        balasEnCartucho = capacidadCartucho;
        cartuchos = cartuchosIniciales;
        ActualizarTextoUI();
        ActualizarSlider(); // Asegúrate de que el Slider esté configurado al principio
        advertenciaText.gameObject.SetActive(false); // Desactiva la advertencia al principio
        imagenParpadeante.gameObject.SetActive(false); // Desactiva la imagen parpadeante al principio
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
    private void Update()
    {
        // Obtén la posición del cursor en el mundo
        Vector3 posicionCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcula la dirección hacia la que apuntar
        Vector3 direccion = (posicionCursor - transform.position).normalized;

        // Rotar el brazo para apuntar hacia el cursor
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angulo);

        // Disparar una bala si se presiona el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0) && CurasRestantes > 0)
        {
            disparar1();
            CurasRestantes--;
            ActualizarSlider(); // Actualiza el Slider después de cada disparo
            if (CurasRestantes == 2 && !advertenciaActiva)
            {
                advertenciaActiva = true;
                StartCoroutine(ActivarAdvertencia());
            }
        }
        if (CurasRestantes <= 0)
        {
            Debug.Log("Has perdido. No pudiste salvar la vida.");
            // Aquí puedes agregar cualquier lógica adicional para manejar la derrota.
        }
        if (Input.GetMouseButtonDown(1) && balasEnCartucho > 0)
        {
            disparar2();
        }
        if (Input.GetKeyDown(KeyCode.R) && !recargando && cartuchos > 0 && balasEnCartucho < capacidadCartucho)
        {
            StartCoroutine(Recargar());
        }



    }

    void disparar1()//Enemigo
    {
        // Crear una nueva bala en la punta del brazo
        GameObject bala1 = Instantiate(balaPrefab1, puntaDelBrazo1.position, puntaDelBrazo1.rotation);

        // Obtener el componente Rigidbody2D de la bala y aplicarle una velocidad
        Rigidbody2D rb = bala1.GetComponent<Rigidbody2D>();
        rb.velocity = puntaDelBrazo1.right * velocidadBala1;
    }
    void disparar2()//Limpiar Zona
    {
        // Crear una nueva bala en la punta del brazo
        GameObject bala2 = Instantiate(balaPrefab2, puntaDelBrazo2.position, puntaDelBrazo2.rotation);

        // Obtener el componente Rigidbody2D de la bala y aplicarle una velocidad
        Rigidbody2D rb = bala2.GetComponent<Rigidbody2D>();
        rb.velocity = puntaDelBrazo2.right * velocidadBala2;
        balasEnCartucho--;
        ActualizarTextoUI();
        if (balasEnCartucho == 0)
        {

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
    private void ActualizarSlider()
    {
        // Actualiza el valor del Slider según los disparos restantes
        sliderCuras.value = CurasRestantes;
    }
    private IEnumerator ActivarAdvertencia()
    {
        // Activa la advertencia y hace que el texto y la imagen parpadeen
        advertenciaText.gameObject.SetActive(true);

        while (CurasRestantes == 2)
        {
            parpadeoActivo = !parpadeoActivo;
            advertenciaText.gameObject.SetActive(parpadeoActivo);
            imagenParpadeante.gameObject.SetActive(parpadeoActivo);
            yield return new WaitForSeconds(0.5f);
        }

        // Asegúrate de que el texto e imagen parpadeante se apaguen al final
        advertenciaText.gameObject.SetActive(false);
        imagenParpadeante.gameObject.SetActive(false);
    }
}
