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


    [SerializeField] private string facing = "down";
    private bool idle = true;
    private bool moving = false;
    private bool tool = false;
    private float attackDelay;


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
       

        if (!tool)
        { 
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement.y == 1)
            {
                facing = "up";
            }
            else if (movement.y == -1)
            {
                facing = "down";
            }

            if (movement.x == 1)
            {
                facing = "right";
            }
            else if (movement.x == -1)
            {
                facing = "left";
            }

            if (movement != new Vector2(0, 0))
            {
                idle = false;
                moving = true;
            }
            else
            {
                idle = true;
                moving = false;
            }
            playAnimation();
        }

        if (Input.GetMouseButtonDown(0))
        {
            movement = new Vector2(0, 0);
            tool = true;
            idle = false;
            moving = false;
            //Debug.Log("click");


            playAnimation();
            handlePlanting();
            attackDelay = anim.GetCurrentAnimatorStateInfo(0).length;
            Invoke("toolComplete", attackDelay);
        }
    }

    void handlePlanting()
    {
        if (inv.selected == "shovel" && tool)
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
            gameObject.transform.position = position;
            if (GameManager.instance.tileManager.IsInteractable(position))
            {
                Debug.Log("Tile is interactable");
                GameManager.instance.tileManager.SetInteracted(position);
            }
        }
    }


    void toolComplete()
    {
        tool = false;
    }



    void playAnimation() {
        if (tool)
        {
            ChangeAnimationState($"{inv.selected}{facing}");
        }
        else if (idle)
        {
            ChangeAnimationState($"idle{facing}");
        }
        else if (moving)
        {
            ChangeAnimationState($"walk{facing}");
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