using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public int enemiesToKill = 10;
    private int enemiesKilled = 0;
    public GameObject victoryPanel;
    public TextMeshProUGUI victoryText;
    public TextMeshProUGUI additionalText;
    public TextMeshProUGUI heroText; // Nuevo TextMeshProUGUI para mostrar "Eres un héroe"
    public Slider slider; // Asocia tu Slider desde el Inspector

    private bool isGamePaused = false;
    private bool slidersEnabled = true;
    private bool isGameOver = false;

    private void Start()
    {
        // Desactiva el panel, el TextMeshPro adicional y el nuevo mensaje al inicio del juego
        victoryPanel.SetActive(false);
        additionalText.gameObject.SetActive(false);
        heroText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            // Código para pasar al siguiente nivel o realizar alguna acción al presionar Enter
            // Por ejemplo, puedes cargar una nueva escena aquí.
            Debug.Log("Presionaste Enter para pasar al siguiente nivel.");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RestartGame();
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (enemiesKilled >= enemiesToKill)
        {
            // Pausa el juego
            Time.timeScale = 0f;

            // Muestra el cursor del mouse
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Muestra el panel de victoria
            victoryPanel.SetActive(true);

            // Cambia el texto del panel
            victoryText.text = "¡Has vencido al virus gripe!";

            // Activa el TextMeshPro adicional con el mensaje "Presiona Enter para pasar al siguiente nivel"
            additionalText.gameObject.SetActive(true);
            additionalText.text = "Presiona Enter para pasar al siguiente nivel";

            // Activa el nuevo TextMeshPro con el mensaje "Eres un héroe"
            heroText.gameObject.SetActive(true);
            heroText.text = "RECOMENDACION: Cúbrete la boca y la nariz al toser o estornudar. Cuando tosas o estornudes, cúbrete la boca y la nariz con un pañuelo de papel. Si no tienes un pañuelo, cúbrete la boca y la nariz con el antebrazo. Esto ayudará a prevenir que los gérmenes se propaguen a los demás.";

            // Desactiva temporalmente la interacción de los Sliders
            slidersEnabled = false;

            isGameOver = true;
        }
    }

    public void ResumeGame()
    {
        // Oculta el cursor del mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Desactiva el panel de victoria
        victoryPanel.SetActive(false);

        // Reactiva el juego
        Time.timeScale = 1f;

        // Vuelve a habilitar la interacción de los Sliders
        slidersEnabled = true;
    }


    void RestartGame()
    {
        // Aquí puedes cargar la escena principal o la que desees reiniciar.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
