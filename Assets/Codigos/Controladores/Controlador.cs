using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public int enemiesToKill = 10;
    private int enemiesRemaining;
    public GameObject victoryPanel;
    public TextMeshProUGUI victoryText;
    public TextMeshProUGUI additionalText;
    public TextMeshProUGUI heroText;
    public TextMeshProUGUI enemiesRemainingText;

    private bool isGameOver = false;

    private void Start()
    {
        // Activa el TextMeshPro de enemigos restantes al inicio del juego
        enemiesRemainingText.gameObject.SetActive(true);

        // Desactiva el panel, el TextMeshPro adicional, el nuevo mensaje al inicio del juego
        victoryPanel.SetActive(false);
        additionalText.gameObject.SetActive(false);
        heroText.gameObject.SetActive(false);

        // Inicializa la cantidad restante de enemigos al comienzo del juego
        enemiesRemaining = enemiesToKill;

        // Actualiza el TextMeshPro de enemigos restantes
        UpdateEnemiesRemainingText();
    }

    private void UpdateEnemiesRemainingText()
    {
        // Actualiza el TextMeshPro de enemigos restantes
        enemiesRemainingText.text = "" + enemiesRemaining;
    }

    public void EnemyKilled()
    {
        enemiesRemaining--;

        // Actualiza el TextMeshPro de enemigos restantes
        UpdateEnemiesRemainingText();

        if (enemiesRemaining <= 0)
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
            heroText.text = "Cubrete la boca y la nariz al toser o estornudar. Cuando tosas o estornudes, cubrete la boca y la nariz con un pañuelo de papel. Si no tienes un pañuelo, cubrete la boca y la nariz con el antebrazo. Esto ayudará a prevenir que los gérmenes se propaguen a los demás.";

            isGameOver = true;
        }
    }

    void RestartGame()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
