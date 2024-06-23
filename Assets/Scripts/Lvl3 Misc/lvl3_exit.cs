using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class lvl3_exit : MonoBehaviour
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
        {
            GameObject.Find("GameMaster").GetComponent<GameMaster>().PanelTransition("back");
            GameObject.Find("GameMaster").GetComponent<GameMaster>().EndLvl("3", GotSecret);          
        }
            
              
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            dm.GetComponentInChildren<DialogueManager>().StartDialogue(gameObject.GetComponents<Dialogue>()[0]);
            activateTimer = true;
        }
        
    }

}
