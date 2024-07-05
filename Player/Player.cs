using System;
using System.Collections.Generic;
using System.Linq;

namespace ti4_calc
{
	internal class Player
	{
		internal string Faction { get; private set; }
		internal int Wins { get; private set; } = 0;
		internal Player(string faction) { Faction = faction; }

		internal List<PlayerUnit> Fleet = new List<PlayerUnit>();

		public void AddWin() => Wins++;

		public void UpdatePlayerUnitCount(int count, IUnit unitNew)
		{
			// Ensure we aren't adding two of the same unit.
			bool unitAlreadyExists = Fleet.Exists(unitCur => unitCur.Unit.Name == unitNew.Name);

			if (unitAlreadyExists) {
				throw new Exception("Only one stack per type of unit per player can be added.");
			}

			Fleet.Add(new PlayerUnit(count, unitNew));
		}
	}
}
