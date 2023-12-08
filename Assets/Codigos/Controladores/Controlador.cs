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
    public TextMeshProUGUI heroText;
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
            SceneManager.LoadScene("Calculos");
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            RestartGame();
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (enemiesKilled >= enemiesToKill)
        {
            // Muestra el panel de victoria
            victoryPanel.SetActive(true);

            // Cambia el texto del panel
            victoryText.text = "!Has vencido al virus Bronquitis!";

            // Activa el TextMeshPro adicional con el mensaje "Presiona Enter para pasar al siguiente nivel"
            additionalText.gameObject.SetActive(true);
            additionalText.text = "Presiona ENTER para pasar al siguiente nivel";

            // Activa el nuevo TextMeshPro con el mensaje "Eres un héroe"
            heroText.gameObject.SetActive(true);
            heroText.text = "Cubrete la boca y la nariz al toser o estornudar. Cuando tosas o estornudes, cubrete la boca y la nariz con un panuelo de papel. Si no tienes un panuelo, cubrete la boca y la nariz con el antebrazo. Esto ayudara a prevenir que los germenes se propaguen a los demas.";

            isGameOver = true;
        }
    }

    void RestartGame()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
