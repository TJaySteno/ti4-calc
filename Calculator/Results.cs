﻿using System;

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

		public void Print(int draws, int numberOfRounds)
		{
			string _attackerPdsString = Attacker.PDS.Stringify();
			string _defenderPdsString = Defender.PDS.Stringify();


			string _attackerFleetString = Attacker.StringifyFleet();
			string _defenderFleetString = Defender.StringifyFleet();
			
			double _attackerPercentage = GetAverage(Attacker.Wins, numberOfRounds);
			double _defenderPercentage = GetAverage(Defender.Wins, numberOfRounds);
			double _drawPercentage = GetAverage(draws, numberOfRounds);

			Console.WriteLine(
				"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
				"Trent's Sick Ass TI4 Battle Calculator, Babyyyyyyyyyyy!!!!!\n" +
				"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
				"\n" +
				$"Out of {numberOfRounds} battle simulations run...\n" +
				$"  Attacker: {_attackerFleetString}\n" +
				$"    Wins: {Attacker.Wins} wins ({_attackerPercentage}%)\n" +
				$"  Defender: {_defenderFleetString}\n" +
				$"    Wins: {Defender.Wins} wins ({_defenderPercentage}%)\n" +
				$"  Draws: {draws} ({_drawPercentage}%)\n"
			);
			Console.ReadLine();
		}
	}
}