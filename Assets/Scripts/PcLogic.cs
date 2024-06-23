using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PcLogic : MonoBehaviour
{
    // General
    public Camera cam;
    
    // Player
    private NavMeshAgent _agent;
    private AudioSource _walk;
    private Animator _animator;
    private Rigidbody _rigidBody;
    public Inventory inventory;
    [SerializeField] private Inventory_UI inventory_ui;
    public Transform CammeraFollowObj;
    private bool FollowPlayer = true;
    private float health;
    public bool radiated;
    public Slider healthBar;
    private float FollowSpeed = 50f;
    
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponentInChildren<NavMeshAgent>();
        _rigidBody = GetComponentInChildren<Rigidbody>();
        _walk = GetComponent<AudioSource>();
        inventory = new Inventory();
        inventory_ui.SetInventory(inventory);
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset Camera
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(FollowPlayer)
            {
                CammeraFollowObj.position = gameObject.transform.position + new Vector3(0,15,0);
                cam.GetComponent<CameraControl>().maxDistance = 1.1f;
            }
            else
            {
                cam.GetComponent<CameraControl>().maxDistance = 30;
                cam.GetComponent<CameraControl>().SetDesiredDistance(8);
            }
            FollowPlayer = !FollowPlayer;   
        }

        if(FollowPlayer)
        {
            CammeraFollowObj.position = gameObject.transform.position;
            CammeraFollowObj.rotation = gameObject.transform.rotation;
        }
        else
        {
            if(Input.GetKey(KeyCode.W))
            {
                CammeraFollowObj.position += CammeraFollowObj.forward * Time.deltaTime * FollowSpeed;
            }
            if(Input.GetKey(KeyCode.S))
            {
                CammeraFollowObj.position -= CammeraFollowObj.forward * Time.deltaTime * FollowSpeed;   
            }
            if(Input.GetKey(KeyCode.D))
            {
                CammeraFollowObj.position += CammeraFollowObj.right * Time.deltaTime * FollowSpeed;
            }
            if(Input.GetKey(KeyCode.A))
            {
                CammeraFollowObj.position -= CammeraFollowObj.right * Time.deltaTime * FollowSpeed;
            }
            if(Input.GetKey(KeyCode.Space))
            {
                CammeraFollowObj.position += CammeraFollowObj.up * Time.deltaTime * FollowSpeed;
            }
            if(Input.GetKey(KeyCode.LeftShift))
            {
                CammeraFollowObj.position -= CammeraFollowObj.up * Time.deltaTime * FollowSpeed;
            }
            CammeraFollowObj.rotation =  Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }

        float speedP = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("speed",speedP); 

        if(radiated)
            Damage(0.05f);
        
        healthBar.value = health;
        _walk.volume = speedP;
        // Debug.Log(speedP);
    }

    public void Damage(float d)
    {
        health -= d;
        if (health < 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpeedBoost()
    {
        _agent.speed *= 2;
    }

    public void Heal()
    {
        health = 100f;
    }
}
