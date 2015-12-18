//Text RPG Project
//Author: Melissa Mojica (n01110962)
//version: 1.11
//The balance is not good at all

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
	class Program
	{
		//public static void Main(string[] args)
		public static void Main()
		{
			string pName; 
			int i; 
			bool valid = false, start, reset = false;
			Player p = new Player();

			Console.WriteLine("Enter Player Name");
			pName = Console.ReadLine();
			p.Name = pName;
			Console.WriteLine("Welcome {0}.", pName);

			
				Console.WriteLine("----------------------------------");
				do
				{
					Console.WriteLine("Enter 1 to start a new game.");
					Console.WriteLine("Enter 2 to exit.");
					string input = Console.ReadLine();
					valid = int.TryParse(input, out i);
					int j = i;
					if (j == 1 || j == 2 || j == 23)
					{
						valid = true;
					}
					else {
						valid = false;
					}
				} while (!valid);

				if (i == 1 || i == 23)
				{
					if (i == 23)
					{
						Console.WriteLine("----------------------------------");
						Console.WriteLine("Ooo, secret menu. \nYou can set your "
							+ "difficulty lvl here. \nThe default level is 1. "
							+ "\nThe max level is 50. "
							+ "\nEnter a number from 1-50");
						reset = false;
						do
						{
							string input = Console.ReadLine();
							int lvl;
							reset = int.TryParse(input, out lvl);
							int j = lvl;
							if (j >= 1 && j <= 50)
							{
								p.LVL = j;
								reset = true;
							}
							else {
								Console.WriteLine("Enter a number between 1 and"
									+ " 50.\n It's not hard...");
								reset = false;
							}
						} while (!reset);
					}
					else { p.LVL = 1; }

					Console.WriteLine("----------------------------------");
					Console.WriteLine("Select your weapon: \n1. Sword & Shield "
						+ "(Low Damage, High Defense) \n2. Gun (High Damage, "
						+ "Low Defense) \n3. Lance (Mid Damage, Mid Defense)");
					valid = false;

					do
					{
						string input = Console.ReadLine();
						valid = int.TryParse(input, out i);
						int j = i;
						if (j == 1 || j == 2 || j == 3)
						{
							valid = true;
						}
						else {
							Console.WriteLine("Invalid choice. \n Enter 1, 2,"
								+ " or 3\n It's not hard...");
							valid = false;
						}
					} while (!valid);

					//sets weapon
					switch (i)
					{
						case 1:
							p.Weapon = "Sword & Shield";
							p.BaseAtt = 3;
							p.BaseDef = 5;
							break;
						case 2:
							p.Weapon = "Gun";
							p.BaseAtt = 5;
							p.BaseDef = 1;
							break;
						case 3:
							p.Weapon = "Lance";
							p.BaseAtt = 4;
							p.BaseDef = 3;
							break;
					}

					start = true;

					while (start == true)
					{
						Console.WriteLine("----------------------------------");
						Console.WriteLine("[Enter 9 at anytime to open menu.]");
						Console.WriteLine("[ This is a gauntlet, you do not ]");
						Console.WriteLine("[   recover HP between battles   ]");
						Console.WriteLine("[    You fight until you die     ]");
						Console.WriteLine("[        or you turn back        ]");
						Console.WriteLine("----------------------------------");
						Console.WriteLine("The road ahead is haunted by the "
							+ "shadows of adventurers past...");
						Console.WriteLine("Do you truly whish to walk this "
							+ "path?");
						Console.Read();

						Console.WriteLine("----------------------------------");
						Console.WriteLine("[Encounter 1]");
						Console.WriteLine("----------------------------------");
						Dragon e1 = new Dragon();
						e1.scaleATT(p.LVL);
						e1.scaleHP(p.LVL);
						e1.PlayLvl = p.LVL;
						Console.WriteLine(e1.Intro);
						Console.WriteLine("1. Enter battle \n2. Turn back, "
							+ "I won't laugh at you...much");
						valid = false;

						do
						{
							string input = Console.ReadLine();
							valid = int.TryParse(input, out i);
							int j = i;
							if (j == 1 || j == 2 || j == 9)
							{
								valid = true;
							}
							else {
								valid = false;
							}
						} while (!valid);

						switch (i)
						{
							case 1:
								do
								{
									if (p.Alive == false) {
										lose();
										gameOver(p);
									}
									Console.WriteLine("------------------------"
										+ "----------");
									valid = false;

									Console.WriteLine("1. Attack \n2. Defend "
										+ "\n3. Scan");
									do
									{
										string input = Console.ReadLine();
										valid = int.TryParse(input, out i);
										int j = i;
										if (j==1 || j==2 || j==3 || j==9)
										{
											valid = true;
										}
										else {
											Console.WriteLine("Invalid choice."
												+ "\n Enter 1, 2, or 3"
												+ "\n It's not hard...");
											valid = false;
										}
										switch (i)
										{
											case 1:
												attack(p, e1);
												if (e1.Alive != false)
												{
													damage(p, e1);
												}
												break;
											case 2:
												defend(p, e1);
												break;
											case 3:
												scan(e1);
												damage(p, e1);
												break;
											case 9:
												menu(p);
												break;
										}
									} while (!valid);

								} while (e1.Alive);
								Console.WriteLine("Winner!\nNo time to rest. "
									+ "\nOn to the next one.");
								Console.WriteLine("----------------------------"
									 + "------");
								string n = p.Name;
								string w = p.Weapon;
								int s = p.Score;
								int hp = p.HP;
								int max = p.BaseHp;
								int l = p.LVL;
								Console.WriteLine("Player: " + n + "\nLevel: "
									+ l + "\nEquipment: " + w + "\nScore: " + s
									+ "\nCurrent HP: " + hp + "/" + max);
								Console.Read();

								break;
							case 2:
								gameOver(p);
								break;

							case 9:
								menu(p);
								break;
						}


						Console.WriteLine("----------------------------------");
						Console.WriteLine("[Encounter 2]");
						Console.WriteLine("----------------------------------");
						Greg e2 = new Greg();
						e2.scaleATT(p.LVL);
						e2.scaleHP(p.LVL);
						e2.PlayLvl = p.LVL;
						Console.WriteLine(e2.Intro);
						Console.WriteLine("1. Enter battle \n2. Turn back, "
							+ "I won't laugh at you...much");
						valid = false;

						do
						{
							string input = Console.ReadLine();
							valid = int.TryParse(input, out i);
							int j = i;
							if (j == 1 || j == 2 || j == 9)
							{
								valid = true;
							}
							else {
								valid = false;
							}
						} while (!valid);

						switch (i)
						{
							case 1:
								do
								{
									if (p.Alive == false)
									{
										lose();
										gameOver(p);
									}
									Console.WriteLine("------------------------"
										+ "----------");
									valid = false;

									Console.WriteLine("1. Attack \n2. Defend "
										+ "\n3. Scan");
									do
									{
										string input = Console.ReadLine();
										valid = int.TryParse(input, out i);
										int j = i;
										if (j==1 || j==2 || j==3 || j==9)
										{
											valid = true;
										}
										else {
											Console.WriteLine("Invalid choice."
												+ "\n Enter 1, 2, or 3"
												+ "\n It's not hard...");
											valid = false;
										}
										switch (i)
										{
											case 1:
												attack(p, e2);
												if (e2.Alive != false) {
													damage(p, e2);
												}
												break;
											case 2:
												defend(p, e2);
												break;
											case 3:
												scan(e2);
												damage(p, e2);
												break;
											case 9:
												menu(p);
												break;
										}
									} while (!valid);

								} while (e2.Alive);
								Console.WriteLine("Winner!\nNo time to rest. "
									+ "\nOn to the next one.");
								Console.WriteLine("----------------------------"
									+ "------");
								string n = p.Name;
								string w = p.Weapon;
								int s = p.Score;
								int hp = p.HP;
								int max = p.BaseHp;
								int l = p.LVL;
								Console.WriteLine("Player: " + n + "\nLevel: " 
									+ l + "\nEquipment: " + w + "\nScore: " + s 
									+ "\nCurrent HP: " + hp + "/" + max);
								Console.Read();
								break;
							case 2:
								gameOver(p);
								break;

							case 9:
								menu(p);
								break;
						}

					}
				} else if (i == 2) {
					//exits game
					Environment.Exit(0);
				}
			
		}
		
		static void lose() {
			//loss message
			Console.WriteLine("----------------------------------");
			Console.WriteLine("You Died. Your dead. \nHa! Basura.");
		}

		static void gameOver(Player p) {
			bool valid = false;
			int i;
			Console.WriteLine("----------------------------------");
			Console.WriteLine("GAME OVER");
			Console.WriteLine("Your score: " + p.Score);
			Console.WriteLine("----------------------------------");
			Console.WriteLine("1. New Game \n2. Exit game");
			do {
				string input = Console.ReadLine();
				valid = int.TryParse(input, out i);
				int j = i;
				if (j == 1 || j == 2) {
					valid = true;
				} else {
					valid = false;
				}
			} while (!valid);

			switch (i) {
				case 1:
					Main();
					break;
				case 2:
					Environment.Exit(0);
					break;
			}
		}


		static void menu(Player p)
		{
			//main menu
			bool valid = false;
			int i;

			Console.WriteLine("----------------------------------");
			string n = p.Name;
			string w = p.Weapon;
			int s = p.Score;
			int hp = p.HP;
			int max = p.BaseHp;
			int l = p.LVL;
			Console.WriteLine("Player: " + n + "\nLevel: " + l + "\nEquipment: "
				+ w + "\nScore: " + s + "\nCurrent HP: " + hp + "/" + max);
			Console.WriteLine("----------------------------------");
			Console.WriteLine("Main Menu: \n  1. Return to game "
				+ "\n  2. New Game\n  3. Exit game");
			do
			{
				string input = Console.ReadLine();
				valid = int.TryParse(input, out i);
				int j = i;
				if (j == 1 || j == 2 || j == 3)
				{
					valid = true;
				}
				else {
					Console.WriteLine("Invalid choice. \n Enter 1, 2, or 3"
						+ "\n It's not hard...");
					valid = false;
				}
			} while (!valid);
			switch (i)
			{
				case 1:
					return;
				case 2:
					Main();
					break;
				case 3:
					Environment.Exit(0);
					break;
			}
		}


		static void menuA(Player p)
		{
			//main menu
			bool valid = false;
			int i;

			Console.WriteLine("----------------------------------");
			string n = p.Name;
			string w = p.Weapon;
			int s = p.Score;
			int hp = p.HP;
			int max = p.BaseHp;
			int l = p.LVL;
			Console.WriteLine("Player: " + n + "\nLevel: " + l + "\nEquipment: "
				+ w + "\nScore: " + s + "\nCurrent HP: " + hp + "/" + max);
			Console.WriteLine("----------------------------------");
			Console.WriteLine("Main Menu: \n  1. New Game\n  2. Exit game");
			do
			{
				string input = Console.ReadLine();
				valid = int.TryParse(input, out i);
				int j = i;
				if (j == 1 || j == 2)
				{
					valid = true;
				}
				else {
					Console.WriteLine("Invalid choice. \n Enter 1, 2, or 3"
						+ "\n It's not hard...");
					valid = false;
				}
			} while (!valid);
			switch (i)
			{
				case 1:
					Main();
					break;
				case 2:
					Environment.Exit(0);
					break;
			}
		}

		//defend command
		static void defend(Player p, Dragon e) {
			//int def = p.BaseDef + ((p.BaseDef * p.LVL) / 150);
			int def = ((p.BaseDef * p.LVL) / 110);
			int dmg;
			dmg = e.behavior()/2 + def;
			p.HP += dmg;
			Console.WriteLine("----------------------------------");
			Console.WriteLine("You recover " + dmg + " HP.");
		}
		//attack command
		static void attack(Player p, Dragon e) {
			int dmgDealt;
			dmgDealt = (p.BaseAtt + (p.LVL / 50));
			Console.WriteLine("----------------------------------");
			Console.WriteLine("You attack. " + Environment.NewLine
				+ "You deal " + dmgDealt + " damage.");
			e.CurrHP -= dmgDealt;
			if (e.CurrHP <= 0) {
				e.Alive = false;
				Console.WriteLine(e.Outro);
				Console.WriteLine("----------------------------------");
				Console.Read();
				p.Score += 10;
			}
		}
		//update hp for dmg taken 
		static void damage(Player p, Dragon e) {
			//int def = p.BaseDef + ((p.BaseDef * p.LVL) / 200);
			int def = ((p.BaseDef * p.LVL) / 200);
			int dmg;
			dmg = e.behavior() - def;
			p.HP -= dmg;
			Console.WriteLine("----------------------------------");
			Console.WriteLine("You take " + dmg + " damage.");
			if (p.HP <= 0) {
				p.Alive = false;
			}
		}
		//scan command
		static void scan(Dragon e) {
			int currHP= e.CurrHP;
			int totalHP = e.HP;
			string wep = e.Weapon;
			string special = e.Special;
			Console.WriteLine("----------------------------------");
			Console.WriteLine("Special attack: " + special);
			Console.WriteLine("Weapon: " + wep);
			Console.WriteLine("HP: " + currHP + "/" + totalHP);

		}
		
		//c# doesn't support templating, 
		//and I don't know how to work generics
		//so I'm just gonna overload functions instead
		//It's not clean, but it'll work.

		//defend command
		static void defend(Player p, Greg e) {
			//int def = p.BaseDef + ((p.BaseDef * p.LVL) / 150);
			int def = ((p.BaseDef * p.LVL) / 110);
			int dmg;
			dmg = e.behavior(p) / 2 + def;
			if (dmg >= 1000) {
				p.Alive = false;
			} else {
				p.HP += dmg;
				Console.WriteLine("----------------------------------");
				Console.WriteLine("You recover " + dmg + " HP.");
			}
		}
		//attack command
		static void attack(Player p, Greg e) {
			int dmgDealt;
			dmgDealt = (p.BaseAtt + (p.LVL / 50));
			Console.WriteLine("----------------------------------");
			Console.WriteLine("You attack. " + Environment.NewLine
				+ "You deal " + dmgDealt + " damage.");
			e.CurrHP -= dmgDealt;
			if (e.CurrHP <= 0) {
				e.Alive = false;
				Console.WriteLine(e.Outro);
				Console.WriteLine("----------------------------------");
				Console.Read();
				p.Score += 10;
			}
		}
		//update hp for dmg taken 
		static void damage(Player p, Greg e) {
			//int def = p.BaseDef + ((p.BaseDef * p.LVL) / 200);
			int def = ((p.BaseDef * p.LVL) / 200);
			int dmg;
			dmg = e.behavior(p)-def;
			p.HP -= dmg;
			Console.WriteLine("----------------------------------");
			Console.WriteLine("You take " + dmg + " damage." );
			if (p.HP <= 0 ) {
				p.Alive = false;
			}
		}
		//scan command
		static void scan(Greg e) {
			int currHP = e.CurrHP;
			int totalHP = e.HP;
			string wep = e.Weapon;
			string special = e.Special;
			Console.WriteLine("----------------------------------");
			Console.WriteLine("Special attack: " + special);
			Console.WriteLine("Weapon: " + wep);
			Console.WriteLine("HP: " + currHP + "/" + totalHP);

		}

	}
}
