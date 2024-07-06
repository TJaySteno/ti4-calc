namespace ti4_calc
{
	internal class Cruiser : IShip
	{
		// IShip properties
		public string Name { get; } = "Cruiser";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 8;
		public double Cost { get; } = 2;
		public int Capacity { get; private set; } = 0;

		public int CombatToHit { get; private set; } = 7;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		// IShip properties


		public Cruiser(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			// Upgrade logic

			// Faction logic
		}
	}
}
