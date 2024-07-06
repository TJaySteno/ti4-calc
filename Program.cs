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
				int _numberOfRounds = 10000;

				// Attacker's fleet
				attacker.UpdatePlayerShipCount(4, new Carrier(attacker.FactionNameShort));
				attacker.UpdatePlayerShipCount(8, new Cruiser(attacker.FactionNameShort));
				attacker.UpdatePlayerShipCount(8, new Destroyer(attacker.FactionNameShort));
				attacker.UpdatePlayerShipCount(5, new Dreadnought(attacker.FactionNameShort));
				attacker.UpdatePlayerShipCount(10, new Fighter(attacker.FactionNameShort));
				attacker.UpdatePlayerShipCount(2, new WarSun(attacker.FactionNameShort, true));

				// Defender's fleet
				// Later: Nebula bonus
				defender.UpdatePlayerShipCount(4, new Carrier(defender.FactionNameShort));
				defender.UpdatePlayerShipCount(8, new Cruiser(defender.FactionNameShort));
				defender.UpdatePlayerShipCount(8, new Destroyer(defender.FactionNameShort));
				defender.UpdatePlayerShipCount(5, new Dreadnought(defender.FactionNameShort));
				defender.UpdatePlayerShipCount(10, new Fighter(defender.FactionNameShort));
				defender.UpdatePlayerShipCount(2, new WarSun(defender.FactionNameShort, true));

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
