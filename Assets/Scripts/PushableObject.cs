using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
     private Rigidbody2D rb;
    public float massReductionFactor = 0.5f;  // Factor de reducción de masa (50%)
    private float originalMass;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalMass = rb.mass;  // Guarda la masa original al inicio
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el jugador está colisionando y si presiona 'E'
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            rb.mass = originalMass * massReductionFactor;  // Aplica la masa reducida
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Cuando el jugador deja de colisionar, restaura la masa original
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.mass = originalMass;
        }
    }

    void Update()
    {
        // Si el jugador mantiene presionada 'E' y está en colisión, reduce la masa
        if (Input.GetKey(KeyCode.E) && rb.mass != originalMass * massReductionFactor)
        {
            rb.mass = originalMass * massReductionFactor;
        }
        else if (!Input.GetKey(KeyCode.E) && rb.mass != originalMass)
        {
            // Si se suelta 'E', restaura la masa
            rb.mass = originalMass;
        }
    }
}
