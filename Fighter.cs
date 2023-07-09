using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti4_calc
{
	internal class Fighter : Unit
	{
		private bool _isNaalu = false;

		public Fighter(string faction, bool upgraded = false)
		{
			_isNaalu = faction == "Naalu";

			SetUnitBaseStats(0.5, 10);

			if (upgraded && _isNaalu) { SetCombatToHit(7); }
			else if (upgraded || _isNaalu) { SetCombatToHit(8); }
			else { SetCombatToHit(9); }

			if (upgraded) {
				SetUnitMove(2);
				
				SetSpecialText("This unit may move without being transported.");
				if (_isNaalu) { AppendSpecialText("Each fighter in excess of your ships' capacity counts as 1/2 of a ship against your fleet pool."); }
				else { AppendSpecialText("Each fighter in excess of your ships' capacity counts as 1/2 of a ship against your fleet pool."); }
			}
			else
			{
				SetUnitMove(0);
			}
		}

		// UpgradeFighter() ???
	}
}
