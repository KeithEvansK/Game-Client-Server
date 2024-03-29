using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour {

    public GameObject player;

	public bool pressingUp;
	public bool pressingDown;
	public bool pressingLeft;
	public bool pressingRight;
	public bool pressingSpace;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //Button input
		if (Input.GetKey(KeyCode.UpArrow)) { //Up Arrow

			pressingUp = true;
		} else {

			pressingUp = false;
		}

		if (Input.GetKey(KeyCode.DownArrow)) { //Down Arrow

			pressingDown = true;
		} else {

			pressingDown = false;
		}

		if (Input.GetKey(KeyCode.LeftArrow)) { //Left Arrow

			pressingLeft = true;
		} else {

			pressingLeft = false;
		}

		if (Input.GetKey(KeyCode.RightArrow)) { //Right Arrow

			pressingRight = true;
		} else {

			pressingRight = false;
		}

		if (Input.GetKey(KeyCode.Space)) { //Space Key

			pressingSpace = true;
		} else {

			pressingSpace = false;
		}


        //Processes
        //transform.position = new Vector3(player.GetComponent<Player>().x,0,0);



	}
}
