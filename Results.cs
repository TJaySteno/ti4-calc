using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace ti4_calc
{
	internal class Results
	{
		internal Player Attacker;
		internal Player Defender;

		internal Results(Player attacker, Player defender)
		{
			Attacker = attacker;
			Defender = defender;
		}

		private double GetAverage(int wins, int rounds)
			=> (Convert.ToDouble(wins) / Convert.ToDouble(rounds)) * 100;

		private string StringifyFleet (List<PlayerUnit> fleet)
		{
			string fleetString = "";
			fleet.ForEach(u => fleetString += u.PrintUnit());
			return fleetString;
		}

		public void Print(int draws, int numberOfRounds)
		{
			string _attackerFleetString = StringifyFleet(Attacker.Fleet);
			string _defenderFleetString = StringifyFleet(Defender.Fleet);
			
			double _attackerPercentage = GetAverage(Attacker.Wins, numberOfRounds);
			double _defenderPercentage = GetAverage(Defender.Wins, numberOfRounds);
			double _drawPercentage = GetAverage(draws, numberOfRounds);

			Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.WriteLine("Trent's Sick Ass TI4 Battle Calculator, Babyyyyyyyyyyy!!!!!");
			Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.WriteLine("");
			Console.WriteLine($"Attacker Units:{_attackerFleetString} {Attacker.Wins} wins, {_attackerPercentage}%");
			Console.WriteLine($"Defender Units:{_defenderFleetString} {Defender.Wins} wins, {_defenderPercentage}%");
			Console.WriteLine($"Draws: {draws}, {_drawPercentage}%");
			Console.ReadLine();
		}
	}
}