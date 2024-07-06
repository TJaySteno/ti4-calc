namespace ti4_calc
{
	internal class Infantry : IGroundUnit
	{
		// IGroundUnit properties
		public string Name { get; } = "Infantry";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 12;

		public double Cost { get; } = 0.5;
		public int CombatToHit { get; private set; } = 8;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; } = false;

		public int CapacityCost { get; } = 1;
		// IGroundUnit properties


		public Infantry(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			// Upgrade logic

			// Faction logic
		}
	}
}