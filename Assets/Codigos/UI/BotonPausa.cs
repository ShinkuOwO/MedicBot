using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotonPausa : MonoBehaviour
{
    public Button boton; // Arrastra el bot�n en el Inspector
    public GameObject panelConfirmacion; // Arrastra un panel de confirmaci�n en el Inspector
    public TextMeshProUGUI textoConfirmacion; // Arrastra un TextMeshProUGUI en el Inspector
    public Button botonConfirmar; // Arrastra un bot�n de confirmar en el Inspector
    public Button botonCancelar; // Arrastra un bot�n de cancelar en el Inspector

    private bool enDialogo = false;

    private void Start()
    {
        panelConfirmacion.SetActive(false); // Desactiva el panel de confirmaci�n al inicio
        textoConfirmacion.gameObject.SetActive(false); // Desactiva el texto de confirmaci�n al inicio

        boton.onClick.AddListener(ToggleDialogo);
        botonConfirmar.onClick.AddListener(SalirJuego);
        botonCancelar.onClick.AddListener(OcultarDialogo);
        textoConfirmacion.text = "Deseas salir del juego?";
    }

    private void Update()
    {
        if (enDialogo && Input.GetKeyDown(KeyCode.Escape))
        {
            OcultarDialogo();
        }
    }

    private void ToggleDialogo()
    {
        enDialogo = !enDialogo;

        if (enDialogo)
        {
            panelConfirmacion.SetActive(true); // Activa el panel de confirmaci�n
            
            textoConfirmacion.gameObject.SetActive(true); // Muestra el texto de confirmaci�n
            Time.timeScale = 0; // Pausa el juego
        }
        else
        {
            panelConfirmacion.SetActive(false); // Oculta el panel de confirmaci�n
         
            textoConfirmacion.gameObject.SetActive(false); // Oculta el texto de confirmaci�n
            Time.timeScale = 1; // Reanuda el juego
        }
    }

    private void SalirJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Cierra la aplicaci�n en la compilaci�n final
#endif
    }

    private void OcultarDialogo()
    {
        enDialogo = false;
        panelConfirmacion.SetActive(false); // Oculta el panel de confirmaci�n
        textoConfirmacion.gameObject.SetActive(false); // Oculta el texto de confirmaci�n
        Time.timeScale = 1; // Reanuda el juego
    }
}
