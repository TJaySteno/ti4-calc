namespace ti4_calc
{
	internal class Cruiser : IUnit
	{
		public string Name { get; } = "Cruiser";
		public int Health { get; private set; } = 1;
		public int ToHit { get; private set; } = 7;

		// public int Capacity { get; private set; } = 0;

		// public int Reinforcements { get; } = 8;

		// public int Cost { get; } = 2;
		// public int Move { get; private set; } = 2;

		// private readonly bool _isTitans;

		/*public Cruiser(string faction, bool upgraded = false)
		{
			_isTitans = faction == "Titans";

			if (upgraded)
			{
				Move = 3;
				ToHit = 6;
			}

			if (_isTitans && upgraded)
			{
				Capacity = 2;
				BaseHealth = 2;
			}
			else if (_isTitans || upgraded)
			{
				Capacity = 1;
			}
		}*/

		/*public void UpgradeUnit()
		{
			Move = 3;
			ToHit = 6;

			if (_isTitans)
			{
				Capacity = 2;
				BaseHealth = 2;
			}
			else
			{
				Capacity = 1;
			}
		}*/

		/*public void DowngradeUnit()
		{
			Move = 2;
			ToHit = 7;

			if (_isTitans) { Capacity = 1; }
			else { Capacity = 0; }
		}*/
	}
}
