using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti4_calc
{
	internal class Flagship : Unit
	{
		public Flagship(string faction, bool upgraded = false)
		{
			// Defaults, chosen from the most common values.
			SetUnitBaseStats(8, 1);
			SetUnitMove(1);
			SetUnitCapacity(3);
			SetCombatToHit(5);
			SetCombatNumberOfDice(2);
			ActivateSustainDamage();

			if (faction == "Arborec")
			{
				SetCombatToHit(7);
				SetUnitCapacity(5);
				SetSpecialText("After you activate this system, you may produce up to 5 units in this system.");
			}
			if (faction == "Argent")
			{
				SetCombatToHit(7);
				SetSpecialText("Other players cannot use SPACE CANNON against your ships in this system.");
			}
			if (faction == "Barony")
			{
				SetSpecialText("Other players' units in this system lose PLANETARY SHIELD. At the start of each space combat round, repair this ship.");

				SetSpecialAttackType("Bombard");
				SetSpecialAttackToHit(5);
				SetSpecialAttackNumberOfDice(3);
			}
			if (faction == "Saar")
			{
				SetSpecialAttackType("AFB");
				SetSpecialAttackToHit(6);
				SetSpecialAttackNumberOfDice(4);
			}
			if (faction == "Keleres")
			{
				SetCombatToHit(7);
				SetUnitCapacity(6);
				SetSpecialText("Other players must spend 2 influence to activate the system that contains this ship.");
			}
			if (faction == "Muaat")
			{
				SetSpecialText("ACTION: Spend 1 token from your strategy pool to place 1 cruiser in this unit's system.");
			}
			if (faction == "Hacan")
			{
				SetCombatToHit(7);
				SetSpecialText("After you roll a die during space combat in this system, you may spend 1 trade good to apply +1 to the result.");
			}
			if (faction == "Empyrean")
			{
				SetSpecialText("After any player's unit in this system or an adjacent system uses SUSTAIN DAMAGE, you may spend 2 influence to repair that unit.");
			}
			if (faction == "Sol")
			{
				SetUnitCapacity(12);
				SetSpecialText("At the end of the status phase, place 1 infantry from your reinforcements in this system's space area.");
			}
			if (faction == "Ghosts")
			{
				SetCombatNumberOfDice(1);
				SetSpecialText("This ship's system contains a delta wormhole. During movement, this ship may move before or after your other ships");
			}
			if (faction == "LIZIX")
			{
				SetUnitCapacity(5);
				SetSpecialText("During a space combat, hits produced by this ship and by your dreadnoughts in this system must be assigned to non-fighter ships if able.");
			}
			if (faction == "Mahact")
			{
				SetSpecialText("During combat against an opponent whose command token is not in your fleet pool, apply +2 to the results of this unit's combat rolls.");
			}
			if (faction == "Mentak")
			{
				SetCombatToHit(7);
				SetSpecialText("Other players' ships in this system cannot use SUSTAIN DAMAGE");
			}
			if (faction == "Nalu")
			{
				SetCombatToHit(9);
				SetUnitCapacity(6);
				SetSpecialText("During an invasion in this system, you may commit fighters to planets as if they were ground forces. When combat ends, return those units to the space area.");
			}
			if (faction == "Naaz")
			{
				SetCombatToHit(9);
				SetUnitCapacity(4);
				SetSpecialText("Your mechs in this system roll 1 additional die during combat");
			}
			if (faction == "Nekro")
			{
				SetCombatToHit(9);
				SetSpecialText("At the start of a space combat, choose any number of your ground forces in this system to participate in that combat as if they were ships.");
			}
			if (faction == "Nomad")
			{
				SetCombatNumberOfDice(2);
				SetSpecialText("You may treat this unit as if it were adjacent to systems that contain one or more of your mechs.");

				SetSpecialAttackType("AFB");
				SetSpecialAttackNumberOfDice(3);

				if (upgraded)
				{
					SetUnitMove(2);
					SetUnitCapacity(6);
					SetSpecialAttackToHit(5);
				}
				else
				{
					SetCombatToHit(7);
					SetSpecialAttackToHit(8);
				}

				// UpgradeFlagship() ???
			}
			if (faction == "Sardakk")
			{
				SetCombatToHit(6);
				SetSpecialText("Apply +1 to the result of each of your other ship's combat rolls in this system.");
			}
			if (faction == "Titans")
			{
				SetCombatToHit(7);
				SetSpecialText("DEPLOY: After you activate a system that contains 1 or more of your PDS, you may replace 1 of those PDS with this unit");
			}
			if (faction == "Jol-Nar")
			{
				SetCombatToHit(6);
				SetSpecialText("When making a combat roll for this ship, each result of a 9 or 10, before applying modifiers, produces 2 additional hits.");
			}
			if (faction == "Cabal")
			{
				SetSpecialText("Capture all other non-structure units that are destroyed in this unit's system, including your own.");

				SetSpecialAttackType("Bombard");
				SetSpecialAttackToHit(5);
				SetSpecialAttackNumberOfDice(1);
			}
			if (faction == "Winnu")
			{
				SetCombatToHit(7);
				SetCombatNumberOfDice(1);
				SetSpecialText("When this unit makes a combat roll, it rolls a number of dice equal to the number of your opponent's non-fighter ships in this system.");
			}
			if (faction == "Xxcha")
			{
				SetCombatToHit(7);
				SetSpecialText("You may use this unit's SPACE CANNON against ships that are in adjacent systems.");

				SetSpecialAttackType("Space Cannon");
				SetSpecialAttackToHit(5);
				SetSpecialAttackNumberOfDice(3);
			}
			if (faction == "Yin")
			{
				SetCombatToHit(9);
				SetSpecialText("When this ship is destroyed, destroy all ships in this system.");
			}
			if (faction == "Yssaril")
			{
				SetSpecialText("This ship can move through systems that contain other player's ships.");
			}
		}
	}
}
