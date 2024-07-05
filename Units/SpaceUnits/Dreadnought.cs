/*namespace ti4_calc
{
	internal class Dreadnought : Unit
	{
		private readonly bool _isSardakk = false;
		private readonly bool _isLIZIX = false;
		private readonly bool _isLIZIXUpgraded = false;

		public Dreadnought(string faction, bool upgraded = false)
		{
			_isSardakk = faction == "Sardakk";
			_isLIZIX = faction == "LIZIX";
			_isLIZIXUpgraded = faction == "LIZIX" && upgraded;

			SetUnitBaseStats(faction, upgraded, 4, 5);
			SetCombatToHit(_isLIZIXUpgraded ? 4 : 5);
			SetCombatNumberOfDice(1);
			SetUnitMove(upgraded ? 2 : 1);
			SetUnitCapacity(_isLIZIX ? 2 : 1);

			ActivateSustainDamage();

			SetSpecialAttackType("Bombardment");
			SetSpecialAttackToHit(_isSardakk || _isLIZIXUpgraded ? 4 : 5);
			SetSpecialAttackNumberOfDice(_isSardakk ? 2 : 1);

			if (upgraded)
			{
				SetSpecialText("\"Direct Hit\" cards are no longer effective against this type of ship.");

				if (_isSardakk) AppendSpecialText("After a round of space combat, you may destroy this unit to destroy up to 2 ships in this system.");
			}
		}

		public override Unit Clone(string faction, bool upgraded = false)
		{
			throw new System.NotImplementedException();
		}

		// UpgradeDreadnought() ???
	}
}
*/