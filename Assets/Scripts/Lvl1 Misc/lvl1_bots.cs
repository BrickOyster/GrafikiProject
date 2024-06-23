using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lvl1_bots : MonoBehaviour
{
    public GameObject dm;

    private void OnTriggerEnter(Collider other)
    {
        dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[0]);
        GetComponentInChildren<Collider>().enabled = false;
    }
}
