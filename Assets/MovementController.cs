using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f; // movement speed of the player

    private Vector2 movement; // variable to store the player's movement input

    private Rigidbody2D rb; // reference to the player's Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the player's Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        // get the player's horizontal and vertical input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate is called at a fixed interval (used for physics updates)
    void FixedUpdate()
    {
        // move the player by applying a force to the player's Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}