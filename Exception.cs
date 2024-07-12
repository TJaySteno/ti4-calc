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
			Console.WriteLine($"TI4CalculatorException: {message}");
		}
	}

	class CannotBuildWarSunException : TI4CalculatorException
	{
		public CannotBuildWarSunException(string faction)
		{
			Console.WriteLine($"CannotBuildWarSunException: Un-upgraded War Suns are not available to faction, {faction}.");
		}
	}

	class CombatTypeException : TI4CalculatorException
	{
		public CombatTypeException(string combatType)
		{
			Console.WriteLine($"CombatTypeException: $Combat must take place in space or ground. Value given: {combatType}.");
		}
	}

	class NoFactionMatchException : TI4CalculatorException
	{
		public NoFactionMatchException(string faction)
		{
			Console.WriteLine($"NoFactionMatchException: The faction provided does not exist: {faction}.");
		}
	}

	class NoFleetException : TI4CalculatorException
	{
		public NoFleetException(string message)
		{
			Console.WriteLine($"NoFleetException: {message}");
		}
	}

	class ReinforcementsException : TI4CalculatorException
	{
		public ReinforcementsException(string unitName, int reinforcements)
		{
			Console.WriteLine($"ReinforcementsException: Not enough reinforcements for the requested amount of {unitName}. Max: {reinforcements}.");
		}
	}

	class SustainDamageException : TI4CalculatorException
	{
		public SustainDamageException(string shipName)
		{
			Console.WriteLine($"SustainDamageException: $Cannot destroy {shipName} while it can still sustain damage.");
		}
	}

	class UnitTypeException : TI4CalculatorException
	{
		public UnitTypeException(string unitName)
		{
			Console.WriteLine($"UnitTypeException: Only one stack of unit, {unitName}, can be added.");
		}
	}
}
