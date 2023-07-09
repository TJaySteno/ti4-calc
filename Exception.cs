using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

	class TI4CalculatorException : Exception
	{
		public TI4CalculatorException()
		{

		}

		public TI4CalculatorException(string message)
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

}
