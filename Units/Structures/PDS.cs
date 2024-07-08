namespace ti4_calc
{
	internal class PDS : IUnit, IPlanetaryShield
	{
		// IUnit
		public string Name { get; } = "PDS";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 6;
		public string SpecialText { get; }
		// IUnit

		// ICombatUnit
		public double Cost { get; }
		public int CombatToHit { get; private set; } = 0;
		public int CombatDiceCount { get; private set; } = 0;
		public bool SpecialAbilitySustainDamage { get; private set; } = false;
		public bool IgnoreDirectHit { get; } = false;
		// ICombatUnit

		// IPlanetaryShield
		public bool PlanetaryShield { get; } = true;
		// IPlanetaryShield

		// ISpaceCannon properties
		public int SpaceCannonToHit { get; private set; } = 6;
		public int SpaceCannonDiceCount { get; } = 1;
		// ISpaceCannon properties


		public PDS(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			if (upgraded) SpaceCannonToHit = 5;

			if (faction == "Titans")
			{
				CombatToHit = (upgraded ? 6 : 7);
				CombatDiceCount = 1;

				SpecialText = "This unit is treated as both a structure and a ground force. It cannot be transported.";
			}
		}	

		// Max 2 PDS per system, but upgraded PDS can fire in adjacent systems.
		public int GetMaxPDS() => Upgraded ? Reinforcements : 2;
	}
}