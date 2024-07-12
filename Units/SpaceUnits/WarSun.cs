using System;
using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class WarSun : IShip
	{
		// IShip properties
		public string Name { get; } = "War Sun";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 2;
		public string SpecialText { get; }
			= "Other players' units in this system lose their Planetary Shield ability.";
		// IUnit

		// ICombatUnit
		public double Cost { get; private set; } = 12;
		public int CombatToHit { get; } = 3;
		public int CombatDiceCount { get; } = 3;
		public bool SpecialAbilitySustainDamage { get; } = true;
		public bool IgnoreDirectHit { get; } = false;
		// ICombatUnit

		// IShip
		public int Capacity { get; } = 6;
		public int Move { get; private set; } = 2;

		public int AFBToHit { get; }
		public int AFBDiceCount { get; }

		public int BombardToHit { get; } = 3;
		public int BombardDiceCount { get; } = 3;

		public bool DisablePlanetaryShield { get; } = true;

		public int SpaceCannonToHit { get; }
		public int SpaceCannonDiceCount { get; }
		// IShip


		public WarSun(string faction, bool upgraded = false)
		{
			if (!upgraded && faction != "Muaat")
				throw new CannotBuildWarSunException(faction);
			
			Upgraded = upgraded;

			if (faction == "Muaat")
			{
				Move = (upgraded ? 3 : 1);
				if (upgraded) Cost = 10;
			}
		}
	}
}