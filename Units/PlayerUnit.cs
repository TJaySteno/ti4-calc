using System;

namespace ti4_calc
{
	public class PlayerShip
	{
		internal int Count { get; private set; }
		internal int AliveCount { get; private set; }
		internal int CanSustainDamage { get; private set; } = 0;
		
		internal IShip Ship { get; private set; }

		internal PlayerShip(int count, IShip unit)
		{
			Count = count;
			AliveCount = count;
			if (unit.SpecialAbilitySustainDamage)
				CanSustainDamage = count;

			Ship = unit;
		}

		public void ResetPlayerShip()
		{
			AliveCount = Count;
			if (Ship.SpecialAbilitySustainDamage)
				CanSustainDamage = Count;
		}

		// Returns a negative number if there are still hits remaining after sustaining damage.
		public int SustainDamage(int hits)
			=> CanSustainDamage -= hits;
			

		// Returns a negative number if there are still hits remaining after losing units.
		public int LoseUnits(int hits)
		{
			if (CanSustainDamage > 0) throw new Exception("You cannot destroy units that can still sustain damage.");
			return AliveCount -= hits;
		}
		
		public string PrintUnit() => $" {Count} {Ship.Name}{(Count > 1 ? "s" : "")},";
	}
}
