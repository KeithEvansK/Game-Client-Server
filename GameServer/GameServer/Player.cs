using System;

namespace GameServer
{
	public class Player
	{
		//Variables
		 Random idRandomizer = new Random (); //Generates Random IDs

		//Player Attributes
		public string name = "PlayAtDark";
		public string id; 
		public int x = 250;
		public int y = 250;
		public string level = "level1";
		public string previousLevel = "level0";

		public string headCode = "head1.png";
		public string bodyCode = "body1.png";

        public bool pressingLeft = false;
        public bool pressingRight = false;
        public bool pressingUp = false;
        public bool pressingDown = false;







			public string getID(){

			id = "@" + idRandomizer.Next(10000,90000).ToString();

			return id;
	        }

        
    }

    
}

