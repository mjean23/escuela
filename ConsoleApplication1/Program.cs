//Text RPG Project
//Author: Melissa Mojica (n01110962)
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
	class Program {
		static void Main(string[] args) {
			string pName;
			int i;
			bool valid = false, start;
			Player p = new Player();

			Console.WriteLine("Enter Player Name");
			pName = Console.ReadLine();
			Console.WriteLine("Welcome {0}.", pName);
			
			do {
				Console.WriteLine("Enter 1 to start a new game.");
				Console.WriteLine("Enter 2 to exit.");
				string input = Console.ReadLine();
				valid = int.TryParse(input, out i);
				int j = i;
				if (j == 1 || j == 2 || j == 23) {
					valid = true;
				} else {
					valid = false;
				}
			} while (!valid);

			if (i == 1||i ==23) {
				if (i == 23) {
					Console.WriteLine("Ooo, bonus menu. \nYou can set your "
						+ "starting lvl here. \nEverything will scale "
						+ "accordingly.");
						
				}
				Console.WriteLine("Select your weapon: \n1. Sword & Shield "
					+ "(Low Damage, High Defense) \n2. Gun (High Damage, "
					+ "Low Defense) \n3. Lance (Mid Damage, Mid Defense)");

				start = true;

				//game loop	
				while (start == true) {
					//return;
				}
			} else if (i == 2) {
				return;
			} 
		}

		void lose() {
			Console.WriteLine("You Died. Your dead. \nHa! Basura.");
		}
		void menu() {
			bool valid;
			int i;
			Console.WriteLine("Main Menu: \n  1. Return to game \n  2. New Game"
				+ "\n  3. Exit game");
			do{
				string input = Console.ReadLine();
				valid = int.TryParse(input, out i);
				int j = i;
				if (j == 1 || j == 2 || j == 23)
				{
					valid = true;
				}
				else {
					Console.WriteLine("Invalid choice. \n Enter 1, 2, or 3"
						+ "\n It's not hard...");
					valid = false;
				}
			} while (!valid);
		}

	}
}
