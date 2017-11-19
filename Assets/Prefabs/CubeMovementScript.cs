using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CubeMovementScript : NetworkBehaviour {

	public GameObject Parent = null;
	[SerializeField]
	private float Speed = 8;
	private Rigidbody Rigidbody;
	void Start()
	{
		Rigidbody = transform.GetComponent<Rigidbody>();
	}
	void Update () {
		if (Parent != null && isServer)
		{
			float dist = Vector3.Distance(Parent.transform.position, transform.position);
			Vector3 vect = (Parent.transform.position - transform.position).normalized;
			
			Vector3 speed = vect * Speed * dist;
			Rigidbody.velocity = speed;
		}
	}

	public void Throw()
	{
		Parent = null;
		Rigidbody.velocity *= 3;
	}
}
