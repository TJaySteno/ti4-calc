namespace ti4_calc
{
	internal class Destroyer : IShip, IAntiFighterBarrage
	{
		// IShip properties
		public string Name { get; } = "Destroyer";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 8;
		public double Cost { get; } = 1;
		public int Capacity { get; private set; } = 0;

		public int CombatToHit { get; private set; } = 9;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		// IShip properties


		// Other properties
		public int AFBToHit { get; private set; } = 9;
		public int AFBDiceCount { get; private set; } = 2;
		// Other properties


		public Destroyer(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			// Upgrade logic

			// Faction logic
		}
	}
}