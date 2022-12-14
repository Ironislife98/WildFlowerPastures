using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<int> wheats;
    public List<int> apples;


    public TextMeshProUGUI applesText;
    private void Update()
    {
        
    }
    public void add(string name)
    {
        if (name == "wheat")
        {
            wheats.Add(1);
        }
        else if (name == "apple")
        {
            apples.Add(1);
            applesText.text = $"{apples.Length}";
        }
    }
    public void remove(string name) 
    { 
        
    }
}
