using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_secret : MonoBehaviour
{
    public GameObject exit;
    public GameObject dm;

    private void Start() {
        dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[1]);
    }
    private void OnTriggerEnter(Collider other)
    {
        dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[0]);
        gameObject.GetComponent<AudioSource>().Play();
        exit.GetComponent<lvl2_exit>().GotSecret = true;
        GetComponentInChildren<Collider>().enabled = false;
    }
}
