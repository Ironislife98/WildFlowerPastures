using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private string selected = "None";
    [SerializeField] private BoxCollider2D ownCollider;
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private List<GameObject> slots = new List<GameObject>(); // Max of 8 slots free
    [SerializeField] private List<GameObject> correspondingSlots = new List<GameObject> ();
    [SerializeField] private Sprite selectedSprite;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private List<TextMeshProUGUI> counts = new List<TextMeshProUGUI> ();
    [SerializeField] private List<Item> allItems = new List<Item>();



    private List<string> ids = new List<string>() {"Axe", "Shovel", "Apple"};
    public static bool running = false;


    public void changeSelected(GameObject requestingObject)
    {
        
        if (selected != requestingObject.name)
        {   
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].GetComponent<Slot>().correspondingSlot.GetComponent<Image>().sprite = defaultSprite;
            }
            requestingObject.GetComponent<Slot>().correspondingSlot.GetComponent<Image>().sprite = selectedSprite;
            selected = requestingObject.name;
        }
        else 
        {
            requestingObject.GetComponent<Slot>().correspondingSlot.GetComponent<Image>().sprite = defaultSprite;
            selected = "None";
        }
    }

    public string getSelected()
    {
        return selected;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Add(other.gameObject.GetComponent<ItemDisplay>().item);
            Destroy(other.gameObject);
        }
    }

    private void Add(Item item)
    {
        /* items.Add(item);
        for (int i = 0; i < slots.Count - 2; i++)
        {
            Debug.Log($"{slots[i + 2].GetComponent<Slot>().itemName}, {item.id}");
            if (slots[i + 2].GetComponent<Slot>().itemName == item.id.ToString())
            {
                item.count += 1;
                counts[i].text = item.count.ToString();
                break;
            }
            if (slots[i + 2].GetComponent<Slot>().itemName == "None")
            { 
                slots[i + 2].GetComponent<Image>().sprite = item.image;
                slots[i + 2].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                slots[i + 2].GetComponent<Slot>().itemName = $"{item.id}";
                slots[i +2].gameObject.name = ids[item.id - 1];


                // Make Small Adjustments
                if (item.id == 3)
                {
                   RectTransform rectTransform = slots[i + 2].GetComponent<RectTransform>();
                   rectTransform.sizeDelta = new Vector2(24, 26);
                    rectTransform.anchoredPosition += new Vector2(5, 0);
                }


                break;
            }
        } */
        for (int i = 0; i < slots.Count; i++)
        {
            GameObject current = slots[i];
            if (current.GetComponent<Slot>().itemName == ids[item.id - 1])
            {
                // Increment items count
                item.count += 1;
                // Change count on text
                counts[i - 1].GetComponent<TextMeshProUGUI>().text = item.count.ToString();
                // No Need to add item to items list
                return;
            }
            else if (current.GetComponent<Slot>().itemName == "None")
            {
                current.GetComponent<Image>().sprite = item.image;
                current.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                current.GetComponent<Slot>().itemName = ids[item.id - 1];
                current.gameObject.name = ids[item.id - 1];

                Debug.Log(item.id);

                if (item.id == 3)
                {
                    RectTransform rectTransform = current.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = new Vector2(24, 26);
                    rectTransform.anchoredPosition += new Vector2(5, 0);
                }


                items.Add(item);
                return;
            }
        }
    }

    private void Remove(Item item)
    {
        items.Remove(item);
    }

    private void Start()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            allItems[i].count = 1;
        }
        for (int i = 0; i < counts.Count; i++)
        {
            counts[i].GetComponent<TextMeshProUGUI>().text = "";
        }
    }

}
