using System;
using System.Collections.Generic;
using System.Linq;

namespace ti4_calc
{

	internal class Combat
	{
		private List<PlayerUnit> _attackingFleet;
		private List<PlayerUnit> _defendingFleet;

		private static readonly Random random = new Random();
		private static readonly object syncLock = new object();

		private static int Roll()
		{
			lock (syncLock)
			{
				return random.Next(11);
			}
    }

	private int RollToHit(int numberOfDice, int toHit)
		{
			int numberOfHits = 0;
			while (numberOfDice > 0)
			{
				if (Roll() >= toHit) numberOfHits++;
				numberOfDice--;
			}
			return numberOfHits;
		}

		private int TakeShots(List<PlayerUnit> fleet)
		{
			int hits = 0;
			fleet.ForEach(delegate (PlayerUnit unit) {
				hits += RollToHit(unit.CurrentCount, unit.Unit.ToHit);
			});
			return hits;
		}

		private int GetRemainingUnitCount(List<PlayerUnit> fleet)
		{
			int count = 0;
			fleet.ForEach(u => count += u.CurrentCount);
			return count;
		}

		private int TakeHits(List<PlayerUnit> fleet, int hits)
		{
			PlayerUnit unit;

			while (hits > 0 && fleet.Exists(u => u.CurrentCount > 0))
			{
				if (fleet.Any()) // Prevents IndexOutOfRangeException for empty list
				{
					// Find the last set of units
					unit = fleet.FindLast(delegate (PlayerUnit u) { return u.CurrentCount > 0; });
					
					// Remove units; when more hits remain, a negative number will be returned
					hits = -unit.LoseUnits(hits);
				}
			}

			return GetRemainingUnitCount(fleet);

			// Add a default sort order for units later on. e.g. dread = 1, fighters = 2, etc. 
				// Add a way to override these. e.g. dread near the end unless upgraded.
				// units.FindAll().FindLast() ?
		}

		private string RoundOfCombat(List<PlayerUnit> _attackingFleet, List<PlayerUnit> _defendingFleet)
		{
			// Find number of hits per player
			int _attackerNumberOfHits = TakeShots(_attackingFleet);
			int _defenderNumberOfHits = TakeShots(_defendingFleet);

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

			while (_combatStatus == "Ongoing")
			{ 
				_combatStatus = RoundOfCombat(_attackingFleet, _defendingFleet);
			}

			return _combatStatus;
		}
	}
}