namespace ti4_calc
{	
	interface IShip
	{
		string Name { get; }
		bool Upgraded { get; }
		int Reinforcements { get; }
		int Cost { get; }
		int Capacity { get; }

		int CombatToHit { get; }
		int CombatDiceCount { get; }
		bool SpecialAbilitySustainDamage { get; }

		// bool HasPlanetaryShield { get; }
		// bool CanBypassPlanetaryShield { get; }

		// string SpecialText { get; }

		// int Move { get; }

		// void UpgradeUnits();
		// void DowngradeUnits();
	}
}
