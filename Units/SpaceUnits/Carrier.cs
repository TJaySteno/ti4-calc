using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class Carrier : IShip
	{
		// IUnit
		public string Name { get; } = "Carrier";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 4;
		public string SpecialText { get; }
		// IUnit

		// ICombatUnit
		public double Cost { get; } = 3;
		public int CombatToHit { get; } = 9;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		public bool IgnoreDirectHit { get; } = false;
		// ICombatUnit

		// IShip
		public int Capacity { get; private set; } = 4;
		public int Move { get; private set; } = 1;

		public int AFBToHit { get; }
		public int AFBDiceCount { get; }

		public int BombardToHit { get; }
		public int BombardDiceCount { get; }

		public bool DisablePlanetaryShield { get; } = false;

		public int SpaceCannonToHit { get; }
		public int SpaceCannonDiceCount { get; }
		// IShip


		public Carrier(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;
			
			if (upgraded) Move = 2;
			
			if (faction == "Sol" && upgraded)
			{
				Capacity = 8;
				SpecialAbilitySustainDamage = true;
			}
			else if (faction == "Sol" || upgraded)
			{
				Capacity = 6;
			}
		}
	}
}