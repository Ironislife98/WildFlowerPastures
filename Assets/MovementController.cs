using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f; // movement speed of the player

    public Vector2 movement; // variable to store the player's movement input

    private Rigidbody2D rb; // reference to the player's Rigidbody2D component

    private Animator anim;
    private string currentState;


    [SerializeField] private string facing;
    private bool idle = true;
    private bool moving = false;
    private bool tool = false;

    [SerializeField] private InventoryController inv;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the player's Rigidbody2D component
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the player's horizontal and vertical input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!tool)
        {
            if (movement.y == 1)
            {
                facing = "up";
            }
            else if (movement.y == -1)
            {
                facing = "down";
            }
            else
            {
                idle = true;
            }

            if (movement.x == 1)
            {
                facing = "right";
            }
            else if (movement.x == -1)
            {
                facing = "left";
            }
            else
            {
                idle = true;
            }

            if (movement != new Vector2(0, 0))
            {
                idle = false;
                moving = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            tool = true;
            idle = false;
            moving = false;
            Debug.Log("click");
        }
        else
        {
            tool = false;
        }

        playAnimation();
    }

    void playAnimation()
    {
        if (idle)
        {
            ChangeAnimationState($"idle{facing}");
        }
        else if (moving)
        {
            ChangeAnimationState($"walk{facing}");
        }
        else if (tool)
        {
            ChangeAnimationState($"{inv.selected}{facing}");
        }
    }
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);
        currentState = newState;
    }


    // FixedUpdate is called at a fixed interval (used for physics updates)
    void FixedUpdate()
    {
        // move the player by applying a force to the player's Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}