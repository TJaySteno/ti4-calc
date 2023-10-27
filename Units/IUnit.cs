namespace ti4_calc
{
/*	interface ISpecialAttack
	{
		string SpecialAttackType { get; }
		int SpecialAttackToHit { get; }
		int SpecialAttackNumberOfDice { get; }

		string GetSpecialAttack();
		int UseSpecialAttack(); // Return number of hits made.
	}*/
	
	interface IUnit
	{
		int Health { get; }
		int CombatHealth { get; }
		bool IsDestroyed { get; }

		int Cost { get; }
		int Move { get; }
		int Capacity { get; }

		int ToHit { get; }
		int NumberOfCombatDice { get; }
		int Reinforcements { get; }

		// bool HasPlanetaryShield { get; }
		// bool CanBypassPlanetaryShield { get; }

		// string SpecialText { get; }

		bool DamageUnit(bool directHit = false); // Returns true if unit is destroyed.
		void UpgradeUnit();
		void DowngradeUnit();

		// UseSustainDamage()
		// ResetSustainDamage()
	}
}
