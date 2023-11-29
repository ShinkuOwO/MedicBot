using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public HUD hud;
    public int PuntosTotales { get; private set; }

    private int vidas = 3;

    public GameObject[] CompuertaAnim;
    public GameObject[] Zona;
    //public GameObject[] Vida;

    private Animator[] animators;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("¡Cuidado! Más de un GameManager en escena.");
        }
    }

    private void Start()
    {
        animators = new Animator[CompuertaAnim.Length];

        for (int i = 0; i < CompuertaAnim.Length; i++)
        {
            animators[i] = CompuertaAnim[i].GetComponent<Animator>();
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        hud.ActualizarPuntos(PuntosTotales);
    }

    public void PerderVida()
    {
        vidas--;

        if (vidas == 0)
        {
            // Reiniciamos el nivel.
            SceneManager.LoadScene(0);
        }

        hud.DesactivarVida(vidas);
    }

    public bool RecuperarVida()
    {
        if (vidas == 3)
        {
            return false;
        }

        hud.ActivarVida(vidas);
        vidas++;
        return true;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < CompuertaAnim.Length; i++)
        {
            if (PuntosTotales >= 30 * (i + 1))
            {
                StartCoroutine(EjecutarAnimacion(i));
            }
        }
    }
    IEnumerator EjecutarAnimacion(int index)
    {
        // Configurar la animación "abriendo"
        animators[index].SetBool("abriendo", true);

        // Esperar un tiempo antes de realizar otras acciones
        yield return new WaitForSeconds(2.0f); // Ajusta el tiempo según sea necesario

        // Desactivar los objetos según sea necesario
        CompuertaAnim[index].SetActive(false);
        Zona[index].SetActive(false);

    }
}

