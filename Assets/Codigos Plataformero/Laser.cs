using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer lineRenderer; // Componente LineRenderer para dibujar el láser
    public float laserMaxLength = 10f; // Longitud máxima del láser
    public LayerMask laserCollisionMask; // Capa de colisión del láser

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
        // Obtiene la dirección en la que apunta la punta del brazo
        Vector3 laserDirection = transform.right;

        // Establece la posición de la punta del brazo como el punto de inicio del láser
        Vector3 laserStartPosition = transform.position;

        // Lanza un rayo desde la punta del brazo en la dirección del láser
        RaycastHit2D hit = Physics2D.Raycast(laserStartPosition, laserDirection, laserMaxLength, laserCollisionMask);

        // Calcula la posición final del láser
        Vector3 laserEndPosition;

        if (hit.collider != null)
        {
            // Si el rayo golpea un objeto, el final del láser es el punto de impacto
            laserEndPosition = hit.point;
        }
        else
        {
            // Si el rayo no golpea nada, el final del láser es la dirección máxima
            laserEndPosition = laserStartPosition + laserDirection * laserMaxLength;
        }

        // Actualiza las posiciones del LineRenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserEndPosition);

        // Oculta el cursor si no está oculto
        if (!isCursorHidden)
        {
            Cursor.visible = false;
            isCursorHidden = true;
        }
    }
}
