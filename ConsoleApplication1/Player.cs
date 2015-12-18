using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//include hp, weapon, lvl, score
namespace ConsoleApplication1 {
	public class Player { 
		protected int lvl, baseHP = 80, baseATT, baseDEF, hp = 80, score = 10;
		protected string name, weapon; 
		private bool alive = true;

		public string Name {
			get { return name; }
			set { name = value; } 
		}

		public string Weapon {
			get { return weapon; }
			set { weapon = value; }
		}

		public int LVL {
			get { return lvl; }
			set { lvl = value; }
		}

		public int BaseAtt {
			get { return baseATT; }
			set { baseATT = value; }
		}

		public int BaseDef {
			get { return baseDEF; }
			set { baseDEF = value; }
		}

		public int HP {
			get { return hp; }
			set { hp = value; }
		}
		public int BaseHp {
			get { return baseHP; }
			set { baseHP = value; }
		}
		public int Score {
			get { return score; }
			set { score = value; }
		}
		public bool Alive {
			get { return alive; }
			set { alive = value; }
		}

		public Player() {
		}
		
	}
}
