using ti4_calc.Units.SpaceUnits;
	
namespace ti4_calc
{
	internal class Cruiser : IShip
	{
		// IUnit
		public string Name { get; } = "Cruiser";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 8;
		public string SpecialText { get; }
		// IUnit

		// ICombatUnit
		public double Cost { get; } = 2;
		public int CombatToHit { get; private set; } = 7;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		public bool IgnoreDirectHit { get; } = false;
		// ICombatUnit

		// IShip
		public int Capacity { get; private set; } = 0;
		public int Move { get; private set; } = 2;

		public int AFBToHit { get; }
		public int AFBDiceCount { get; }

		public int BombardToHit { get; }
		public int BombardDiceCount { get; }

		public bool DisablePlanetaryShield { get; } = false;

		public int SpaceCannonToHit { get; }
		public int SpaceCannonDiceCount { get; }
		// IShip


		public Cruiser(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			if (faction == "Titans") Capacity = 1;

			if (upgraded)
			{
				Capacity += 1;
				Move = 3;
				CombatToHit = 6;

				if (faction == "Titans")
					SpecialAbilitySustainDamage = true;
			}
		}
	}
}
