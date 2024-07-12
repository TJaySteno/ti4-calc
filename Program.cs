using System;

namespace ti4_calc
{
	internal class Program
	{
		static void Main()
		{
			try
			{
				int _numberOfRounds = 10000;
				int _numberOfDraws = 0;
				string _combatType = "space";


				// Attacker
				Player attacker = new Player("Sol");

				// attacker.PDS.UpdatePDS(new UpdatePDS(attacker.Faction, 6, true));

				/*attacker.AddShipToFleet(4,	new Carrier(attacker.Faction));
				attacker.AddShipToFleet(8,	new Cruiser(attacker.Faction));*/
				attacker.AddShipToFleet(3,	new Destroyer(attacker.Faction));
				/*attacker.AddShipToFleet(5,	new Dreadnought(attacker.Faction));
				attacker.AddShipToFleet(10, new Fighter(attacker.Faction));
				attacker.AddShipToFleet(1,	new Flagship(attacker.Faction));
				attacker.AddShipToFleet(2,	new WarSun(attacker.Faction, true));*/
				// Attacker


				// Defender (Later: Nebula bonus)
				Player defender = new Player("Muaat");
				
				defender.PDS.UpdatePDS(defender.Faction, 2);

				/*defender.AddShipToFleet(4, new Carrier(defender.Faction));
				defender.AddShipToFleet(8, new Cruiser(defender.Faction));*/
				defender.AddShipToFleet(2, new Destroyer(defender.Faction));
				// defender.AddShipToFleet(5, new Dreadnought(defender.Faction));
				// defender.AddShipToFleet(4, new Fighter(defender.Faction));
				/*defender.AddShipToFleet(1,	new Flagship(defender.Faction));
				defender.AddShipToFleet(2,	new WarSun(defender.Faction, true));*/
				// Defender


				Combat combat = new Combat(attacker, defender, _combatType);
				Results results = new Results(attacker, defender);

				for (int i = 0; i < _numberOfRounds; i++)
				{
					string _result = combat.DoBattle();

					if		(_result == "Offensive Victory") attacker.Win();
					else if (_result == "Defensive Victory") defender.Win();
					else if (_result == "Draw") _numberOfDraws++;

					attacker.Fleet.ForEach(s => s.ResetShip());
					defender.Fleet.ForEach(s => s.ResetShip());
				}

				results.Print(_numberOfDraws, _numberOfRounds);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"UnhandledException: {ex}");
				Console.ReadLine();
			}
		}
	}
}
