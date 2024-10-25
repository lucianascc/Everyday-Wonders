using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private int jumpCount = 0; // Contador de saltos
    public int maxJumps = 2; // Número máximo de saltos permitidos
    private bool isGrounded = false; // Indica si el personaje está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Reinicia la velocidad en y antes del salto
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            isGrounded = false; // Desactiva el estado de suelo al saltar
        } 
    }

    // Detecta colisión con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reinicia el contador de saltos al tocar el suelo
        }
    }
}
