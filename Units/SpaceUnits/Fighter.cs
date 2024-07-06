namespace ti4_calc
{
	internal class Fighter : IShip, ICapacityCost
	{
		// IShip properties
		public string Name { get; } = "Fighter";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 10;
		public double Cost { get; } = 0.5;
		public int Capacity { get; private set; } = 4;

		public int CombatToHit { get; } = 9;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		// IShip properties


		// ICapacityCost properties
		public int CapacityCost { get; } = 1;
		// ICapacityCost properties


		public Fighter(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			// Upgrade logic

			// Faction logic
		}
	}
}