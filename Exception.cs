using System;
// Later: Make better Exceptions.

namespace ti4_calc
{
	class CannotBuildWarSunException : Exception
	{
		public CannotBuildWarSunException()
		{

		}

		public CannotBuildWarSunException(string message)
		{

		}
	}

	class DoesNotHaveSustainException : TI4CalculatorException
	{
		public DoesNotHaveSustainException()
		{

		}

		public DoesNotHaveSustainException(string message) : base(message)
		{

		}
	}

	class TI4CalculatorException : Exception
	{
		public TI4CalculatorException()
		{

		}

		public TI4CalculatorException(string message)
		{

		}
	}
}
