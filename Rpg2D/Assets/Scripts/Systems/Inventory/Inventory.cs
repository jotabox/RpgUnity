using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item> ();

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log("item adicionado" + item.itemName);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        Debug.Log("item removido" + item.itemName);
    }


}
