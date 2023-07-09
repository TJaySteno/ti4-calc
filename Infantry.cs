namespace ti4_calc
{
	internal class Infantry : Unit
	{
		private readonly bool _isArborec = false;
		private readonly bool _isMehact = false;
		private readonly bool _isSol = false;

		public Infantry(string faction, bool upgraded = false)
		{
			_isArborec = faction == "Arborec";
			_isMehact = faction == "Mehact";
			_isSol = faction == "Sol";

			SetUnitBaseStats(0.5, 12);

			// SetCombatToHit
			if (_isSol && upgraded) SetCombatToHit(6);
			else if (_isSol || upgraded) SetCombatToHit(7);
			else SetCombatToHit(8);

			// SetSpecialText
			if (_isMehact)
			{
				SetSpecialText("After this unit is destroyed, gain 1 commodity or convert 1 of your commodities to a trade good.");
				if (upgraded) AppendSpecialText("Then, place the unit on this card. At the start of your next turn, place each unit that is on this card on a planet you control in your home system.");
			}
			else if (upgraded) SetSpecialText("After this unit is destroyed, roll 1 die. If the result is 6 or greater, place the unit on this card. At the start of your next turn, place each unit that is on this card on a planet you control in your home system.");

			if (_isArborec) AppendSpecialText(upgraded ? "Production 2." : "Production 1.");
		}

		// UpgradeInfantry() ???
	}
}
