using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti4_calc
{
	internal class Carrier : Unit
	{
		private bool _isSol = false;

		
		public Carrier(string faction, bool upgraded = false)
		{
			_isSol = faction == "Sol";

			SetUnitBaseStats(3, 4);
			SetCombatToHit(9);

			if (upgraded) {
				SetUnitMove(2);
			} else {
				SetUnitMove(1);
			}

			if (_isSol && upgraded) {
				SetUnitCapacity(8);
				ActivateSustainDamage();
			} else if (_isSol || upgraded) {
				SetUnitCapacity(6);
			} else {
				SetUnitCapacity(4);
			}
		}

		// UpgradeCarrier() ???
	}
}
