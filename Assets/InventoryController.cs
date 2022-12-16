using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public int wheats;
    public int apples;


    public string selected = "shovel";

    public TextMeshProUGUI applesText;
    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Debug.Log("drop");
        }   
    }
    public void add(string name)
    {
        if (name == "wheat")
        {
            wheats += 1;
        }
        else if (name == "apple")
        {
            apples += 1;
            applesText.text = $"{apples}x";
        }
    }
    public void remove(string name) 
    { 
        
    }
}
