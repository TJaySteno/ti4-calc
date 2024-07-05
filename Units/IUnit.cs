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
		string Name { get; }
		int ToHit { get; }

		// int Reinforcements { get; }
		// int Capacity { get; }
		// int NumberOfCombatDice { get; }

		// bool HasPlanetaryShield { get; }
		// bool CanBypassPlanetaryShield { get; }

		// string SpecialText { get; }

		// int Cost { get; }
		// int Move { get; }
		
		// void UpgradeUnits();
		// void DowngradeUnits();

		// UseSustainDamage()
		// ResetSustainDamage()
	}
}
