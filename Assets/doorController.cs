using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    [SerializeField] private string type;
    [SerializeField] private BoxCollider2D ownCollider;
    private Animator anim;
    public int count = 0;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Hello1");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Hello");
            if (count % 2 == 0 && count != 0)
            {
                anim.SetTrigger("open");
            }
            else if (count != 0)
            {
                anim.SetTrigger("close");
            }
        }
    }
}
