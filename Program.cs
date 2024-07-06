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
				int _numberOfRounds = 5000;

				// Attacker's fleet
				attacker.UpdatePlayerShipCount(8, new Cruiser(attacker.Faction));
				//attacker.UpdatePlayerShipCount(1, new Dreadnought(attacker.Faction));

				// Defender's fleet
				//defender.UpdatePlayerShipCount(7, new Cruiser(defender.Faction));
				defender.UpdatePlayerShipCount(5, new Dreadnought(defender.Faction));

				for (int i = 0; i < _numberOfRounds; i++)
				{
					string _result = combat.DoBattle(attacker, defender);

					if		(_result == "Offensive Victory") attacker.AddWin();
					else if (_result == "Defensive Victory") defender.AddWin();
					else if (_result == "Draw") _draws++;

					attacker.Fleet.ForEach(u => u.ResetPlayerShip());
					defender.Fleet.ForEach(u => u.ResetPlayerShip());
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
