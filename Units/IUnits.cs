namespace ti4_calc
{
	interface IUnit
	{
		string Name { get; }
		bool Upgraded { get; }
		int Reinforcements { get; }
		string SpecialText { get; }
	}

	interface ICombatUnit : IUnit
	{
		double Cost { get; }
		int CombatToHit { get; }
		int CombatDiceCount { get; }
		bool SpecialAbilitySustainDamage { get; }
		bool IgnoreDirectHit { get; }
	}

	interface ICapacityCost { int CapacityCost { get; } }

	interface IPlanetaryShield : ICombatUnit
	{
		bool PlanetaryShield { get; }
	}

	/*interface IAntiFighterBarrage : IShip { }
	interface IBombardment { }
	interface ISpaceCannon { }*/
}
