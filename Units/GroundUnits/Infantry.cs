namespace ti4_calc.Units.GroundUnits
{
	internal class Infantry : IArmy, ICapacityCost
	{
		// IUnit
		public string Name { get; } = "Infantry";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 12;
		public string SpecialText { get; private set; }
		// IUnit

		// ICombatUnit
		public double Cost { get; } = 0.5;
		public int CombatToHit { get; private set; } = 8;
		public int CombatDiceCount { get; } = 1;
		public bool SpecialAbilitySustainDamage { get; } = false;
		public bool IgnoreDirectHit { get; } = false;
		// ICombatUnit

		// ICapacityCost
		public int CapacityCost { get; } = 1;
		// ICapacityCost


		public Infantry(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			if (faction == "Mahact")
				SpecialText = "After this unit is destroyed, gain 1 commodity or convert 1 of your commodities to a trade good.";

			if (upgraded)
			{
				CombatToHit = 7;

				if (faction == "Mahact")
					SpecialText += " Then, place the unit on this card. At the start of your next turn, place each unit that is on this card on a planet you control in your home system.";
				else
					SpecialText = $"After this unit is destroyed, roll 1 die. If the result is {(faction == "Sol" ? 5 : 6)} or greater, place the unit on this card. At the start of your next turn, place each unit that is on this card on a planet you control in your home system.";
			}
		}
	}
}