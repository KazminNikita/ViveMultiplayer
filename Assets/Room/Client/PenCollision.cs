using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenCollision : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        string collisionName = collision.gameObject.name;

        if(collisionName == "Ligh")
        {
            RoomManagerLocal.instance.LightOnOff();
        }
        if (collisionName == "Lamp")
        {
            RoomManagerLocal.instance.LampLight();
        }
        if (collisionName == "PhoneCall")
        {

        }
        if(collisionName == "OnMagnitola")
        {
            RoomManagerLocal.instance.Magnitola(false);
        }
        if(collisionName == "OffMagnitola")
        {
            RoomManagerLocal.instance.Magnitola(true);
        }
     
    }


}
