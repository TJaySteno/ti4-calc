using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class Dreadnought : IShip
	{
		// IUnit
		public string Name { get; } = "Dreadnought";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 5;
		public string SpecialText { get; private set; }
		// IUnit

		// ICombatUnit
		public double Cost { get; } = 4;
		public int CombatToHit { get; private set; } = 5;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; } = true;
		public bool IgnoreDirectHit { get; private set; } = false;
		// ICombatUnit

		// IShip
		public int Capacity { get; private set; } = 1;
		public int Move { get; private set; } = 1;

		public int AFBToHit { get; }
		public int AFBDiceCount { get; }

		public int BombardToHit { get; private set; } = 5;
		public int BombardDiceCount { get; } = 1;

		public bool DisablePlanetaryShield { get; } = false;

		public int SpaceCannonToHit { get; }
		public int SpaceCannonDiceCount { get; }
		// IShip


		public Dreadnought(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			if (faction == "L1Z1X") Capacity = 2;
			if (faction == "Sardakk")
			{
				BombardToHit = 4;
				BombardDiceCount = 2;
			}

			if (upgraded)
			{
				IgnoreDirectHit = true;
				Move = 2;

				if (faction == "L1Z1X")
				{
					CombatToHit = 4;
					BombardToHit = 4;
				}

				if (faction == "Sardakk")
				{
					SpecialText = "After a round of space combat, you may destroy this unit to destroy up to 2 ships in this system.";
				}
			}
		}
	}
}