using ti4_calc.SpecialAbilities;

namespace ti4_calc
{
	internal class Dreadnought : IShip, IBombardment
	{
		// IShip properties
		public string Name { get; } = "Dreadnought";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 5;
		public double Cost { get; } = 4;
		public int Capacity { get; private set; } = 1;

		public int CombatToHit { get; private set; } = 5;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; } = true;
		// IShip properties


		// IBombardment properties
		public int BombardToHit { get; private set; } = 5;
		public int BombardDiceCount { get; } = 1;
		// IBombardment properties


		// Other Properties
		public bool IgnoreDirectHit { get; private set; } = false;
		// Other Properties


		public Dreadnought(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			// Upgrade logic

			// Faction logic
		}
	}
}