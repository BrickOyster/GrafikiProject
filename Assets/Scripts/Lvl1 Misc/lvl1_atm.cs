using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_atm : MonoBehaviour
{
    public GameObject exit;
    public GameObject dm;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInChildren<PcLogic>().inventory.AddItem(new Item { itemType = Item.ItemType.Money });
        dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[0]);
        gameObject.GetComponent<AudioSource>().Play();
        GetComponentInChildren<Collider>().enabled = false;
    }
}
