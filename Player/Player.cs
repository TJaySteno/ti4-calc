using System;
using System.Collections.Generic;
using System.Linq;

namespace ti4_calc
{
	internal class Player
	{
		internal string Faction { get; private set; }
		internal List<PlayerUnit> PlayerUnits = new List<PlayerUnit>();
		
		internal Player(string faction) { Faction = faction; }


		public void AddNewUnitType(string unitName, int count, IUnit unit)
		{
			if (PlayerUnits.Exists(u => u.UnitName == unitName))
			{
				Console.Write("Player.AddNewUnitType: This unit already exists for this player.");
				return;
			}
			PlayerUnits.Add(new PlayerUnit(unitName, count, unit));
		}

		// Removes the entire unit type for a given UnitName. Not sure if this is needed though.
		// public void RemoveUnits(string unitName) { }
	}
}
