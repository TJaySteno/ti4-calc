/*namespace ti4_calc
{
	internal class Mech : Unit
	{
		public Mech(string faction, bool revised = false)
		{
			SetUnitBaseStats(faction, false, 6, 4);
			SetCombatToHit(6);
			// SetCombatNumberOfDice(1);
			ActivateSustainDamage();

			if (faction == "Arborec") SetSpecialText("DEPLOY: When you use MITOSIS faction ability you may replace 1 of your infantry with 1 mech from your reinforcements instead. Production 2.");
			if (faction == "Argent") SetSpecialText("This unit does not count against capacity if it is being transported or if it is in a space area with 1 or more of your ships that has capacity values.");
			if (faction == "Barony") SetSpecialText("DEPLOY: At the start of a round of ground combat, you may spend 2 resources to replace 1 of your infantry in that combat with 1 mech.");
			if (faction == "Saar") SetSpecialText("DEPLOY: After you gain control of a planet, you may spend 1 trade good to place 1 mech on that planet.");
			if (faction == "Muaat") SetSpecialText("When you use your STAR FORGE faction ability in this system or an adjacent system, you may place 1 infantry from your reinforcements with this unit.");
			if (faction == "Hacan") SetSpecialText("This planet's card may be traded as part of a transaction; if you do, move all of your units from this planet to another planet you control.");
			if (faction == "Empyrean") SetSpecialText("You may remove this unit from a system that contains or is adjacent to another player's units to cancel an action card played by that player.");
			if (faction == "Sol") SetSpecialText("DEPLOY: After you use your ORBITAL DROP faction ability you may spend 3 resources to place 1 mech on that planet.");
			if (faction == "Ghosts") SetSpecialText("After any player activates a system, you may remove this unit from the game board to place or move a Creuss wormhole token into this system.");
			if (faction == "LIZIX") SetSpecialText("While not participating in ground combat, this unit can use its BOMBARDMENT ability on planets in its system as if it were a ship.");
			if (faction == "Mahact") SetSpecialText("After a player whose command token is in your fleet pool activates this system, you may spend their token from your fleet pool to end their turn; they gain that token.");
			if (faction == "Mentak") SetSpecialText("Other players' ground forces on this planet cannot use SUSTAIN DAMAGE.");
			if (faction == "Naalu")
			{
				if (revised) SetSpecialText("Other players cannot use ANTI - FIGHTER BARRAGE against your units in this system.");
				else SetSpecialText("During combat against an opponent who has at least 1 relic fragment, apply +2 to the results of this unit's combat rolls.");
			}
			if (faction == "Naaz") SetSpecialText("If this unit is in the space area of the active system, it is also a ship.");
			if (faction == "Nekro") SetSpecialText("During combat against an opponent who has an \"X\" or \"Y\" token on 1 or more of their technologies, apply +2 to the result of each of this unit's combat rolls.");
			if (faction == "Nomad") SetSpecialText("While this unit is in a space area during combat, you may use its SUSTAIN DAMAGE ability to cancel a hit that is produced against your ships in this system.");
			if (faction == "Sardakk") SetSpecialText("After this unit uses its SUSTAIN DAMAGE ability during Ground Combat, it produces 1 hit against your opponent's ground forces on this planet.");
			if (faction == "Titans") SetSpecialText("DEPLOY: When you would place a PDS on a planet, you may place 1 mech and 1 infantry on that planet instead.");
			if (faction == "Jol-Nar") SetSpecialText("Your infantry on this planet are not affected by your FRAGILE faction ability.");
			if (faction == "Cabal") SetSpecialText("When your infantry on this planet are destroyed, place them on your faction sheet; those units are captured.");
			if (faction == "Winnu") SetSpecialText("After you resolve a tactical action where you gained control of this planet, you may place 1 PDS or 1 Space Dock from your reinforcements on this planet.");
			if (faction == "Xxcha") SetSpecialText("You may use this unit's SPACE CANNON against ships that are in adjacent systems.");
			if (faction == "Yin") SetSpecialText("DEPLOY: When you use your INDOCTRINATION faction ability, you may spend 1 additional influence to replace your opponent's unit with 1 mech instead of 1 infantry.");
			if (faction == "Yssaril") SetSpecialText("DEPLOY: After you use your STALL TACTICS faction ability, you may place 1 mech on a planet you control.");

			// SetSpecialAttack
			// Otherwise, just add a +2 modifier in SpaceCombat.cs?
			if (faction == "Naaz")
			{
				SetSpecialAttackType("Space Combat");
				SetSpecialAttackToHit(8);
				SetSpecialAttackNumberOfDice(2);
			}
			if (faction == "LIZIX" || faction == "Xxcha")
			{
				SetSpecialAttackType("Bombardment");
				SetSpecialAttackToHit(8);
				SetSpecialAttackNumberOfDice(1);
			}

			// ActivatePlanetaryShield
			if (faction == "Arborec") ActivatePlanetaryShield();
		}

		public override Unit Clone(string faction, bool upgraded = false)
		{
			throw new System.NotImplementedException();
		}
	}
}
*/