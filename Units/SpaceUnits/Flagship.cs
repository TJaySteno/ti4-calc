using System;
using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class Flagship : IShip
	{
		// IUnit
		public string Name { get; } = "Flagship";
		public bool Upgraded { get; private set; }
		public int Reinforcements { get; } = 1;
		public string SpecialText { get; private set; }
		// IUnit

		// ICombatUnit
		public double Cost { get; } = 8;
		public int CombatToHit { get; private set; }
		public int CombatDiceCount { get; private set; }
		public bool SpecialAbilitySustainDamage { get; } = true;
		public bool IgnoreDirectHit { get; } = false;
		// ICombatUnit

		// IShip
		public int Capacity { get; private set; }
		public int Move { get; private set; }

		public int AFBToHit { get; private set; }
		public int AFBDiceCount { get; private set; }

		public int BombardToHit { get; private set; }
		public int BombardDiceCount { get; private set; }

		public bool DisablePlanetaryShield { get; private set; }

		public int SpaceCannonToHit { get; private set; }
		public int SpaceCannonDiceCount { get; private set; }
		// IShip


		public Flagship(string faction, bool upgraded = false)
		{
			Upgraded = upgraded;

			if (faction == "Arborec")
			{
				CombatToHit = 7;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 5;

				SpecialText = "After you activate this system, you may produce up to 5 units in this system.";
			}
			else if (faction == "Argent")
			{
				CombatToHit = 7;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "Other players cannot use SPACE CANNON against your ships in this system.";
			}
			else if (faction == "Barony")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "Other players' units in this system lose PLANETARY SHIELD. At the start of each space combat round, repair this ship.";
			}
			else if (faction == "Saar")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				AFBToHit = 6;
				AFBDiceCount = 4;
			}
			else if (faction == "Keleres")
			{
				CombatToHit = 7;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 6;

				SpecialText = "Other players must spend 2 influence to activate the system that contains this ship.";
			}
			else if (faction == "Muaat")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "ACTION: Spend 1 token from your strategy pool to place 1 cruiser in this unit's system.";
			}
			else if (faction == "Hacan")
			{
				CombatToHit = 7;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "After you roll a die during space combat in this system, you may spend 1 trade good to apply +1 to the result.";
			}
			else if (faction == "Empyrean")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "After any player's unit in this system or an adjacent system uses SUSTAIN DAMAGE, you may spend 2 influence to repair that unit.";
			}
			else if (faction == "Sol")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 12;

				SpecialText = "At the end of the status phase, place 1 infantry from your reinforcements in this system's space area.";
			}
			else if (faction == "Ghosts")
			{
				CombatToHit = 5;
				CombatDiceCount = 1;
				Move = 1;
				Capacity = 3;

				SpecialText = "This ship's system contains a delta wormhole. During movement, this ship may move before or after your other ships.";
			}
			else if (faction == "L1Z1X")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 5;

				SpecialText = "During a space combat, hits produced by this ship and by your dreadnoughts in this system must be assigned to non-fighter ships if able.";
			}
			else if (faction == "Mahact")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "During combat against an opponent whose command token is not in your fleet pool, apply +2 to the results of this unit's combat rolls";
			}
			else if (faction == "Mentak")
			{
				CombatToHit = 7;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "Other players' ships in this system cannot use SUSTAIN DAMAGE.";
			}
			else if (faction == "Naalu")
			{
				CombatToHit = 9;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 6;

				SpecialText = "During an invasion in this system, you may commit fighters to planets as if they were ground forces. When combat ends, return those units to the space area.";
			}
			else if (faction == "NRA")
			{
				CombatToHit = 9;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 4;

				SpecialText = "Your mechs in this system roll 1 additional die during combat.";
			}
			else if (faction == "Nekro")
			{
				CombatToHit = 9;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "At the start of a space combat, choose any number of your ground forces in this system to participate in that combat as if they were ships.";
			}
			else if (faction == "Nomad")
			{
				if (upgraded)
				{
					CombatToHit = 5;
					Move = 2;
					Capacity = 6;

					AFBToHit = 5;
				}
				else
				{
					CombatToHit = 7;
					Move = 1;
					Capacity = 3;

					AFBToHit = 8;
				}

				CombatDiceCount = 2;
				AFBDiceCount = 3;

				SpecialText = "You may treat this unit as if it were adjacent to systems that contain one or more of your mechs.";
			}
			else if (faction == "Sardakk")
			{
				CombatToHit = 6;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "Apply +1 to the result of each of your other ship's combat rolls in this system.";
			}
			else if (faction == "Titans")
			{
				CombatToHit = 7;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "DEPLOY: After you activate a system that contains 1 or more of your PDS, you may replace 1 of those PDS with this unit.";
			}
			else if (faction == "JolNar")
			{
				CombatToHit = 6;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "When making a combat roll for this ship, each result of a 9 or 10, before applying modifiers, produces 2 additional hits.";
			}
			else if (faction == "VuilRaith")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "Capture all other non-structure units that are destroyed in this unit's system, including your own.";
			}
			else if (faction == "Winnu")
			{
				CombatToHit = 7;
				CombatDiceCount = 1;
				Move = 1;
				Capacity = 3;

				SpecialText = "When this unit makes a combat roll, it rolls a number of dice equal to the number of your opponent's non-fighter ships in this system.";
			}
			else if (faction == "Xxcha")
			{
				CombatToHit = 7;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpaceCannonToHit = 5;
				SpaceCannonDiceCount = 3;

				SpecialText = "You may use this unit's SPACE CANNON against ships that are in adjacent systems.";
			}
			else if (faction == "Yin")
			{
				CombatToHit = 9;
				CombatDiceCount = 2;
				Move = 1;
				Capacity = 3;

				SpecialText = "When this ship is destroyed, destroy all ships in this system.";
			}
			else if (faction == "Yssaril")
			{
				CombatToHit = 5;
				CombatDiceCount = 2;
				Move = 2;
				Capacity = 3;

				SpecialText = "This ship can move through systems that contain other player's ships.";
			}
			else throw new Exception($"This faction does not exist: {faction}");
		}
	}
}