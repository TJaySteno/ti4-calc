using System;
using System.Collections.Generic;

namespace ti4_calc
{
	internal class Player
	{
		internal string Faction { get; private set; }
		internal int Wins { get; private set; } = 0;
		internal Player(string faction) { Faction = faction; }

		internal List<PlayerShip> Fleet = new List<PlayerShip>();

		public void AddWin() => Wins++;

		public bool FleetCanSustainDamage()
			=> Fleet.Exists(u => u.CanSustainDamage > 0);

		private int GetFleetCost()
		{
			int cost = 0;
			Fleet.ForEach(u => cost += u.Count * u.Ship.Cost);
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

		public void UpdatePlayerShipCount(int count, IShip unitNew)
		{
			// Ensure we aren't adding two of the same unit.
			bool unitAlreadyExists = Fleet.Exists(unitCur => unitCur.Ship.Name == unitNew.Name);
			bool checkReinforcements = unitNew.Reinforcements >= count;

			if (unitAlreadyExists)
			{
				throw new Exception("Only one stack per type of unit per player can be added.");
			}

			if (!checkReinforcements)
			{
				throw new Exception($"Not enough reinforcements for {unitNew.Name}. Max: {unitNew.Reinforcements}.");
			}

			Fleet.Add(new PlayerShip(count, unitNew));
		}
	}
}