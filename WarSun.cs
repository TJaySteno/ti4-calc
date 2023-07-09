namespace ti4_calc
{
	internal class WarSun : Unit
	{
		private readonly bool _isMuaat = false;
		private readonly bool _isMuaatUpgraded = false;

		public WarSun(string faction, bool upgraded = false)
		{
			_isMuaat = faction == "Muaat";
			_isMuaatUpgraded = faction == "Muaat" && upgraded;

			if (!_isMuaat && !upgraded) { throw new CannotBuildWarSunException("War Suns cannot be built until the War Sun Technology is researched."); }

			SetUnitBaseStats(_isMuaatUpgraded ? 10 : 12, 2);
			SetCombatToHit(3);
			SetCombatNumberOfDice(3);
			SetUnitCapacity(6);
			ActivateSustainDamage();
			
			SetSpecialText("Other players' units in this system lose their Planetary Shield ability");
			ActivateBypassPlanetaryShield();

			// SetSpecialAttack
			SetSpecialAttackType("Bombard");
			SetSpecialAttackToHit(3);
			SetSpecialAttackNumberOfDice(3);

			// SetUnitMove
			if (_isMuaatUpgraded) SetUnitMove(3);
			else if (upgraded) SetUnitMove(2);
			else if (_isMuaat) SetUnitMove(1);
		}

		// UpgradeWarSun() ???
	}
}
