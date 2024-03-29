using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public class ConnecionManager : MonoBehaviour {

	public string localIP;
	public int localPort;
	//Data buffer for incoming data.
	byte[] bytes = new byte[1024];
	// Use this for initialization
	void Start () {



		Connect (); //connect to the server


	

}


	void Connect(){

		//Connect to server

		//Establish the remote endpoint for the socket.
		IPHostEntry ipHostInfo = Dns.GetHostEntry(localIP); //My local machine IP
		IPAddress ipAddress = ipHostInfo.AddressList [0];
		IPEndPoint remoteEP = new IPEndPoint (ipAddress, localPort);
		//Create a TCP/IP socket.
		Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		//Connect the socket to the server. Catch any errors.
		Debug.Log(remoteEP);
		Debug.Log (ipHostInfo.AddressList[0]);

		try{
			sender.Connect(remoteEP);

			Console.WriteLine("Socket connected");
			sendData(sender);


		}catch(Exception e){

			Debug.Log (e.ToString());

		}
	}//connect

	void Update(){ //waiting for connection


        Connect();


	}

	void sendData(Socket sender){

		//Data buffer for incoming data.
		byte[] bytes = new byte[1024];

        string sendData = GameObject.Find("NetworkManager").GetComponent<packet>().pressingUp+"";
       // string sendData = NetworkManager.GetComponent<packet>().pressingUp;
        





		//Encode the data string to a byte array. 
		byte[] msg = Encoding.ASCII.GetBytes(sendData);
        Debug.Log("Data Sent: "+sendData);
		//Send data.
		int bytesSent = sender.Send(msg);
        

		//Recieve the responce form the server
		int bytesRec = sender.Receive(bytes);

        string dataRec = Encoding.ASCII.GetString(bytes, 0, bytesRec);

        dataRec = dataRec.ToString();

        Debug.Log(dataRec);

        

        GameObject.Find("Player/name").GetComponent<TextMesh>().text = dataRec.Split(',')[0]; ; //Set name

        GameObject.Find("Player").transform.position = new Vector3(float.Parse(dataRec.Split(',')[2]), float.Parse(dataRec.Split(',')[3]), 0);


        Debug.Log("Data Recieved: " + dataRec);

		//Release the socket.
		sender.Shutdown(SocketShutdown.Both);
		sender.Close();



	}





}






	
	
	
