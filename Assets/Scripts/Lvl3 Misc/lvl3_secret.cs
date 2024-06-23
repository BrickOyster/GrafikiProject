using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_secret : MonoBehaviour
{
    public GameObject exit;
    public GameObject dm;

    private void Start() {
        dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[1]);
    }
    private void OnTriggerEnter(Collider other)
    {
        dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[0]);
        exit.GetComponent<lvl3_exit>().GotSecret = true;
        GetComponentInChildren<Collider>().enabled = false;
    }
}
