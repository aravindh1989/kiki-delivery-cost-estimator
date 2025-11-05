using KikiDelivery.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiDelivery.Console.Offers
{
	public class OFR003 : IOfferRule
	{
		public string OfferCode => "OFR003";
		public double DiscountPercent => 0.05;
		public bool IsApplicable(Package pkg)
		{
			return pkg.Distance >= 50 && pkg.Distance <= 250 && pkg.Weight >= 10 && pkg.Weight <= 150;
		}
	}
}
