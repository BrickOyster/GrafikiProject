using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_shop : MonoBehaviour
{
    public GameObject dm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponentInChildren<PcLogic>().inventory.hasItem(Item.ItemType.Money))
            {
                dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[1]);
                other.GetComponentInChildren<PcLogic>().inventory.AddItem(new Item { itemType = Item.ItemType.Disguise});
                gameObject.GetComponent<AudioSource>().Play();
                GetComponentInChildren<Collider>().enabled = false;
            }
            else
            {
                dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[0]);
            }
        }
        
    }
}
