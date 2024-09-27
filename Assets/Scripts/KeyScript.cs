using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class KeyScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision other) {
        
        if (other.collider.tag == "Player"){
            GameObject.Find("DoorExit").GetComponent<ExitDoor>().foundKeys++;
            Destroy(gameObject);
        }
    }
}
