using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    private List<Item> itemlist;

    public Inventory()
    {
        itemlist = new List<Item>();
    }

    public void AddItem(Item item)
    {
        itemlist.Add(item);
        GameObject.Find("Inventory_UI").GetComponent<Inventory_UI>().RefreshInventoryItems();
    }

    public void RemoveItem(Item.ItemType type)
    {
        for (int i = 0; i < itemlist.Count; i++)
            if (itemlist[i].itemType == type)
                itemlist.RemoveAt(i);
        
        GameObject.Find("Inventory_UI").GetComponent<Inventory_UI>().RefreshInventoryItems();
    }

    public List<Item> GetItemList()
    {
        return itemlist;
    }

    public bool hasItem(Item.ItemType type)
    {
        foreach(Item i in itemlist)
        {
            if(i.itemType == type)
                return true;
        }
        return false;   
    }
}
