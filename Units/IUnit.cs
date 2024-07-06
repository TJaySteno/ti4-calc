namespace ti4_calc
{	
	interface IUnit
	{
		string Name { get; }
		bool Upgraded { get; }
		int Reinforcements { get; }
		int Cost { get; }

		int CombatToHit { get; }
		int CombatDiceCount { get; }

		int Capacity { get; }


		// bool HasPlanetaryShield { get; }
		// bool CanBypassPlanetaryShield { get; }

		// string SpecialText { get; }

		// int Move { get; }

		// void UpgradeUnits();
		// void DowngradeUnits();
	}
}
