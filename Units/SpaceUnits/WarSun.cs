using System;

using ti4_calc.SpecialAbilities;

namespace ti4_calc
{
	internal class WarSun : IShip, IBombardment
	{
		// IShip properties
		public string Name { get; } = "War Sun";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 2;
		public double Cost { get; private set; } = 12;
		public int Capacity { get; } = 6;

		public int CombatToHit { get; } = 3;
		public int CombatDiceCount { get; } = 3;
		public bool SpecialAbilitySustainDamage { get; } = true;
		// IShip properties


		// IBombardment properties
		public int BombardToHit { get; } = 3;
		public int BombardDiceCount { get; } = 3;
		// IBombardment properties


		// Other Properties
		public bool BypassPlanetaryShield { get; } = true;
		// Other Properties

		public WarSun(string faction, bool upgraded = false)
		{
			if (faction != "Muaat" && !upgraded)
				throw new Exception("Unupgraded War Suns are not available to this faction.");
			
			Upgraded = upgraded;

			// Upgrade logic

			// Faction logic
		}
	}
}