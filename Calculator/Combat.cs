using System;
using System.Collections.Generic;
using System.Linq;

namespace ti4_calc
{
	internal class Combat
	{
		private List<PlayerShip> _attackingFleet;
		private List<PlayerShip> _defendingFleet;

		private static readonly Random random = new Random();
		private static readonly object syncLock = new object();

		internal static int Roll()
		{
			lock (syncLock)
			{
				return random.Next(11);
			}
		}

		private int RollToHit(int numberOfDice, int toHit)
		{
			// Implement Player.FactionCombatModifier
			// JolNaar Mech affects this too
			
			int numberOfHits = 0;
			while (numberOfDice > 0)
			{
				if (Roll() >= toHit) numberOfHits++;
				numberOfDice--;
			}
			return numberOfHits;
		}

		private int GetRemainingUnitCount(List<PlayerShip> fleet)
		{
			int count = 0;
			fleet.ForEach(u => count += u.AliveCount);
			return count;
		}

		private int TakeShots(List<PlayerShip> fleet)
		{
			int hits = 0;
			fleet.ForEach(delegate (PlayerShip unit) {
				// Check to see if any units have 2+ dice per attack.
				int numberOfDice = unit.AliveCount * unit.Ship.CombatDiceCount;
				hits += RollToHit(numberOfDice, unit.Ship.CombatToHit);
			});
			return hits;
		}

		private int SustainDamage(List<PlayerShip> fleet, int hits)
		{
			// Implement Direct Hit later, once this is up and running.
			
			PlayerShip unit;

			while (hits > 0 && fleet.Exists(u => u.CanSustainDamage > 0))
			{
				// Find the last set of units.
				unit = fleet.FindLast(delegate (PlayerShip u) { return u.CanSustainDamage > 0; });

				// Units sustain damage; when more hits remain, LoseUnits returns a negative number.
				hits = -unit.SustainDamage(hits);
			}
			return hits;
		}

		private int TakeHits(List<PlayerShip> fleet, int hits)
		{
			PlayerShip unit;

			while (hits > 0 && fleet.Exists(u => u.AliveCount > 0))
			{
				// Find the last set of units.
				unit = fleet.FindLast(delegate (PlayerShip u) { return u.AliveCount > 0; });

				// Remove units; when more hits remain, LoseUnits returns a negative number.
				hits = -unit.LoseUnits(hits);
			}

			return GetRemainingUnitCount(fleet);

			// Add a default sort order for units later on. e.g. dread = 1, fighters = 2, etc. 
				// Add a way to override these. e.g. dread near the end unless upgraded.
				// units.FindAll().FindLast() ?
		}

		private string RoundOfCombat(Player attacker, Player defender)
		{
			if (!attacker.Fleet.Any() || !defender.Fleet.Any())
				throw new Exception("Both fleets must have ships");

			// Find number of hits per player
			int _attackerNumberOfHits = TakeShots(attacker.Fleet);
			int _defenderNumberOfHits = TakeShots(defender.Fleet);

			// Sustain damage and recalculate remaining hits
			if (defender.FleetCanSustainDamage())
			{
				_attackerNumberOfHits = SustainDamage(defender.Fleet, _attackerNumberOfHits);
			}
				
			if (attacker.FleetCanSustainDamage())
			{
				
				_defenderNumberOfHits = SustainDamage(attacker.Fleet, _defenderNumberOfHits);
			}

			// Assign hits to each player's units
			int _attackingFleetRemaining = TakeHits(_attackingFleet, _defenderNumberOfHits);
			int _defendingFleetRemaining = TakeHits(_defendingFleet, _attackerNumberOfHits);

			// Check for end
			if (_attackingFleetRemaining <= 0 && _defendingFleetRemaining <= 0) return "Draw";
			if (_attackingFleetRemaining <= 0) return "Defensive Victory";
			if (_defendingFleetRemaining <= 0) return "Offensive Victory";
			else return "Ongoing";
		}

		public string DoBattle(Player attacker, Player defender)
		{
			string _combatStatus = "Ongoing";

			_attackingFleet = attacker.Fleet;
			_defendingFleet = defender.Fleet;

			// Pre-combat
			// Attacks (Bombardment, PDS, AFB)

			// Regular combat
			while (_combatStatus == "Ongoing")
			{ 
				_combatStatus = RoundOfCombat(attacker, defender);
			}

			return _combatStatus;
		}
	}
}