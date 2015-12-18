using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//include hp, weapon, attack
namespace ConsoleApplication1 {
	public class Enemy {
		protected int baseHP,baseATT,dmgDealt,currHP,playLVL,att,hp,playHP;

		protected bool alive = true;

		//standard and special are attacks
		protected string intro, outro, standard, special, wep;
		protected Enemy() { }
		public string Intro { get { return intro; } }
		public string Outro { get { return outro; } }
		public string Standard { get { return standard; } }
		public string Special { get { return special; } }
		public string Weapon { get { return wep; } }
		public int HP { get { return hp; } }
		public int BaseHP { get { return baseHP; } }
		public int CurrHP {
			get { return currHP; }
			set { currHP = value; }
		}
		public int PlayLvl {
			get { return playLVL; }
			set { playLVL = value; }
		}
		public int PlayHp {
			get { return playHP; }
			set { playHP = value; }
		}
		public bool Alive {
			get { return alive; }
			set { alive = value; }
		}
		protected int standardDMG() {
			dmgDealt = (att + (playLVL/110));
			return dmgDealt;
		}
		protected int specialDMG() { return dmgDealt; }
		public void scaleHP(int playLVL) {
			hp = baseHP + playLVL / 10;
		}
		public void scaleATT(int playLVL) {
			att = baseATT + playLVL / 10;
		}
		public int behavior() { return dmgDealt; }
	}
	public class Dragon : Enemy {
		public Dragon() {
			standard = "Attack";
			special = "Jump";
			wep = "Gungnir";
			baseHP = 20;
			baseATT = 3;
			intro = "The shadow of a knight approaches. " + Environment.NewLine
				+ "Wielding a Lance and clad in armour adorned with dragons, "
				+ Environment.NewLine + "he wishes to test your skill.";
			outro = "\"Hmph.\" " + Environment.NewLine + "\"You've talent.\" "
				+ Environment.NewLine + "\"Perhaps you'll be able to reach"
				+ " the end.\"" + Environment.NewLine + Environment.NewLine
				+ "The shadow fades.";
		}
		public void scaleHP(int playLVL) {
			hp = baseHP + playLVL / 10;
			currHP = hp;
		}
		public void scaleATT(int playLVL) {
			att = baseATT + playLVL / 10;
		}
		protected int specialDMG() {
			dmgDealt = (int)(standardDMG() * 1.5 + (playLVL / 110));
			return dmgDealt;
		}
		public int behavior() {
			var r = new Random();
			int i = r.Next(1, 101), d;
			if (i <= 65) {
				d = standardDMG();
				Console.WriteLine("The enemy attacks.");
			} else if (i > 65) {
				d = specialDMG();
				Console.WriteLine("The enemy Jumps high and crashes down on"
					+ " you.");
			}
			d = dmgDealt;
			return dmgDealt;
		}
	}

	public class Greg : Enemy {
		public Greg() {
			standard = "Attack";
			special = "Rocket Punch";
			wep = "Variable";
			baseHP = 26;
			baseATT = 2;
			intro = "You encounter a creature garbed in red. " 
				+ Environment.NewLine + "Having eight arms, and brandishing"
				+ "a different weapon in each," + Environment.NewLine 
				+ "he challenges you to a duel.";
			outro = "\"I, uhh, just realized... " + Environment.NewLine
				+ "I...have a thing to go to." + Environment.NewLine
				+ "Gotta run!" + Environment.NewLine + Environment.NewLine
				+ "Confused, you're left wondering wheather he was another "
				+ "shadow or not";
		}
		public void scaleHP(int playLVL) {
			hp = baseHP + playLVL / 10;
			currHP = hp;
		}
		public void scaleATT(int playLVL) {
			att = baseATT + playLVL / 10;
		}
		protected int standardDMG(Player p)
		{
			dmgDealt = (att + (playLVL / 110)- p.BaseDef);
			return dmgDealt;
		}
		protected int specialDMG(int playHP) {
			//ok, the way this attack is Supposed to work is
			//damage equal to half player's current hp
			//it's mean, but it shouldn't beable to kill you
			dmgDealt = ((playHP/2) - 1); 
			return dmgDealt;
		}
		public int behavior(Player p) {
			var r = new Random();
			int i = r.Next(1, 101), d;
			if (i <= 85) {
				// his standard attacks have some random attatched to them
				// depending on the roll a different effect will happen
				var r2 = new Random();
				int j = r2.Next(1, 8);
				switch (j){
					case 1:
					case 7:
						//normal damage
						d = standardDMG();
						Console.WriteLine("The enemy attacks With Naga.");
						break;
					case 2:
						//75% normal damage
						d = (int)(standardDMG()*0.75);
						Console.WriteLine("The enemy attacks With Genji.");
						break;
					case 3:
						//175% normal damage
						d = (int)(standardDMG() * 1.75);
						Console.WriteLine("The enemy attacks With Battle Axe.");
						break;
					case 4:
						//x2 damage
						d = standardDMG()*2;
						Console.WriteLine("The enemy attacks With Bur.");
						break;
					case 5:
						//damage=1
						d = 1;
						Console.WriteLine("The enemy attacks With Pur.");
						break;
					case 6:
						//%chance will cast instant death, 
						//otherwise normal damage
						//%based on lvl
						Console.WriteLine("The enemy attacks With Zan.");
						var r3 = new Random();
						int k = playLVL;
						int l = r3.Next(1,101);
						if (k >= l) {
							Console.WriteLine("Instant Death activates.");
							Console.WriteLine("DAMN YOU, RNG!");
							d = 9999;
						} else {
							d = standardDMG();
						}
						break;
				}
			} else if (i > 15) {
				//checks player's current hp.
				int j = p.HP;
				Console.WriteLine(j);
				d = specialDMG(j);
				if (d < 0) { d = 0; }
				Console.WriteLine("\"Rocket Punch!\" \nOh,shit.");
			}
			d = dmgDealt;
			return dmgDealt;
		}
	}
}
