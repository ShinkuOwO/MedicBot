using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // ...

    // Llamado cuando se presiona el bot�n de salida
    public void SalirDelJuegoConRetraso()
    {
        // Invoca el m�todo SalirDelJuego con un retraso de 1 segundo
        Invoke("SalirDelJuego", 1.0f);
    }

    // Llamado cuando se presiona el bot�n de salida despu�s del retraso
    private void SalirDelJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // ...
}
