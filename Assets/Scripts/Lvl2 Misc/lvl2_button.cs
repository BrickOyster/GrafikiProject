using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_button : MonoBehaviour
{
    public lvl2_exit exit;
    public Item.ItemType color;
    public bool done = false;
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {   
            PcLogic pc = other.GetComponentInChildren<PcLogic>();
            if(pc.inventory.hasItem(color))
            {
                gameObject.GetComponent<AudioSource>().Play();

                gameObject.GetComponentInChildren<Collider>().enabled = false;
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                pc.inventory.RemoveItem(color);
                done = true;

                if(color == Item.ItemType.BlueBlock) 
                {
                    exit.GetComponent<lvl2_exit>().button_ready[0] = true;
                } 
                else if(color == Item.ItemType.YellowBlock) 
                {
                    exit.GetComponent<lvl2_exit>().button_ready[1] = true;
                } 
                else if(color == Item.ItemType.RedBlock) 
                {
                    exit.GetComponent<lvl2_exit>().button_ready[2] = true;
                }
            }
            else
            {
                pc.Damage(10f);
            }
        }    
    }
}
