namespace ti4_calc.Units.SpaceUnits
{
	interface IShip : ICombatUnit
	{
		int Capacity { get; }
		int Move { get; }

		int AFBToHit { get; }
		int AFBDiceCount { get; }

		int BombardToHit { get; }
		int BombardDiceCount { get; }

		bool DisablePlanetaryShield { get; }

		int SpaceCannonToHit { get; }
		int SpaceCannonDiceCount { get; }
	}
}
