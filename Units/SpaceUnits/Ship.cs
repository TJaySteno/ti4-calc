namespace ti4_calc.Units.SpaceUnits
{
	public class Ship
	{
		internal int Count { get; private set; }
		internal int AliveCount { get; private set; }
		internal int CanSustainDamage { get; private set; } = 0;
		
		internal IShip Type { get; private set; }

		internal Ship(int count, IShip type)
		{
			if (count > type.Reinforcements)
				throw new ReinforcementsException(type.Name, type.Reinforcements);
			
			Type = type;
			Count = count;
			AliveCount = count;
			if (type.SpecialAbilitySustainDamage)
				CanSustainDamage = count;
		}

		public void ResetShip()
		{
			AliveCount = Count;
			if (Type.SpecialAbilitySustainDamage)
				CanSustainDamage = Count;
		}

		// Returns a negative number if there are still hits remaining after sustaining damage.
		public int SustainDamage(int hits) => CanSustainDamage -= hits;
			

		// Returns a negative number if there are still hits remaining after losing units.
		public int LoseShips(int hits)
		{
			if (CanSustainDamage > 0 /* Later: || Direct Hit */) throw new SustainDamageException(Type.Name);
			return AliveCount -= hits;
		}
		
		public string PrintUnit() => $" {Count} {Type.Name}{(Count > 1 ? "s" : "")},";
	}
}
