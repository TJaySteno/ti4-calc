/*namespace ti4_calc
{
	internal class Flagship : Unit
	{
		public Flagship(string faction, bool upgraded = false)
		{
			// Constants
			SetUnitBaseStats(faction, upgraded, 8, 1);
			ActivateSustainDamage();

			// SetUnitMove
			if (faction == "Yssaril" || (faction == "Nomad" && upgraded)) SetUnitMove(2);
			else SetUnitMove(1);

			// SetUnitCapacity
			if (faction == "Sol") SetUnitCapacity(12);
			else if (faction == "Keleres" || faction == "Naalu" || (faction == "Nomad" && upgraded)) SetUnitCapacity(6);
			else if (faction == "Arborec" || faction == "LIZIX") SetUnitCapacity(5);
			else if (faction == "Naaz") SetUnitCapacity(4);
			else SetUnitCapacity(3);

			// SetCombatToHit
			if (faction == "Arborec" || faction == "Argent" || faction == "Keleres" || faction == "Hacan" || faction == "Mentak" || (faction == "Nomad" && !upgraded) || faction == "Titans" || faction == "Winnu" || faction == "Xxcha")
				SetCombatToHit(7);
			else if (faction == "Naalu" || faction == "Naaz" || faction == "Nekro" || faction == "Yin") SetCombatToHit(9);
			else if (faction == "Sardakk" || faction == "Jol-Nar") SetCombatToHit(6);
			else SetCombatToHit(5);

			// SetCombatNumberOfDice
			if (faction != "Ghosts" && faction != "Winnu") SetCombatNumberOfDice(2);

			// SetSpecialText
			if (faction == "Arborec") SetSpecialText("After you activate this system, you may produce up to 5 units in this system.");
			if (faction == "Argent") SetSpecialText("Other players cannot use SPACE CANNON against your ships in this system.");
				// ActivateBypassSpace Cannon()???
			if (faction == "Barony") SetSpecialText("Other players' units in this system lose PLANETARY SHIELD. At the start of each space combat round, repair this ship.");
			if (faction == "Keleres") SetSpecialText("Other players must spend 2 influence to activate the system that contains this ship.");
			if (faction == "Muaat") SetSpecialText("ACTION: Spend 1 token from your strategy pool to place 1 cruiser in this unit's system.");
			if (faction == "Hacan") SetSpecialText("After you roll a die during space combat in this system, you may spend 1 trade good to apply +1 to the result.");
			if (faction == "Empyrean") SetSpecialText("After any player's unit in this system or an adjacent system uses SUSTAIN DAMAGE, you may spend 2 influence to repair that unit.");
			if (faction == "Sol") SetSpecialText("At the end of the status phase, place 1 infantry from your reinforcements in this system's space area.");
			if (faction == "Ghosts") SetSpecialText("This ship's system contains a delta wormhole. During movement, this ship may move before or after your other ships.");
			if (faction == "LIZIX") SetSpecialText("During a space combat, hits produced by this ship and by your dreadnoughts in this system must be assigned to non-fighter ships if able.");
			if (faction == "Mahact") SetSpecialText("During combat against an opponent whose command token is not in your fleet pool, apply +2 to the results of this unit's combat rolls.");
			if (faction == "Mentak") SetSpecialText("Other players' ships in this system cannot use SUSTAIN DAMAGE.");
			if (faction == "Naalu") SetSpecialText("During an invasion in this system, you may commit fighters to planets as if they were ground forces. When combat ends, return those units to the space area.");
			if (faction == "Naaz") SetSpecialText("Your mechs in this system roll 1 additional die during combat.");
			if (faction == "Nekro") SetSpecialText("At the start of a space combat, choose any number of your ground forces in this system to participate in that combat as if they were ships.");
			if (faction == "Nomad") SetSpecialText("You may treat this unit as if it were adjacent to systems that contain one or more of your mechs.");
			if (faction == "Sardakk") SetSpecialText("Apply +1 to the result of each of your other ship's combat rolls in this system.");
			if (faction == "Titans") SetSpecialText("DEPLOY: After you activate a system that contains 1 or more of your PDS, you may replace 1 of those PDS with this unit.");
			if (faction == "Jol-Nar") SetSpecialText("When making a combat roll for this ship, each result of a 9 or 10, before applying modifiers, produces 2 additional hits.");
			if (faction == "Cabal") SetSpecialText("Capture all other non-structure units that are destroyed in this unit's system, including your own.");
			if (faction == "Winnu") SetSpecialText("When this unit makes a combat roll, it rolls a number of dice equal to the number of your opponent's non-fighter ships in this system.");
			if (faction == "Xxcha") SetSpecialText("You may use this unit's SPACE CANNON against ships that are in adjacent systems.");
			if (faction == "Yin") SetSpecialText("When this ship is destroyed, destroy all ships in this system.");
			if (faction == "Yssaril") SetSpecialText("This ship can move through systems that contain other player's ships.");

			// SetSpecialAttack
			if (faction == "Saar")
			{
				SetSpecialAttackType("Anti-Fighter Barrage");
				SetSpecialAttackToHit(6);
				SetSpecialAttackNumberOfDice(4);
			}
			if (faction == "Nomad")
			{
				SetSpecialAttackType("Anti-Fighter Barrage");
				SetSpecialAttackNumberOfDice(3);

				if (upgraded) SetSpecialAttackToHit(5);
				else SetSpecialAttackToHit(8);
			}
			if (faction == "Barony")
			{
				SetSpecialAttackType("Bombardment");
				SetSpecialAttackToHit(5);
				SetSpecialAttackNumberOfDice(3);
			}
			if (faction == "Cabal")
			{
				SetSpecialAttackType("Bombardment");
				SetSpecialAttackToHit(5);
				SetSpecialAttackNumberOfDice(1);
			}
			if (faction == "Xxcha")
			{
				SetSpecialAttackType("Space Cannon");
				SetSpecialAttackToHit(5);
				SetSpecialAttackNumberOfDice(3);
			}

			// ActivateBypassPlanetaryShield
			if (faction == "Barony") ActivateBypassPlanetaryShield();
		}

		public override Unit Clone(string faction, bool upgraded = false)
		{
			throw new System.NotImplementedException();
		}

		// UpgradeFlagship() ???
	}
}
*/