/*namespace ti4_calc
{
	internal class Destroyer : Unit
	{
		private readonly bool _isArgent = false;

		public Destroyer(string faction, bool upgraded = false)
		{
			_isArgent = faction == "Argent";

			SetUnitBaseStats(faction, upgraded, 1, 8);
			SetUnitMove(2);
			SetSpecialAttackType("Anti-Fighter Barrage");

			SetUnitCapacity(_isArgent ? 1 : 0);

			if (upgraded) {
				SetSpecialAttackToHit(6);
				SetSpecialAttackNumberOfDice(3);
			} else {
				SetSpecialAttackToHit(9);
				SetSpecialAttackNumberOfDice(2);
			}

			if (_isArgent && upgraded) SetCombatToHit(7);
			// SpecialText for this specialAttack. Implement in AFB class.
			else if (_isArgent || upgraded) SetCombatToHit(8);
			else SetCombatToHit(9);
		}

		public override Ship Clone(string faction, bool upgraded = false)
		{
			throw new System.NotImplementedException();
		}

		// UpgradeDestroyer() ???
	}
}
*/