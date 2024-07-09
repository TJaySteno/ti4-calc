using System;

namespace ti4_calc
{
	class TI4CalculatorException : Exception
	{
		public TI4CalculatorException()
		{
			Console.WriteLine("TI4CalculatorException.");
		}

		public TI4CalculatorException(string message)
		{
			Console.WriteLine($"UnhandledException: {message}");
		}
	}

	class CannotBuildWarSunException : TI4CalculatorException
	{
		public CannotBuildWarSunException()
		{
			Console.WriteLine($"CannotBuildWarSunException: Un-upgraded War Suns are not available to this faction.");
		}

		public CannotBuildWarSunException(string message)
		{
			Console.WriteLine($"CannotBuildWarSunException: {message}");
		}
	}

	class CombatTypeException : TI4CalculatorException
	{
		public CombatTypeException()
		{
			Console.WriteLine($"CombatTypeException: Combat must take place in space or ground.");
		}
		
		public CombatTypeException(string message)
		{
			Console.WriteLine($"CombatTypeException: {message}");
		}
	}

	class NoFactionMatchException : TI4CalculatorException
	{
		public NoFactionMatchException()
		{
			Console.WriteLine("NoFactionMatchException: The faction provided does not exist.");
		}

		public NoFactionMatchException(string message)
		{
			Console.WriteLine($"NoFactionMatchException: {message}");
		}
	}

	class NoFleetException : TI4CalculatorException
	{
		public NoFleetException()
		{
			Console.WriteLine($"NoFleetException: Both players must have a fleet.");
		}

		public NoFleetException(string message)
		{
			Console.WriteLine($"NoFleetException: {message}");
		}
	}

	class ReinforcementsException : TI4CalculatorException
	{
		public ReinforcementsException()
		{
			Console.WriteLine($"The requested number of ships is greater than the reinforcement supply.");
		}

		public ReinforcementsException(string message)
		{
			Console.WriteLine($"ReinforcementsException: {message}");
		}
	}

	class SustainDamageException : TI4CalculatorException
	{
		public SustainDamageException()
		{
			Console.WriteLine($"SustainDamageException: Cannot destroy this unit while it can still sustain damage.");
		}

		public SustainDamageException(string message)
		{
			Console.WriteLine($"SustainDamageException: {message}");
		}
	}

	class UnitTypeException : TI4CalculatorException
	{
		public UnitTypeException()
		{
			Console.WriteLine($"UnitTypeException: Unhandled unit type exception.");
		}

		public UnitTypeException(string message)
		{
			Console.WriteLine($"UnitTypeException: {message}");
		}
	}
}
