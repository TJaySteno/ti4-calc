using System;
using System.Collections.Generic;
using System.Linq;

namespace ti4_calc
{
	internal class Player
	{
		internal string Faction { get; private set; }
		internal int Wins { get; private set; } = 0;
		internal Player(string faction) { Faction = faction; }

		internal List<PlayerUnit> Fleet = new List<PlayerUnit>();

		public void AddWin() => Wins++;

		private int GetFleetCost()
		{
			int cost = 0;
			Fleet.ForEach(u => cost += u.StartingCount * u.Unit.Cost);
			return cost;
		}

		internal string StringifyFleet()
		{
			if (Fleet.Count < 1)
			{
				throw new Exception("There is no fleet to stringify.");
			};
			
			string fleetString = "";
			fleetString += $"(Cost {GetFleetCost()} TG)";
			Fleet.ForEach(u => fleetString += u.PrintUnit());
			if (fleetString.Length > 1) fleetString = $"{fleetString.TrimEnd(',')}";
			
			return fleetString;
		}

		public void UpdatePlayerUnitCount(int count, IUnit unitNew)
		{
			// Ensure we aren't adding two of the same unit.
			bool unitAlreadyExists = Fleet.Exists(unitCur => unitCur.Unit.Name == unitNew.Name);
			bool checkReinforcements = unitNew.Reinforcements >= count;

			if (unitAlreadyExists)
			{
				throw new Exception("Only one stack per type of unit per player can be added.");
			}

			if (!checkReinforcements)
			{
				throw new Exception($"Not enough reinforcements for {unitNew.Name}. Max: {unitNew.Reinforcements}.");
			}

			Fleet.Add(new PlayerUnit(count, unitNew));
		}
	}
}