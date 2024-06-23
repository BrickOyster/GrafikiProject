using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class lvl2_exit : MonoBehaviour
{
    private Animator _animator;
    public GameObject dm;
    private float timer = 5;
    private bool activateTimer = false;    
    public bool GotSecret = false;
    public bool[] button_ready = {false, false, false};
    void Start ()
	{
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (activateTimer)
            timer -= Time.deltaTime;
        if (timer < 0)
            GameObject.Find("GameMaster").GetComponent<GameMaster>().EndLvl("2", GotSecret);            
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            foreach (bool i in button_ready) {
                if (!i)
                { 
                    return;
                }
            }
            _animator.SetBool("Open", true);
            gameObject.GetComponent<AudioSource>().Play();
            activateTimer = true;
        }
        
    }

}
