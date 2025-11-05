using KikiDelivery.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiDelivery.Console.Offers
{
	public class OFR001 : IOfferRule
	{
		public string OfferCode => "OFR001";
		public double DiscountPercent => 0.10;
		public bool IsApplicable(Package pkg)
		{
			return pkg.Distance < 200 && pkg.Weight >= 70 && pkg.Weight <= 200;
		}
	}
}
