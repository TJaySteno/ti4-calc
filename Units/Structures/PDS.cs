/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti4_calc
{
	internal class PDS : Unit
	{
		private readonly bool _isTitans = false;

		public PDS(string faction, bool upgraded = false)
		{
			_isTitans = faction == "Titans";

			SetUnitBaseStats(faction, upgraded, 0, 6);
			ActivatePlanetaryShield();
			
			SetSpecialAttackType("Space Cannon");
			SetSpecialAttackToHit(upgraded ? 6 : 5);
			SetSpecialAttackNumberOfDice(1);

			if (upgraded) SetSpecialText("Upgraded PDS gain the Deep Space Cannon ability which allows them to fire Space Cannon Offense into adjacent systems. The system a PDS fires in must be the active system.");

			if (_isTitans)
			{
				SetCombatToHit(upgraded ? 7 : 6);
				SetCombatNumberOfDice(1);
				ActivateSustainDamage();
				SetSpecialText("This unit is treated as both a structure and a ground force. It cannot be transported. Production 1.");
			}
		}

		public override Ship Clone(string faction, bool upgraded = false)
		{
			throw new NotImplementedException();
		}

		// UpgradeCruiser() ???
	}
}
*/