using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class Destroyer : IShip
	{

		// IUnit
		public string Name { get; } = "Destroyer";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 8;
		public string SpecialText { get; private set; }
		// IUnit

		// ICombatUnit
		public double Cost { get; } = 1;
		public int CombatToHit { get; private set; } = 9;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		public bool IgnoreDirectHit { get; } = false;
		// ICombatUnit

		// IShip
		public int Move { get; } = 2;
		public int Capacity { get; private set; }

		public int AFBToHit { get; } = 9;
		public int AFBDiceCount { get; private set; } = 2;

		public int BombardToHit { get; }
		public int BombardDiceCount { get; }

		public bool DisablePlanetaryShield { get; }

		public int SpaceCannonToHit { get; }
		public int SpaceCannonDiceCount { get; }
		// IShip


		public Destroyer(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			if (upgraded)
			{
				CombatToHit = 8;
				
				AFBToHit = 6;
				AFBDiceCount = 3;
			}

			if (faction == "Argent")
			{
				Capacity = 1;
				CombatToHit -= 1;

				if (upgraded)
					SpecialText = "When this unit uses ANTI-FIGHTER BARRAGE, each result of 9 or 10 also destroys 1 of your opponents infantry in the space area of the active system";
			}
		}
	}
}