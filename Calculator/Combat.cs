using System;
using System.Collections.Generic;
using System.Linq;
using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class Combat
	{
		private readonly Player Attacker;
		private readonly Player Defender;
		private readonly string CombatType;

		internal Combat(Player attacker, Player defender, string combatType)
		{
			if (combatType != "space" && combatType != "ground")
				throw new CombatTypeException(combatType);

			Attacker = attacker;
			Defender = defender;
			CombatType = combatType;
		}


		// Dice rolls
		private static readonly Random random = new Random();
		private static readonly object syncLock = new object();

		internal static int Roll()
		{
			lock (syncLock)
				return random.Next(11);
		}

		private int RollToHit(int numberOfDice, int toHit)
		{
			// Later: Implement Player.FactionCombatModifier
			// Later: JolNaar Mech affects this too

			int numberOfHits = 0;
			for (int i = 0; i < numberOfDice; i++)
				if (Roll() >= toHit) numberOfHits++;
			return numberOfHits;
		}
		// Dice rolls


		// Assign hits
		private int SustainDamage(List<Ship> fleet, int hits)
		{
			// Later: Direct Hit
			// Later: Order hits

			Ship ship;

			while (hits > 0 && fleet.Exists(s => s.CanSustainDamage > 0))
			{
				// Find the last set of units.
				ship = fleet.FindLast(u => u.CanSustainDamage > 0);

				// Units sustain damage; when more hits remain, LoseShips returns a negative number.
				hits = -ship.SustainDamage(hits);
			}
			return hits;
		}

		private bool FleetStillExists(List<Ship> fleet, string target = null)
			=> fleet.Exists(
				s => (target == null || target == s.Type.Name) && s.AliveCount > 0);

		private void TakeHits(List<Ship> fleet, int hits, string target)
		{
			/* Later: Orders to take hits in.
			 *   Default e.g. dread = 1, fighters = 2, etc.
			 *   Add a way to override these. e.g. dread near the end unless upgraded.
			 */

			Ship ship;

			while (hits > 0 && FleetStillExists(fleet, target))
			{
				// Find the last set of units.
				ship = fleet.FindLast(delegate (Ship s) { return s.AliveCount > 0; });

				// Remove units; when more hits remain, LoseShips returns a negative number.
				hits = -ship.LoseShips(hits);
			}
		}

		/*private int GetRemainingUnitCount(List<Ship> fleet)
		{
			int count = 0;
			fleet.ForEach(s => count += s.AliveCount);
			return count;
		}*/

		private void AssignHits(Player player, int hits, string target = null)
		{
			// Later: pass in "Ship ship" instead of "string target" for these methods?
			
			if (player.FleetCanSustainDamage(target))
				hits = SustainDamage(player.Fleet, hits);

			TakeHits(player.Fleet, hits, target);
		}
		// Assign hits


		// Pre-combat
		private int SpaceCannonPhase(Player player, bool enemyHasArgentFlagship)
		{
			if (enemyHasArgentFlagship)
				{ return 0; }

			int hits = 0;

			if (CombatType == "space")
			{
				// Fire PDS.
				if (player.PDS.Count > 0)
					hits += RollToHit(player.PDS.Count, player.PDS.SpaceCannonToHit);

				// Fire any Space Cannons in the fleet.
				player.Fleet.ForEach(delegate (Ship ship) {
					if (ship.Type.SpaceCannonToHit > 0)
					{
						hits += RollToHit(
							ship.AliveCount * ship.Type.SpaceCannonDiceCount,
							ship.Type.SpaceCannonToHit
						);
					}
				});
				
			}
			else if (CombatType == "space")
			{
				/* Space Cannon Defense, ground combat
				 *   1. armiesDestroyed += Roll() >= SpaceCannonToHit
				 *   2. (Any hits destroy an army; sustain??)
				 *   3. (This only works from the planet you're attacking.)
				 *     a. Usually limited to 2 PDS/combat.
				 *     b. Attackers can never use this.
				 *   4. Argent Flagship disables Space Cannon
				 */
			}
			else throw new CombatTypeException(CombatType);
			return hits;
		}

		private int UseAntiFighterBarrage(List<Ship> fleet)
		{
			if (!fleet.Exists(s => s.Type.AFBToHit > 0))
				{ return 0; }

			int hits = 0;
			fleet.ForEach(delegate (Ship ship)
			{
				if (ship.Type.AFBToHit > 0)
				{
					hits += RollToHit(
						ship.AliveCount * ship.Type.AFBDiceCount,
						ship.Type.AFBToHit
					);
				}
			});
			return hits;
		}

		private int UseBombardment()
		{
			// Later:
			return 1;
		}

		private string PreCombat()
		{
			string _combatStatus = "Ongoing";
			int _attackersHits = 0;
			int _defendersHits = 0;

			if (CombatType == "space")
			{
				// Space Cannon
				_attackersHits += SpaceCannonPhase(
					Attacker,
					Defender.Faction == "Argent" && Defender.Fleet.Exists(s => s.Type.Name == "Flagship")
				);
				_defendersHits += SpaceCannonPhase(
					Defender,
					Attacker.Faction == "Argent" && Attacker.Fleet.Exists(s => s.Type.Name == "Flagship")
				);

				AssignHits(Attacker, _defendersHits);
				AssignHits(Defender, _attackersHits);
				// Later: does this need to specify ships vs ground?
				// Space Cannon

				_attackersHits = 0;
				_defendersHits = 0;

				// Anti-Fighter Barrage
				if (Attacker.Fleet.Exists(s => s.Type.AFBToHit > 0))
					_attackersHits += UseAntiFighterBarrage(Attacker.Fleet);
				if (Defender.Fleet.Exists(s => s.Type.AFBToHit > 0))
					_defendersHits += UseAntiFighterBarrage(Defender.Fleet);

				AssignHits(Attacker, _defendersHits, "Fighter");
				AssignHits(Defender, _attackersHits, "Fighter");
				// Anti-Fighter Barrage
			}
			else if (CombatType == "ground")
			{

			}
			else throw new CombatTypeException(CombatType);

			return _combatStatus;
		}
		// Pre-Combat


		// Regular Combat
		private int TakeShots(List<Ship> fleet)
		{
			int hits = 0;
			fleet.ForEach(delegate (Ship ship) {
				hits += RollToHit(
					ship.AliveCount * ship.Type.CombatDiceCount,
					ship.Type.CombatToHit
				);
			});
			return hits;
		}

		private string RoundOfCombat()
		{
			// Find number of hits per player
			int _attackersHits = TakeShots(Attacker.Fleet);
			int _defendersHits = TakeShots(Defender.Fleet);

			// Sustain damage and recalculate remaining hits
			AssignHits(Attacker, _defendersHits);
			AssignHits(Defender, _attackersHits);

			bool _attackingFleetRemains = FleetStillExists(Attacker.Fleet);
			bool _defendingFleetRemains = FleetStillExists(Defender.Fleet);

			// Check for end
			if (!_attackingFleetRemains && !_defendingFleetRemains) return "Draw";
			if (!_attackingFleetRemains) return "Defensive Victory";
			if (!_defendingFleetRemains) return "Offensive Victory";
			else return "Ongoing";
		}
		// Regular Combat


		public string DoBattle()
		{

			if (!Attacker.Fleet.Any() || !Defender.Fleet.Any())
				throw new NoFleetException("Both fleets must have ships to start battle.");

			// Pre-Combat
			string _combatStatus = PreCombat();

			// Regular combat
			while (_combatStatus == "Ongoing")
				_combatStatus = RoundOfCombat();

			return _combatStatus;
		}
	}
}