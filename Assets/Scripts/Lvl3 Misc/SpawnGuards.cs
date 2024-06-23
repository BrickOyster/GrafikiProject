using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGuards : MonoBehaviour
{
    public GameObject GuardTemplate;
    private float timer;
    private void Start() {
        timer = 4f;    
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            Spawn(3);
            timer = 4f;
        }
    }

    private void Spawn(int c)
    {
        for(int i = 0;i < c; ++i)
        {
            Vector3 spawnPos = GuardTemplate.transform.position + new Vector3(0,0,Random.Range(0,12f)); 
            GameObject clone = Instantiate(GuardTemplate, spawnPos, GuardTemplate.transform.rotation);
            clone.transform.parent = gameObject.transform;
            clone.SetActive(true);
        }
    }
}
