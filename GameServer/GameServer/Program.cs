using System;
using System.Net; //Networking
using System.Net.Sockets; // Networking
using System.Text;
using System.Linq; // Allows use of .Contains for checking arrays.



/*
 * Todo
 * Move the StartListening into like a OnConnection(). 
 * When players connect we need to make an array to save their data. Currently after they connect their @# is output then lost
 * Then loop thru that array each frame while the other continues to check for new connections
 * 
 * After saving player data to arrays > get the packet.cs working so we can transfer more data at a time.
 */



namespace GameServer {
    class MainClass {
        //Server Setup Variables. 

        //Incoming data from the client.
        public static string data = null;




		//Main Start Method. 
		public static void Main (string[] args){

            
                Console.WriteLine("Server Started.. ");
                StartListening();

			

		}

		public static void StartListening(){
            //Create a list of current players
            Player[] PlayerList = new Player[0];
            Player player = new Player();

            Socket[] SocketList = new Socket[0]; //List of socket connections////////////
			//Data buffer for incoming data
			byte[] bytes = new Byte[1024];

			//Establish the local endpoint for the socket.
			IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost"); //My local machine ip. Dns.GetHostName returns the name of the host running the applicaiton
			IPAddress ipAddress = ipHostInfo.AddressList [0];
			IPEndPoint localEndPoint = new IPEndPoint (ipAddress, 2000);

			//Create a TCP/IP socket.
			Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			//Bind the socket to the local endpoint and listen for incoming connections
			try{

				listener.Bind(localEndPoint);
				listener.Listen(10);



                
				//Start listening for connections
				while(true){

                    Console.WriteLine("Waiting for a connection..");
					//Program is suspended while waiting for an incoming connecition.
					Socket handler = listener.Accept();

                    if (SocketList.Contains(listener) == false) //if new player connects
                    {
                        Array.Resize(ref SocketList, SocketList.Length + 1); //Add to SocketList
                        SocketList[SocketList.Length - 1] = listener;
                        Console.WriteLine(SocketList.Length);

                        //Create new player
                        player = new Player();
                        Console.WriteLine("Player Connected.. " + player.name + "(" + player.getID() + ")");

                        //Add new player to the PlayerList if not already in list.
                       if (PlayerList.Contains(player) == false ){
                       Array.Resize(ref PlayerList,PlayerList.Length + 1);
                       PlayerList[PlayerList.Length - 1] = player;

                       }

                    }

                    Console.WriteLine("Connected");


                    //An incoming connection needs to be processed.
					while(true){
						bytes = new byte[1024];
						int bytesRec = handler.Receive(bytes);
						data += Encoding.ASCII.GetString(bytes,0,bytesRec);
						if(data.IndexOf("<EOF>") > -1) {
							break;
						}
						break; //
					}//end while


















                    //You have the data var. Holding the info sent from the client. 

                        //Check if the client is an already connected client // Check using sockets? 
                        //If no > add to the client list
                        //If yes. Update his info into the server. 

                        //Accept any new info. Pressing any buttons?

                        //// Later do checks of the world and things like that before acutally just updating xy and things. 

                        //Create a loop. Loop each player. adding all of their data to the packet to send to the client
                        //The client packet must have everyones data to place them in the world. But also know which player the original client belongs to. 
                        
                    

                    
                    

                   
                    //data = player.name + "(" + player.id + ")" + ": ";
                    string[] playerdata = new string[] {player.name,player.id,player.x+"",player.y+""};

                    data = string.Join(",",playerdata);

                   

                    

                    //Loop each player. - work in progress - This will need to be moved locations - look at old n.js server to see how we did this before. -  
                    int i = 0;
                    while (i <= PlayerList.Length-1)
                    {
                        Console.WriteLine(PlayerList[i].id);
                        i++;
                    }

                 






                    














					
                     
                    //***** Send Data To Client

					//Echo the data back to the client.
					byte[] msg = Encoding.ASCII.GetBytes(data);

					handler.Send(msg);
					handler.Shutdown(SocketShutdown.Both);
					handler.Close();


				}


			}catch(Exception e){
				Console.WriteLine(e.ToString());

			}

			Console.WriteLine ("\nPress Enter To Continue..");
			Console.Read ();

		}//End StartListening







	}
}
