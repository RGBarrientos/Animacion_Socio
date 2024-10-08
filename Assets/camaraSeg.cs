using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraSeg : MonoBehaviour
{
    public Transform objetivo; 
    public float suavizado = 5f; 
    public float margenCentro = 0.0f; 

    private void LateUpdate()
    {
        if (objetivo != null)
        {
            Vector3 posicionDeseada = objetivo.position + new Vector3(0, 0, -10);  
            if (EstaEnCentro(objetivo.position))
            {
                transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);
            }
            //transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);
        }
    }

    private bool EstaEnCentro(Vector3 posicionObjetivo)
    {
        Vector3 centroPantalla = new Vector3(0.5f, 0.5f, 0); // Coordenadas del centro de la pantalla en Viewport Space

        // Convierte la posición del objetivo de World Space a Viewport Space
        Vector3 puntoViewport = Camera.main.WorldToViewportPoint(posicionObjetivo);

        // Compara si la posición del objetivo está dentro de un margen alrededor del centro de la pantalla
        return Mathf.Abs(puntoViewport.x - centroPantalla.x) < margenCentro &&
               Mathf.Abs(puntoViewport.y - centroPantalla.y) < margenCentro;
    }
}
