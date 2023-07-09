using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti4_calc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Dreadnought a = new Dreadnought("LIZIX");
				Dreadnought aUpgraded = new Dreadnought("LIZIX", true);
				
				Dreadnought b = new Dreadnought("Sardakk");
				Dreadnought bUpgraded = new Dreadnought("Sardakk", true);

				Dreadnought other = new Dreadnought(null); // Make faction conform to a small set of strings or IDs
				Dreadnought otherUpgraded = new Dreadnought(null, true);

				Console.WriteLine(a.GetAllUnitStats());
				Console.WriteLine(aUpgraded.GetAllUnitStats());

				Console.WriteLine(b.GetAllUnitStats());
				Console.WriteLine(bUpgraded.GetAllUnitStats());

				Console.WriteLine(other.GetAllUnitStats());
				Console.WriteLine(otherUpgraded.GetAllUnitStats());
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unhandled Exception: " + ex);
			}
		}
	}
}
