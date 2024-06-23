using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Debug.Log("HEAL");
            other.gameObject.GetComponent<PcLogic>().Heal();
            Destroy(gameObject);
        }
    }
}
