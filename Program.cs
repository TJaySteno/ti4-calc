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
				Cruiser a = new Cruiser("LIZIX");
				Cruiser aUpgraded = new Cruiser("LIZIX", true);
				
				Cruiser b = new Cruiser("Sardakk");
				Cruiser bUpgraded = new Cruiser("Sardakk", true);

				Cruiser other = new Cruiser(null); // Make faction conform to a small set of strings or IDs
				Cruiser otherUpgraded = new Cruiser(null, true);

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
