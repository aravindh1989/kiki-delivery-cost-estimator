using KikiDelivery.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiDelivery.Console.Offers
{
	public class OFR002 : IOfferRule
	{
		public string OfferCode => "OFR002";
		public double DiscountPercent => 0.07;
		public bool IsApplicable(Package pkg)
		{
			return pkg.Distance >= 50 && pkg.Distance <= 150 && pkg.Weight >= 100 && pkg.Weight <= 250;
		}
	}
}
