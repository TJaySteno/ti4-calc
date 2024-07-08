using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class Fighter : IShip, ICapacityCost
	{
		// IUnit
		public string Name { get; } = "Fighter";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 10;
		public string SpecialText { get; private set; }
		// IUnit

		// ICombatUnit
		public double Cost { get; } = 0.5;
		public int CombatToHit { get; } = 9;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		public bool IgnoreDirectHit { get; } = false;
		// ICombatUnit

		// IShip
		public int Capacity { get; }
		public int Move { get; private set; } = 0;

		public int AFBToHit { get; }
		public int AFBDiceCount { get; }

		public int BombardToHit { get; }
		public int BombardDiceCount { get; }

		public bool DisablePlanetaryShield { get; } = false;

		public int SpaceCannonToHit { get; }
		public int SpaceCannonDiceCount { get; }
		// IShip

		// ICapacityCost properties
		public int CapacityCost { get; } = 1;
		// ICapacityCost properties


		public Fighter(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;
			
			if (faction == "Naalu") CombatToHit = 8;

			if (upgraded)
			{
				CombatToHit -= 1;
				Move = 2;

				SpecialText = $"This unit may move without being transported.  Each fighter in excess of your ships' capacity counts as {(faction == "Naalu" ? "1/2 of a" : "1")} ship against your fleet pool.";
			}

		}
	}
}