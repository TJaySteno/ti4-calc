using System;
using System.Collections.Generic;

namespace ti4_calc
{
	public class PlayerUnit
	{
		internal int StartingCount { get; }
		internal int CurrentCount { get; private set; }
		internal IUnit Unit { get; private set; }

		internal PlayerUnit(int count, IUnit unit)
		{
			StartingCount = count;
			CurrentCount = count;
			Unit = unit;
		}

		public int ResetUnitCount() => CurrentCount = StartingCount;

		public int LoseUnits(int count) => CurrentCount -= count;
		
		public string PrintUnit() => $" {Unit.Name}: {StartingCount},";
	}
}
