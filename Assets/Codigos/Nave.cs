using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float velocidad = 5f;
    public GameObject balaPrefab;
    public Transform puntoDeDisparo;
    public float velocidadDeBala = 20f;

    [Header("Munición")]
    public int municionMaxima = 50;
    public int municionActual = 50;
    public float tiempoRecarga = 2f; // Tiempo de recarga en segundos
    private bool recargando = false;

    //[Header("Sonido y Efectos Visuales")]
    //public AudioSource disparoSound;
    //public ParticleSystem disparoEffect;

    [Header("TextMesh Pro")]
    public TextMeshProUGUI municionText; // Asigna el objeto TextMesh Pro desde el Inspector

    public float tiempoDeDestruccion = 2f; // Tiempo de destrucción de la bala

    private void Start()
    {
        // Configura el texto de munición inicial
        ActualizarTextoMunicion();
    }

    private void Update()
    {
        MoverNave();

        if (Input.GetMouseButtonDown(0) && !recargando && municionActual > 0)
        {
            Disparar();
        }

        if (Input.GetKeyDown(KeyCode.R) && !recargando)
        {
            StartCoroutine(RecargarMunicion());
        }
    }

    void MoverNave()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(inputHorizontal, inputVertical, 0) * velocidad * Time.deltaTime;
        transform.Translate(movimiento);
    }

    void Disparar()
    {
        municionActual--;
        //disparoSound.Play();
        //disparoEffect.Play();

        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, Quaternion.identity);
        bala.GetComponent<Rigidbody2D>().gravityScale = 0f;
        bala.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidadDeBala);
        Destroy(bala, tiempoDeDestruccion);

        ActualizarTextoMunicion();
    }

    IEnumerator RecargarMunicion()
    {
        recargando = true;
        yield return new WaitForSeconds(tiempoRecarga);
        municionActual = municionMaxima;
        recargando = false;
        ActualizarTextoMunicion();
    }

    void ActualizarTextoMunicion()
    {
        municionText.text = "Municion: " + municionActual.ToString() + " / " + municionMaxima.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JugoGastrico"))
        {
            Debug.Log("Game Over");
            // Implementa la lógica de muerte aquí (reiniciar nivel, mostrar mensaje, etc.)
        }
    }
}
