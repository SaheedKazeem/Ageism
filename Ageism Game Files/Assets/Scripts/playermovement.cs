using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
    {
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Rotate game object on z axis based on movement
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void FixedUpdate()
    {
        // Move game object based on input
        if (Input.GetKey(KeyCode.W))
        {
            // Calculate movement on the x-axis
            Vector2 forwardMovement = new Vector2(movement.x, 0) * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement);
        }
    }
}
