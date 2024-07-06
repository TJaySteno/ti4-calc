using System;

namespace ti4_calc.SpecialAbilities
{
	internal class SustainDamage
	{
		public bool DamageSustained { get; private set; } = false;
		public bool IgnoreDirectHit { get; private set; }

		public SustainDamage(bool ignoreDirectHit = false)
		{
			IgnoreDirectHit = ignoreDirectHit;
		}

		// Returns false if destroyed by Direct Hit. Check DamageSustained before calling this.
		public bool Use(bool directHit)
		{
			if (DamageSustained) throw new Exception("Unit cannot sustain more damage.");
			
			if (directHit && !IgnoreDirectHit) return false;
			return true;
		}

		public void Reset() => DamageSustained = false;
	}
}
