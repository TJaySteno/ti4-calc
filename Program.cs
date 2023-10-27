using System;
using System.Linq;

namespace ti4_calc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Calculator calc = new Calculator();
				
				Player Player1 = new Player("Sol");
				Player Player2 = new Player("Muaat");

				// I have to declare Upgraded twice in the method. Should I just store upgraded on IUnit and not PlayerUnit?
				Player1.AddNewUnitType("Cruiser", 8, new Cruiser(Player1.Faction, false));
				Player2.AddNewUnitType("Cruiser", 8, new Cruiser(Player1.Faction, true));

				calc.DoBattle(Player1, Player2);

				Console.WriteLine("Player 1: " + Player1.PlayerUnits.Count);
				Console.WriteLine("Player 2: " + Player2.PlayerUnits.Count);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unhandled Exception: " + ex);
			}
		}
	}
}
