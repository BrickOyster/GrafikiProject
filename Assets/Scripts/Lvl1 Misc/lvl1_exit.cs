using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class lvl1_exit : MonoBehaviour
{
    private Animator _animator;
    public GameObject dm;
    private float timer = 5;
    private bool activateTimer = false;
    public bool GotSecret = false;
    void Start ()
	{
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (activateTimer)
            timer -= Time.deltaTime;
        if (timer < 0)
            GameObject.Find("GameMaster").GetComponent<GameMaster>().EndLvl("1", GotSecret);            
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponentInChildren<PcLogic>().inventory.hasItem(Item.ItemType.Disguise))
            {
                dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[1]);
                _animator.SetBool("Open", true);
                gameObject.GetComponent<AudioSource>().Play();
                activateTimer = true;
            }
            else
            {
                dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[0]);
            }
        }
        
    }

}
