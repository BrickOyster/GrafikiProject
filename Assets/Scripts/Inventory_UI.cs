using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemContainer;
    private Transform itemTemplate;
    private List<GameObject> inventory_ui_list;
    private void Awake() {
        itemContainer = transform.Find("ItemContainer");  
        itemTemplate = itemContainer.Find("ItemTemplate");
        inventory_ui_list = new List<GameObject>();
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }
    public void RefreshInventoryItems()
    {
        foreach (GameObject obj in inventory_ui_list.ToList())
        {
            Destroy(obj);
            inventory_ui_list.Remove(obj);
        }

        // inventory_ui_list = new List<GameObject>();

        int x = 0;
        float itemSize = 133f;
        foreach (Item i in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemTemplate, itemContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.gameObject.name = i.itemType.ToString();
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSize, 0);
            UnityEngine.UI.Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<UnityEngine.UI.Image>();
            image.sprite = i.GetSprite();
            inventory_ui_list.Add(itemSlotRectTransform.gameObject);
            x++;
        }
    }
}
