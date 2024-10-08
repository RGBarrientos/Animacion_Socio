using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirCamaraIzq : MonoBehaviour
{
    public Camera camara;
    public GameObject objetoASeguir;
    public Vector2 offset = new Vector2(-10f, -10f); // Ajusta según sea necesario

    void LateUpdate()
    {
        if (camara != null && objetoASeguir != null)
        {
            // Obtiene las dimensiones de la pantalla
            float screenHeight = Screen.height;
            float screenWidth = Screen.width;

            // Calcula la posición del objeto en la esquina inferior derecha
            float posX = offset.x + 80;
            float posY = offset.y + 10;

            // Convierte las coordenadas de la pantalla a coordenadas de mundo
            Vector3 posicionMundo = camara.ScreenToWorldPoint(new Vector3(posX, posY, camara.nearClipPlane));

            // Establece la posición del objeto
            objetoASeguir.transform.position = posicionMundo;
        }
    }
}
