namespace ti4_calc
{
	interface IUnit
	{
		string Name { get; }
		bool Upgraded { get; }
		int Reinforcements { get; }
	}

	interface ICombatUnit : IUnit
	{
		double Cost { get; }
		int CombatToHit { get; }
		int CombatDiceCount { get; }
		bool SpecialAbilitySustainDamage { get; }
	}

	interface IShip : ICombatUnit
	{
		int Capacity { get; }

		// int Move { get; }
	}

    interface IGroundUnit : ICombatUnit, ICapacityCost
	{

	}
	
	interface IAntiFighterBarrage
	{
		int AFBToHit { get; }
		int AFBDiceCount { get; }
	}

	interface IBombardment
	{
		int BombardToHit { get; }
		int BombardDiceCount { get; }
	}

	interface ICapacityCost
	{
		int CapacityCost { get; }
	}

	interface IPlanetaryShield
	{
		bool PlanetaryShield { get; }
	}


	interface ISpaceCannon
	{
		int SpaceCannonToHit { get; }
		int SpaceCannonDiceCount { get; }
	}
}
