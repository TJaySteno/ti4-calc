using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Policy;

namespace ti4_calc.Units.GroundUnits
{
	internal class Mech : IArmy, IPlanetaryShield
	{
		// IArmy properties
		public string Name { get; } = "Mech";
		public bool Upgraded { get; } = false;
		public int Reinforcements { get; } = 4;

		public double Cost { get; } = 2;
		public int CombatToHit { get; private set; } = 6;
		public int CombatDiceCount { get; private set; } = 1;
		public bool SpecialAbilitySustainDamage { get; private set; } = true;
		public bool IgnoreDirectHit { get; } = false;

		public int CapacityCost { get; } = 1;
		// IArmy properties


		// IBombardment properties
		public int BombardToHit { get; private set; } = 0;
		public int BombardDiceCount { get; private set; } = 0;
		// IBombardment properties


		// IPlanetaryShield properties
		public bool PlanetaryShield { get; private set; } = false;
		// IPlanetaryShield properties


		// ISpaceCannon properties
		public int SpaceCannonToHit { get; private set; } = 0;
		public int SpaceCannonDiceCount { get; private set; } = 0;
		// ISpaceCannon properties


		// Other properties
		public string Deploy { get; private set; }
		public string SpecialText { get; private set; }
		// Other properties



		public Mech(string faction, bool spaceCombat = false)
		{
			if (faction == "Arborec") Arborec();
			else if (faction == "Argent") Argent();
			else if (faction == "Barony") Barony();
			else if (faction == "Keleres") Keleres();
			else if (faction == "Saar") Saar();
			else if (faction == "Muaat") Muaat();
			else if (faction == "Hacan") Hacan();
			else if (faction == "Empyrean") Empyrean();
			else if (faction == "Sol") Sol();
			else if (faction == "Ghosts") Ghosts();
			else if (faction == "L1Z1X") L1Z1X();
			else if (faction == "Mahact") Mahact();
			else if (faction == "Mentak") Mentak();
			else if (faction == "Naalu") Naalu();
			else if (faction == "NRA") NRA(spaceCombat);
			else if (faction == "Nekro") Nekro();
			else if (faction == "Nomad") Nomad();
			else if (faction == "Sardakk") Sardakk();
			else if (faction == "Titans") Titans();
			else if (faction == "JolNar") JolNar();
			else if (faction == "VuilRaith") VuilRaith();
			else if (faction == "Winnu") Winnu();
			else if (faction == "Xxcha") Xxcha();
			else if (faction == "Yin") Yin();
			else if (faction == "Yssaril") Yssaril();
		}

		private void Arborec()
		{
			Deploy = "When you use MITOSIS faction ability you may replace 1 of your infantry with 1 mech from your reinforcements instead";
		}
		private void Argent()
		{
			SpecialText = "This unit does not count against capacity if it is being transported or if it is in a space area with 1 or more of your ships that has capacity values.";
		}
		private void Barony()
		{
			Deploy = "At the start of a round of ground combat, you may spend 2 resources to replace 1 of your infantry in that combat with 1 mech.";
		}
		private void Keleres()
		{
			SpecialText = "Other players must spend 1 influence to commit ground forces to the planet that contains this unit.";
		}
		private void Saar()
		{
			Deploy = "After you gain control of a planet, you may spend 1 trade good to place 1 mech on that planet.";
		}
		private void Muaat()
		{
			SpecialText = "When you use your STAR FORGE faction ability in this system or an adjacent system, you may place 1 infantry from your reinforcements with this unit.";
		}
		private void Hacan()
		{
			SpecialText = "This planet's card may be traded as part of a transaction; if you do, move all of your units from this planet to another planet you control.";
		}
		private void Empyrean()
		{
			SpecialText = "You may remove this unit from a system that contains or is adjacent to another player's units to cancel an action card played by that player.";
		}
		private void Sol()
		{
			Deploy = "After you use your ORBITAL DROP faction ability you may spend 3 resources to place 1 mech on that planet.";
		}
		private void Ghosts()
		{
			SpecialText = "After any player activates a system, you may remove this unit from the game board to place or move a Creuss wormhole token into this system.";
		}
		private void L1Z1X()
		{
			BombardToHit = 8;
			BombardDiceCount = 1;

			SpecialText = "While not participating in ground combat, this unit can use its BOMBARDMENT ability on planets in its system as if it were a ship.";

		}
		private void Mahact()
		{
			SpecialText = "After a player whose command token is in your fleet pool activates this system, you may spend their token from your fleet pool to end their turn; they gain that token.";
		}
		private void Mentak()
		{
			SpecialText = "Other players' ground forces on this planet cannot use SUSTAIN DAMAGE.";
		}
		private void Naalu()
		{
			SpecialText = "During combat against an opponent who has at least 1 relic fragment, apply +2 to the results of this unit's combat rolls.";
			// Omega text?
		}
		private void NRA(bool SpaceCombat = false)
		{
			CombatDiceCount = 2;

			if (SpaceCombat)
			{
				CombatToHit = 8;
				SpecialAbilitySustainDamage = false;

				SpecialText = "If this unit is in the space area of the active system, it is also a ship. At the end of a space battle in the active system, flip this card.";
			}
			else
			{
				SpecialText = "If this unit is in the space area of the active system at the start of a space combat, flip this card.";
			}
		}
		private void Nekro()
		{
			SpecialText = "During combat against an opponent who has an \"X\" or \"Y\" token on 1 or more of their technologies, apply +2 to the result of each of this unit's combat rolls.";
		}
		private void Nomad()
		{
			SpecialText = "While this unit is in a space area during combat, you may use its SUSTAIN DAMAGE ability to cancel a hit that is produced against your ships in this system.";
		}
		private void Sardakk()
		{
			SpecialText = "After this unit uses its SUSTAIN DAMAGE ability during Ground Combat, it produces 1 hit against your opponent's ground forces on this planet.";
		}
		private void Titans()
		{
			Deploy = "When you would place a PDS on a planet, you may place 1 mech and 1 infantry on that planet instead.";
		}
		private void JolNar()
		{
			// Implement this
			SpecialText = "Your infantry on this planet are not affected by your FRAGILE faction ability.";
		}
		private void VuilRaith()
		{
			SpecialText = "When your infantry on this planet are destroyed, place them on your faction sheet; those units are captured.";
		}
		private void Winnu()
		{
			SpecialText = "After you resolve a tactical action where you gained control of this planet, you may place 1 PDS or 1 Space Dock from your reinforcements on this planet.";
		}
		private void Xxcha()
		{
			SpaceCannonToHit = 8;
			SpaceCannonDiceCount = 1;

			SpecialText = "You may use this unit's SPACE CANNON against ships that are in adjacent systems.";
		}
		private void Yin()
		{
			Deploy = "When you use your INDOCTRINATION faction ability, you may spend 1 additional influence to replace your opponent's unit with 1 mech instead of 1 infantry.";
		}
		private void Yssaril()
		{
			Deploy = "After you use your STALL TACTICS faction ability, you may place 1 mech on a planet you control.";
		}
	}
}