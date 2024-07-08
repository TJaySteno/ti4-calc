using System;
using System.Collections.Generic;
using ti4_calc.Units.GroundUnits;
using ti4_calc.Units.SpaceUnits;

namespace ti4_calc
{
	internal class Player
	{
		public string FactionFullName { get; private set; }
		public string Faction { get; private set; }
		public int FactionCombatModifier { get; private set; } = 0;
		internal int Wins { get; private set; } = 0;

		internal List<Ship> Fleet = new List<Ship>();


		public void AddShipToFleet(int count, IShip unitNew)
		{
			// Ensure we aren't adding two of the same unit.
			if (Fleet.Exists(unitCur => unitCur.Type.Name == unitNew.Name))
				throw new Exception("Only one stack per type of unit per player can be added.");

			// Ensure there are enough available pieces for this unit.
			if (count > unitNew.Reinforcements)
				throw new Exception($"Not enough reinforcements for {unitNew.Name}. Max: {unitNew.Reinforcements}.");

			Fleet.Add(new Ship(count, unitNew));
		}

		internal Player(string faction)
		{
			if (faction == "Arborec") FactionFullName = "The Arborec";
			else if (faction == "Argent") FactionFullName = "The Argent Flight";
			else if (faction == "Barony") FactionFullName = "The Barony of Letnev";
			else if (faction == "Saar") FactionFullName = "The Clan of Saar";
			else if (faction == "Keleres") FactionFullName = "The Council Keleres";
			else if (faction == "Muaat") FactionFullName = "The Embers of Muaat";
			else if (faction == "Hacan") FactionFullName = "The Emirates of Hacan";
			else if (faction == "Empyrean") FactionFullName = "The Empyrean";
			else if (faction == "Sol") FactionFullName = "The Federation of Sol";
			else if (faction == "Ghosts") FactionFullName = "The Ghosts of Creuss";
			else if (faction == "L1Z1X") FactionFullName = "The L1Z1X Mindnet";
			else if (faction == "Mahact") FactionFullName = "The Mahact Gene Sorcerers";
			else if (faction == "Mentak") FactionFullName = "The Mentak Coalition";
			else if (faction == "Naalu") FactionFullName = "The Naalu Collective";
			else if (faction == "NRA") FactionFullName = "The Naaz-Rokha Alliance";
			else if (faction == "Nekro") FactionFullName = "The Nekro Virus";
			else if (faction == "Nomad") FactionFullName = "The Nomad";
			else if (faction == "Sardakk")
			{
				FactionFullName = "Sardakk N'orr";
				FactionCombatModifier = 1;
			}
			else if (faction == "Titans") FactionFullName = "The Titans of Ul";
			else if (faction == "JolNar")
			{
				FactionFullName = "The Universities of Jol-Nar";
				FactionCombatModifier = -1;
			}
			else if (faction == "VuilRaith") FactionFullName = "The Vuil'Raith Cabal";
			else if (faction == "Winnu") FactionFullName = "The Winnu";
			else if (faction == "Xxcha") FactionFullName = "The Xxcha Kingdom";
			else if (faction == "Yin") FactionFullName = "The Yin Brotherhood";
			else if (faction == "Yssaril") FactionFullName = "The Yssaril Tribes";

			else throw new Exception($"Faction provided does not exist: {faction}.");

			Faction = faction;
		}

		public void Win() => Wins++;

		public bool FleetCanSustainDamage(string target)
		{
			return Fleet.Exists(delegate (Ship ship)
			{
				bool targetMatches = target == null || target == ship.Type.Name;
				if (targetMatches && ship.CanSustainDamage > 0)
					return true;
				else
					return false;
			});
		}	

		private double GetFleetCost()
		{
			double cost = 0;
			Fleet.ForEach(s => cost += s.Count * s.Type.Cost);
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
			Fleet.ForEach(s => fleetString += s.PrintUnit());
			if (fleetString.Length > 1) fleetString = $"{fleetString.TrimEnd(',')}";
			
			return fleetString;
		}
	}
}