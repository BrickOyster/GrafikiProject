using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Debug.Log("SPEEED");
            other.gameObject.GetComponent<PcLogic>().SpeedBoost();
            Destroy(gameObject);
        }
    }
}
