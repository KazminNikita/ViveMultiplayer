using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDoor : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Stakan"))
        {
            RoomManagerLocal.instance.OpenSafe();
        }
        else if(other.name == "RH" || other.name == "LH")
        {
            RoomManagerLocal.instance.DenideSafe();
        }
    }
}
