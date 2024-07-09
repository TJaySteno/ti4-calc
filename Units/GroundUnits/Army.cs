using System;
using System.Collections.Generic;
using ti4_calc.Units.GroundUnits;

namespace ti4_calc.Units.GroundUnits
{
	internal class Army
	{
		internal int Count { get; private set; }
		internal int AliveCount { get; private set; }
		internal int CanSustainDamage { get; private set; } = 0;

		internal IArmy Type { get; private set; }

		internal Army(int count, IArmy type)
		{
			Count = count;
			AliveCount = count;
			if (type.SpecialAbilitySustainDamage)
				CanSustainDamage = count;

			Type = type;
		}

		public void ResetArmy()
		{
			AliveCount = Count;
			if (Type.SpecialAbilitySustainDamage)
				CanSustainDamage = Count;
		}

		// Returns a negative number if there are still hits remaining after sustaining damage.
		public int SustainDamage(int hits) => CanSustainDamage -= hits;


		// Returns a negative number if there are still hits remaining after losing armies.
		public int LoseArmies(int hits)
		{
			if (CanSustainDamage > 0) throw new SustainDamageException($"Cannot destroy {Type.Name} while it can still sustain damage.");
			return AliveCount -= hits;
		}

		public string PrintArmy() => $" {Count} {Type.Name}{(Count > 1 ? "s" : "")},";
	}
}

