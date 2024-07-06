using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti4_calc
{
	internal class PDS : IUnit, IPlanetaryShield, ISpaceCannon
	{
		// IUnit properties
		public string Name { get; } = "PDS";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 6;
		// IUnit properties


		// IPlanetaryShield properties
		public bool PlanetaryShield { get; } = true;
		// IPlanetaryShield properties


		// ISpaceCannon properties
		public int SpaceCannonToHit { get; private set; } = 6;
		public int SpaceCannonDiceCount { get; } = 1;
		// ISpaceCannon properties


		public PDS(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			// Upgrade logic

			// Faction logic
		}

		// Max 2 PDS per system, but upgraded PDS can fire in adjacent systems.
		public int GetMaxPDS() => Upgraded ? Reinforcements : 2;
	}
}