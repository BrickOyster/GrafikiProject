using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_cube : MonoBehaviour
{
    public Item.ItemType type;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            other.GetComponentInChildren<PcLogic>().inventory.AddItem(new Item { itemType = type });
            Destroy(gameObject,0.1f);
        }
    }
}
