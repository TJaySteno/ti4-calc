namespace ti4_calc
{
	internal class Carrier : IShip
	{
		// IShip properties
		public string Name { get; } = "Carrier";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 4;
		public double Cost { get; } = 3;
		public int Capacity { get; private set; } = 4;

		public int CombatToHit { get; } = 9;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		// IShip properties


		public Carrier(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			// Upgrade logic

			// Faction logic
		}
	}
}