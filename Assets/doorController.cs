using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    [SerializeField] private string type;
    [SerializeField] private BoxCollider2D physicalCollider;
    private Animator anim;
    private bool entered = false;
    private string state = "closed";


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (entered && Input.GetKeyDown(KeyCode.E))
        {
            if (state == "closed")
            {
                anim.SetTrigger("open");
                state = "open";
            }
            else
            {
                anim.SetTrigger("close");
                state = "closed";
            }
            // Invert collider to stop from going straight through door
            physicalCollider.enabled = !physicalCollider.enabled;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        entered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        entered = false;
    }


    /* 
     On collision enter wait for e to be pressed
    if e pressed
        check state
        toggle state

   */
}
