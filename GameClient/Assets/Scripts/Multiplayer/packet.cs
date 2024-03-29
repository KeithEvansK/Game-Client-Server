using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packet : MonoBehaviour {

	//This is our Client.
	public GameObject player;





	public bool pressingUp;
	public bool pressingDown;
	public bool pressingLeft;
	public bool pressingRight;
	public bool pressingSpace;




	// Make this into sendPacket() later so it is only called when needed from the ConnectionManager. 
	void Update () {

		pressingUp = player.GetComponent<playerMovement> ().pressingUp;
		pressingDown = player.GetComponent<playerMovement> ().pressingDown;
		pressingLeft = player.GetComponent<playerMovement> ().pressingLeft;
		pressingRight = player.GetComponent<playerMovement> ().pressingRight;
		pressingSpace = player.GetComponent<playerMovement> ().pressingSpace;



	}

}
