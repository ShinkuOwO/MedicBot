using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puerta : MonoBehaviour
{
    public Image imagenAColocar;
    public GameObject llave; // Asigna el objeto llave desde el inspector de Unity

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cambia "NombreDelObjetoColisionador" al nombre del objeto con el que colisionas
        if (other.gameObject.name == "Personaje")
        {
            MostrarImagen();
        }
        else if (other.gameObject == llave) // Utiliza el objeto llave asignado desde el inspector
        {
            OcultarImagen();
        }
    }

    private void MostrarImagen()
    {
        // Asegúrate de que la imagen esté configurada en el Canvas y activa el objeto
        imagenAColocar.gameObject.SetActive(true);
    }

    private void OcultarImagen()
    {
        // Desactiva la imagen
        imagenAColocar.gameObject.SetActive(false);
    }
}
