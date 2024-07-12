using System;
using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class PDS : IUnit, IPlanetaryShield
	{
		// Counts
		internal int Count { get; private set; } = 0;
		internal int AliveCount { get; private set; } = 0;
		// Counts


		// IUnit
		public string Name { get; } = "PDS";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 6;
		public string SpecialText { get; private set; }
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

		public void UpdatePDS(string faction, int count, bool upgraded = false)
		{
			if (count > Reinforcements)
				throw new ReinforcementsException("PDS", Reinforcements);

			Upgraded = upgraded;
			Count = count;
			AliveCount = count;

			if (upgraded) SpaceCannonToHit = 5;

			if (faction == "Titans")
			{
				CombatToHit = (upgraded ? 6 : 7);
				CombatDiceCount = 1;

				SpecialText = "This unit is treated as both a structure and a ground force. It cannot be transported.";
				// Later: Add this to List<Army> as a PDS
			}
		}	

		// Max 2 PDS per system, but upgraded PDS can fire in adjacent systems.
		public int GetMaxUpdatePDS()
			=> Upgraded ? Reinforcements : 2;

		public string Stringify()
			=> $"{Count} PDS";
	}
}