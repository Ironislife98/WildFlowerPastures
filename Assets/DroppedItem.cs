using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryController inv = collision.gameObject.GetComponent<InventoryController>();
            inv.add(itemName);
            Destroy(gameObject);
        }
    }
}
