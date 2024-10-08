using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    [SerializeField] private float velocidadDeMovimiento;

    private Animator animator;
    private float distanciaMaximaAbajo1 = 17f;
    private float distanciaMaximaAbajo2 = 17f;
    private float distanciaMaximaAbajo3 = 49f;
    private float distanciaMaximaDerecha = 32f;
    private float distanciaMaximaDerecha2 = 14f;
    private float distanciaRecorridaAbajo = 0f;
    private float distanciaRecorridaDerecha = 0f;
    private bool moviendoAbajo = true;
    private bool moviendoDerecha = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(MovimientoSocio());
    }

    private IEnumerator MovimientoSocio()
    {
        while (true)
        {
            // Movimiento
            if (moviendoAbajo)
            {
                MoverAbajo();
                if (distanciaRecorridaAbajo >= distanciaMaximaAbajo1)
                {
                    moviendoAbajo = false;
                    distanciaRecorridaAbajo = 0f;
                    animator.SetFloat("Frente", 0f);
                }
            }
            else
            {
                if (moviendoDerecha)
                {
                    MoverDerecha(velocidadDeMovimiento);
                    if (distanciaRecorridaDerecha >= distanciaMaximaDerecha)
                    {
                        moviendoDerecha = false;
                        distanciaRecorridaDerecha = 0f;
                        animator.SetFloat("Derecha", 0f);
                    }
                }
                else
                {
                    MoverAbajo();
                    if (distanciaRecorridaAbajo >= distanciaMaximaAbajo2)
                    {
                        MoverAbajo(velocidadDeMovimiento * 2);
                        if (distanciaRecorridaAbajo >= distanciaMaximaAbajo3)
                        {
                            MoverDerecha();
                            if (distanciaRecorridaDerecha >= distanciaMaximaDerecha2)
                            {
                                rb2D.velocity = Vector2.zero;
                                animator.SetFloat("Frente", 0f);
                                animator.SetFloat("Derecha", 0f);
                            }
                        }
                    }
                }
            }

            yield return null;
        }
    }

    private void MoverAbajo()
    {
        Vector2 velocidadY = new Vector2(0, -velocidadDeMovimiento);
        rb2D.velocity = velocidadY;
        animator.SetFloat("Frente", Mathf.Abs(velocidadDeMovimiento));
        distanciaRecorridaAbajo += Mathf.Abs(rb2D.velocity.y) * Time.deltaTime;
    }

    private void MoverAbajo(float velocidadDeMovimiento)
    {
        Vector2 velocidadY = new Vector2(0, -velocidadDeMovimiento);
        rb2D.velocity = velocidadY;
        animator.SetFloat("Frente", Mathf.Abs(velocidadDeMovimiento));
        distanciaRecorridaAbajo += Mathf.Abs(rb2D.velocity.y) * Time.deltaTime;
    }

    private void MoverDerecha(float velocidadDeMovimiento)
    {
        Vector2 velocidadX = new Vector2(velocidadDeMovimiento, 0);
        rb2D.velocity = velocidadX;
        animator.SetFloat("Derecha", Mathf.Abs(velocidadDeMovimiento));
        distanciaRecorridaDerecha += Mathf.Abs(rb2D.velocity.x) * Time.deltaTime;
    }

    private void MoverDerecha()
    {
        Vector2 velocidadX = new Vector2(velocidadDeMovimiento, 0);
        rb2D.velocity = velocidadX;
        animator.SetFloat("Derecha", Mathf.Abs(velocidadDeMovimiento));
        distanciaRecorridaDerecha += Mathf.Abs(rb2D.velocity.x) * Time.deltaTime;
    }
}
