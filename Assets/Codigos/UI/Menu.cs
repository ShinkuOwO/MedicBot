using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string gameSceneName;

    private Button playButton;
    private Button quitButton;

    private void Start()
    {
        // Encuentra los botones por sus nombres
        playButton = GameObject.Find("Jugar").GetComponent<Button>();
        quitButton = GameObject.Find("Salir").GetComponent<Button>();

        // Asocia los métodos a los eventos de clic
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit(); // Esto solo funciona en la versión compilada del juego
    }
}
