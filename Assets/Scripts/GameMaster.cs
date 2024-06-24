using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameMaster : MonoBehaviour
{   
    private GameObject gameMaster;

    public GameObject settingsPanel, backSettingsButton, backToMenuSettingsButton;
    public GameObject lvlSelectPanlel;
    public GameObject menuPanel;
    public GameObject creditPanel;
    public AudioSource click;
    public static GameMaster Instance;
    public bool Beat1 = false, Beat2 = false, Beat3 = false, Secret1 = false, Secret2 = false, Secret3 = false;
    private Vector3 SecndCamPosition = new Vector3(0.200000003f,2.19000006f,-11.3000002f);
    private Quaternion SecndCamRotation = new Quaternion(0,0,0,1);

    private void Awake()
    {
        Debug.Log(SceneManager.GetActiveScene().name);

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        if(SceneManager.GetActiveScene().name == "Intro")
            menuPanel.SetActive(true);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
            PanelTransition("esc");                
    }

    private void FixedUpdate() {
        if(!SceneManager.GetActiveScene().name.Equals("Intro"))
            return;
        
        GameObject cam = GameObject.Find("MainCamera");
        cam.transform.position = Vector3.Lerp(cam.transform.position, SecndCamPosition, 0.1f);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, SecndCamRotation, 0.1f);
    }
    
    public void PanelTransition(String panel)
    {
        switch(panel)
        {
            case "settings":
                click.Play();
                menuPanel.SetActive(false);
                settingsPanel.SetActive(true);
                SecndCamPosition = new Vector3(1.6f,6.4f,1.8f);
                SecndCamRotation = new Quaternion(0,-0.6f,0,-0.8f);
                break;

            case "lvlselect":
                click.Play();
                menuPanel.SetActive(false);
                lvlSelectPanlel.SetActive(true);
                SecndCamPosition = new Vector3(-1.4f,1.7f,4.7f);
                SecndCamRotation = new Quaternion(0,-0.9f,0,0.3f);
                break;
                
            case "credits":
                click.Play();
                menuPanel.SetActive(false);
                creditPanel.SetActive(true);
                SecndCamPosition = new Vector3(-3.1f,6.4f,-5.9f);
                SecndCamRotation = new Quaternion(0,0.4f,0,0.9f);
                break;
                
            case "back":
                click.Play();
                menuPanel.SetActive(true);
                lvlSelectPanlel.SetActive(false);
                settingsPanel.SetActive(false);
                creditPanel.SetActive(false);
                SecndCamPosition = new Vector3(0.2f,2.2f,-11.3f);
                SecndCamRotation = new Quaternion(0,0,0,1);
                break;

            case "esc":
                if(SceneManager.GetActiveScene().name != "Intro")
                {
                    if(!settingsPanel.activeSelf)
                    {
                        settingsPanel.SetActive(true);
                        backSettingsButton.SetActive(false);
                        backToMenuSettingsButton.SetActive(true);
                    }
                    else
                    {
                        settingsPanel.SetActive(false);
                    }
                }
                else
                {
                    if(!settingsPanel.activeSelf)
                    {
                        menuPanel.SetActive(false);
                        settingsPanel.SetActive(true);
                        backSettingsButton.SetActive(true);
                        backToMenuSettingsButton.SetActive(false);
                        lvlSelectPanlel.SetActive(false);
                        creditPanel.SetActive(false);
                        SecndCamPosition = new Vector3(1.6f,6.4f,1.8f);
                        SecndCamRotation = new Quaternion(0,-0.6f,0,-0.8f);
                    }                    
                    else
                    {
                        menuPanel.SetActive(true);
                        settingsPanel.SetActive(false);
                        lvlSelectPanlel.SetActive(false);
                        creditPanel.SetActive(false);
                        SecndCamPosition = new Vector3(0.2f,2.2f,-11.3f);
                        SecndCamRotation = new Quaternion(0,0,0,1);
                    }
                        
                }
                break;

        }
    }

    public void SceneTransition(String scene) 
    {
        if(scene == "Intro")
            settingsPanel.SetActive(false);

        SecndCamPosition = new Vector3(0.2f,2.2f,-11.3f);
        SecndCamRotation = new Quaternion(0,0,0,1);
        menuPanel.SetActive(false);
        lvlSelectPanlel.SetActive(false);
        SceneManager.LoadScene(scene);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));     
    }

    public void EndLvl(string s, bool secretCompletion = false)
    {
        if(s.Equals("1"))
        {   
            Secret1 = secretCompletion;
            Beat1 = true;
            SceneTransition("lvl2");
            return;
        }
        if(s.Equals("2"))
        {   
            Secret2 = secretCompletion;
            Beat2 = true;
            SceneTransition("lvl3");
            return;
        }
        if(s.Equals("3"))
        {   
            Secret3 = secretCompletion;
            Beat3 = true;
            if(Secret1 && Secret2 && Secret3)
            {
                SceneTransition("Secret");
                return;
            }
            
            SceneTransition("Intro");
            return;
        }
    }

    public void Exit()
    {
        click.Play();
        Debug.Log("Thanks for playing!!!");
        Application.Quit(0);
    }
}
