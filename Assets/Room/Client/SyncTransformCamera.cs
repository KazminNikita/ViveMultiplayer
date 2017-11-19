using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncTransformCamera : MonoBehaviour {

	public GameObject rig;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = rig.transform.position;
		this.gameObject.transform.rotation = rig.transform.rotation;
	}
}
