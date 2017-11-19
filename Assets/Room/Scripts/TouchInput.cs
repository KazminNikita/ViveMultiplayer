using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {
    public RoomManagerLocal instRoom;
    private void Start()
    {
        instRoom.GetComponent<RoomManagerLocal>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cup"))
        {
            instRoom.OpenSafe();
        }

    }
}
