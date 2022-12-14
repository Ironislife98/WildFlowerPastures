using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<int> wheats;
    public List<int> apples;


    public void add(string name)
    {
        if (name == "wheat")
        {
            wheats.Add(1);
        }
        else if (name == "apple")
        {
            apples.Add(1);
        }
    }
    public void remove(string name) 
    { 
        
    }
}
