using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer lineRenderer; // Componente LineRenderer para dibujar el l�ser
    public float laserMaxLength = 10f; // Longitud m�xima del l�ser
    public LayerMask laserCollisionMask; // Capa de colisi�n del l�ser

    private bool isCursorHidden = false;

    void Awake()
    {
        // Oculta el cursor tan pronto como se inicie la escena
        Cursor.visible = false;
        isCursorHidden = true;
        lineRenderer.sortingOrder = 1;
    }

    void OnDestroy()
    {

        // Restaura la visibilidad del cursor cuando el juego termine
        Cursor.visible = true;
    }

    void Update()
    {
        // Obtiene la direcci�n en la que apunta la punta del brazo
        Vector3 laserDirection = transform.right;

        // Establece la posici�n de la punta del brazo como el punto de inicio del l�ser
        Vector3 laserStartPosition = transform.position;

        // Lanza un rayo desde la punta del brazo en la direcci�n del l�ser
        RaycastHit2D hit = Physics2D.Raycast(laserStartPosition, laserDirection, laserMaxLength, laserCollisionMask);

        // Calcula la posici�n final del l�ser
        Vector3 laserEndPosition;

        if (hit.collider != null)
        {
            // Si el rayo golpea un objeto, el final del l�ser es el punto de impacto
            laserEndPosition = hit.point;
        }
        else
        {
            // Si el rayo no golpea nada, el final del l�ser es la direcci�n m�xima
            laserEndPosition = laserStartPosition + laserDirection * laserMaxLength;
        }

        // Actualiza las posiciones del LineRenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserEndPosition);

        // Oculta el cursor si no est� oculto
        if (!isCursorHidden)
        {
            Cursor.visible = false;
            isCursorHidden = true;
        }
    }
}
