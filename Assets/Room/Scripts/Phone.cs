using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour {

    public GameObject trubka;
    public GameObject Miesto;
    public CapsuleCollider coliderTrubka;
	void Start () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("trubka"))
        {

            trubka.transform.parent = Miesto.transform;
            trubka.transform.rotation = Quaternion.Euler(-90, 0, 0);
            coliderTrubka.isTrigger = false;
        }
    }

}
