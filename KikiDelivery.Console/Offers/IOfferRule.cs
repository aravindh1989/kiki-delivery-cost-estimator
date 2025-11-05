using KikiDelivery.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiDelivery.Console.Offers
{
	public interface IOfferRule
	{
		string OfferCode { get; }
		bool IsApplicable(Package pkg);
		double DiscountPercent { get; }
	}
}
