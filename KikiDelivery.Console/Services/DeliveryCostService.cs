using KikiDelivery.Console.Interfaces;
using KikiDelivery.Console.Models;
using KikiDelivery.Console.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiDelivery.Console.Services
{
	public class DeliveryCostService : IDeliveryCostService
	{
		private readonly IEnumerable<IOfferRule> _offerRules;
		public DeliveryCostService(IEnumerable<IOfferRule> offerRules)
		{
			_offerRules = offerRules;
		}

		public OfferResult CalculateCost(Package pkg, double baseDeliveryCost)
		{
			double deliveryCost = baseDeliveryCost + (pkg.Weight * 10) + (pkg.Distance * 5);
			double discount = 0;

			var rule = _offerRules.FirstOrDefault(r => string.Equals(r.OfferCode, pkg.OfferCode, StringComparison.OrdinalIgnoreCase));
			if (rule != null && rule.IsApplicable(pkg))
			{
				discount = Math.Round(deliveryCost * rule.DiscountPercent, 2);
			}

			return new OfferResult
			{
				Discount = discount,
				FinalCost = Math.Round(deliveryCost - discount, 2)
			};
		}
	}
}
