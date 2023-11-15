using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugosGastricos : MonoBehaviour
{
    public float velocidadAumento = 0.1f;

    private void Update()
    {
        // Mueve el objeto hacia arriba
        transform.Translate(Vector3.up * velocidadAumento * Time.deltaTime);
    }
}
