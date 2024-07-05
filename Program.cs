using System;

namespace ti4_calc
{
	internal class Program
	{
		static void Main()
		{
			try
			{
				Combat combat = new Combat();
				Player attacker = new Player("Sol");
				Player defender = new Player("Muaat");
				Results results = new Results(attacker, defender);

				int _draws = 0;
				int _numberOfRounds = 500000;

				attacker.UpdatePlayerUnitCount(8, new Cruiser());
				defender.UpdatePlayerUnitCount(8, new Cruiser());

				for (int i = 0; i < _numberOfRounds; i++)
				{
					string _result = combat.DoBattle(attacker, defender);

					if		(_result == "Offensive Victory") attacker.AddWin();
					else if (_result == "Defensive Victory") defender.AddWin();
					else if (_result == "Draw") _draws++;

					attacker.Fleet.ForEach(u => u.ResetUnitCount());
					defender.Fleet.ForEach(u => u.ResetUnitCount());
				}

				results.Print(_draws, _numberOfRounds);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Unhandled Exception: {ex}");
				Console.ReadLine();
			}
		}
	}
}
