namespace ti4_calc
{
	internal class Cruiser : Unit
	{
		private bool _isTitans = false;
		public Cruiser(string faction, bool upgraded = false)
		{
			_isTitans = faction == "Titans";

			if (upgraded) {
				SetUnitMove(3);
				SetCombatToHit(6);
			}

			if (_isTitans && upgraded) {
				SetUnitCapacity(2);
				ActivateSustainDamage();
			} else if (_isTitans || upgraded) {
				SetUnitCapacity(1);
			}
		}

		// UpgradeCruiser() ???
	}
}
