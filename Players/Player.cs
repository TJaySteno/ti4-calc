using System;
using System.Collections.Generic;

namespace ti4_calc
{
	internal class Player
	{
		public string FactionName { get; private set; }
		public string FactionNameShort { get; private set; }
		public int FactionCombatModifier { get; private set; } = 0;

		internal int Wins { get; private set; } = 0;

		internal List<PlayerShip> Fleet = new List<PlayerShip>();

		internal Player(string faction)
		{
			if (faction == "Arborec") FactionName = "The Arborec";
			else if (faction == "Argent") FactionName = "The Argent Flight";
			else if (faction == "Barony") FactionName = "The Barony of Letnev";
			else if (faction == "Keleres") FactionName = "The Council Keleres";
			else if (faction == "Saar") FactionName = "The Clan of Saar";
			else if (faction == "Muaat") FactionName = "The Embers of Muaat";
			else if (faction == "Hacan") FactionName = "The Emirates of Hacan";
			else if (faction == "Empyrean") FactionName = "The Empyrean";
			else if (faction == "Sol") FactionName = "The Federation of Sol";
			else if (faction == "Ghosts") FactionName = "The Ghosts of Creuss";
			else if (faction == "L1Z1X") FactionName = "The L1Z1X Mindnet";
			else if (faction == "Mahact") FactionName = "The Mahact Gene Sorcerers";
			else if (faction == "Mentak") FactionName = "The Mentak Coalition";
			else if (faction == "Naalu") FactionName = "The Naalu Collective";
			else if (faction == "NRA") FactionName = "The Naaz-Rokha Alliance";
			else if (faction == "Nekro") FactionName = "The Nekro Virus";
			else if (faction == "Nomad") FactionName = "The Nomad";
			else if (faction == "Sardakk")
			{
				FactionName = "Sardakk N'orr";
				FactionCombatModifier = 1;
			}
			else if (faction == "Titans") FactionName = "The Titans of Ul";
			else if (faction == "JolNar")
			{
				FactionName = "The Universities of Jol-Nar";
				FactionCombatModifier = -1;
			}
			else if (faction == "VuilRaith") FactionName = "The Vuil'Raith Cabal";
			else if (faction == "Winnu") FactionName = "The Winnu";
			else if (faction == "Xxcha") FactionName = "The Xxcha Kingdom";
			else if (faction == "Yin") FactionName = "The Yin Brotherhood";
			else if (faction == "Yssaril") FactionName = "The Yssaril Tribes";

			else throw new Exception($"Faction provided does not exist: {faction}.");

			FactionNameShort = faction;
		}

		public void AddWin() => Wins++;

		public bool FleetCanSustainDamage()
			=> Fleet.Exists(u => u.CanSustainDamage > 0);

		private double GetFleetCost()
		{
			double cost = 0;
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