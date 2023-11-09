using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 anteriorPosicionCamara;
    [Range(-5f, 5f)] public float velocidadParalax;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        anteriorPosicionCamara = cameraTransform.position;
    }
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - anteriorPosicionCamara.x) *velocidadParalax;
        transform.Translate(new Vector3(deltaX, 0, 0));
        anteriorPosicionCamara = cameraTransform.position;
    }
}
