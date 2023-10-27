using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ti4_calc
{
	internal class Calculator
	{
		private List<PlayerUnit> _p1Units;
		private List<PlayerUnit> _p2Units;

		private double _p1ChanceToHit;
		private double _p2ChanceToHit;

		private int _roundDown(double num) => (int) Math.Floor(num);
		
		private bool _unitIsAlive(PlayerUnit unit) => unit.Count > 0;

		private int _findNextAliveShip(List<PlayerUnit> units)
		{
			return units.FindLastIndex(delegate (PlayerUnit u) { return _unitIsAlive(u); });
		}

		private double _rollForHits(List<PlayerUnit> units)
		{
			double numberOfHits = 0;

			foreach (PlayerUnit unit in units)
			{
				double numberOfShots = unit.Count * unit.Unit.NumberOfCombatDice;
				numberOfHits += (unit.Unit.ToHit * numberOfShots) / 10.0;
			}

			return numberOfHits;
		}

		private void _takeHits(List<PlayerUnit> units, int hits) 
		{
			PlayerUnit unit;

			while (hits > 0 && _findNextAliveShip(units) >= 0)
			{
				if (units.Any()) //prevent IndexOutOfRangeException for empty list
				{
					// Find the last set of units
					unit = units.FindLast(delegate (PlayerUnit u) { return _unitIsAlive(u); });
					
					// Remove units and calculate hits remaining by negating the unit.Count int that's returned
					hits = -unit.AddToUnitCount(-hits);
				}
			}
		}

		private void _roundOfCombat(List<PlayerUnit> _p1Units, List<PlayerUnit> _p2Units)
		{
			// Get probabilities and take hits
			_p1ChanceToHit += _rollForHits(_p1Units);
			_p2ChanceToHit += _rollForHits(_p2Units);

			_takeHits(_p1Units, _roundDown(_p2ChanceToHit));
			_takeHits(_p2Units, _roundDown(_p1ChanceToHit));

			_p1ChanceToHit -= _roundDown(_p1ChanceToHit);
			_p2ChanceToHit -= _roundDown(_p2ChanceToHit);
		}

		public void DoBattle(Player p1, Player p2)
		{
			// Create list of units to do battle
			// NEED: sorting method
			_p1Units = p1.PlayerUnits;
			_p2Units = p2.PlayerUnits;

			int index = 0;

			while (_findNextAliveShip(_p1Units) >= 0 && _findNextAliveShip(_p2Units) >= 0)
			{
				Console.WriteLine("Round: " + ++index);
				
				_roundOfCombat(_p1Units, _p2Units);

				Console.WriteLine(_p1Units.FindLastIndex(delegate (PlayerUnit u) { return _unitIsAlive(u); }));
				Console.WriteLine(_p2Units.FindLastIndex(delegate (PlayerUnit u) { return _unitIsAlive(u); }));
			}
		}
	}
}

/*
 * 
 * Roll attacker
 * Roll defender
 * 
 * Take hits, attacker
 * Take hits, defender
 * 
 * Repeat
 * 
 */