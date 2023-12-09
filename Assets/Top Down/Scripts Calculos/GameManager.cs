using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hud;
    public int PuntosTotales { get; private set; }
    private int vidas = 3;
    public GameObject[] CompuertaAnim;
    public GameObject[] Zona;
    public GameObject victoryPanel;
    public TextMeshProUGUI victoryText;
    public TextMeshProUGUI additionalText;
    public TextMeshProUGUI heroText;

    private Animator[] animators;
    private bool isGamePaused = false;

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

        // Desactiva el panel, el TextMeshPro adicional y el nuevo mensaje al inicio del juego
        victoryPanel.SetActive(false);
    }

    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        hud.ActualizarPuntos(PuntosTotales);

        // Check if the total score reaches 180
        if (PuntosTotales >= 180)
        {
            MostrarPanelVictoria();
        }
    }

    public void PerderVida()
    {
        vidas--;

        if (vidas == 0)
        {
            // Reiniciamos el nivel.
            SceneManager.LoadScene(5);
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
        if (!isGamePaused)
        {
            for (int i = 0; i < CompuertaAnim.Length; i++)
            {
                if (PuntosTotales >= 30 * (i + 1))
                {
                    StartCoroutine(EjecutarAnimacion(i));
                }
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
    private void MostrarPanelVictoria()
    {
        // Pause the game
        isGamePaused = true;

        // Activate the victory panel and set any additional texts
        victoryPanel.SetActive(true);
        victoryText.text = "!Has vencido a los Calculos!";
        additionalText.text = "Presiona ENTER para pasar al siguiente nivel";
        heroText.text = "¡Eres un héroe!";
    }
    private void Update()
    {
        // Check for "Enter" key press
        if (isGamePaused && Input.GetKeyDown(KeyCode.Return))
        {
            // Load the menu scene
            SceneManager.LoadScene("Menu"); // Replace "MenuScene" with your actual menu scene name
        }
    }
}

