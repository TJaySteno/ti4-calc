using System;
using System.Collections.Generic;

namespace ti4_calc
{
	public class PlayerUnit
	{
		internal string UnitName { get; private set; }
		internal int Count { get; private set; }
		internal IUnit Unit { get; private set; }

		internal PlayerUnit(string unitName, int count, IUnit unit)
		{
			if(unit.Reinforcements < count)
			{
				Console.WriteLine("PlayerUnit.PlayerUnit: Not enough reinforcements.");
				return;
			}
			UnitName = unitName;
			Count = count;
			Unit = unit;
		}

		public bool UnitExists(List<PlayerUnit> playerUnits, string unitName)
		{
			return playerUnits.Exists(unit => unit.UnitName == unitName);
		}
		public bool HaveEnoughInReinforcements(string unitName, int count)
		{
			return count < Unit.Reinforcements;
		}

		public int AddToUnitCount(int count) => Count += count;
	}
}
