using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VRPlayerController : NetworkBehaviour {
	[SerializeField]
	GameObject myCamera, myLeftContr, myRightContr, playerHead, playerLeftContr, playerRightContr, visor;
	[SerializeField]
	GameObject[] ObjectsDoDeactivate;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private SteamVR_Controller.Device controller 
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index);}
	}
	private SteamVR_TrackedObject trackedObj;
	private RaycastHit hit;
	private CubeMovementScript Cube;
	void Start () {
		if (isLocalPlayer)
		{
			playerHead.GetComponent<MeshRenderer>().enabled = false;
			playerLeftContr.GetComponent<MeshRenderer>().enabled = false;
			playerRightContr.GetComponent<MeshRenderer>().enabled = false;
			visor.GetComponent<MeshRenderer>().enabled = false;
			trackedObj = myRightContr.GetComponent<SteamVR_TrackedObject>();
		}
		if (isServer && isLocalPlayer)
		{
			//GameObject.Destroy(this.gameObject);
		}
		if (!isLocalPlayer)
		{
			foreach (var obj in ObjectsDoDeactivate)
			{
				obj.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
		{
			return;
		}
		playerHead.transform.SetPositionAndRotation(myCamera.transform.position, myCamera.transform.rotation);
		playerLeftContr.transform.SetPositionAndRotation(myLeftContr.transform.position, myLeftContr.transform.rotation);
		playerRightContr.transform.SetPositionAndRotation(myRightContr.transform.position, myRightContr.transform.rotation);
		if (controller.GetHairTrigger())
		{
			if (Cube == null && Physics.Raycast (myRightContr.transform.position, myRightContr.transform.forward, out hit, 30, ~(1 << 8))) 
			{
				if (hit.collider.tag == "Cube") 
				{
					CmdClick();
					Cube = hit.collider.GetComponent<CubeMovementScript>();
				}
			}
		}
		else 
		{
			if (Cube != null)
			{
				CmdUnClick ();
				Cube = null;
			}
			
		}
		Debug.DrawLine (playerRightContr.transform.position, playerRightContr.transform.forward * 30, Color.red);
	}

	[Command]
	void CmdClick()
	{
		if (Cube == null)
			{
				if (Physics.Raycast (playerRightContr.transform.position, playerRightContr.transform.forward, out hit, 30, ~(1 << 8))) 
				{
					if (hit.collider.tag == "Cube") 
					{
						Cube = hit.collider.GetComponent<CubeMovementScript>();
						Cube.Parent = playerRightContr.transform.GetChild (0).gameObject;
					}
				}
			}
	}

	[Command]
	void CmdUnClick()
	{
		if (Cube == null)
			return;
		Cube.Throw ();
		Cube = null;
	}

	public override void OnStartLocalPlayer()
	{
		//if (!isServer)
		{
			var mainCamera = GameObject.Find("MainCamera");
			if (mainCamera != null)
			{
				mainCamera.GetComponent<Camera>().enabled = false;
				mainCamera.GetComponent<AudioListener>().enabled = false;
			}
			myCamera.GetComponent<Camera>().enabled = true;
		}
	}
}
