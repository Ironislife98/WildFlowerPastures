using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Dictionary<string, string> inventory = new Dictionary<string, string>();
    void Start()
    {
        inventory.Add("txt", "winword.exe");
    }
    //public void AddItem(GameObject obj)
    //{
        
    //}
}
