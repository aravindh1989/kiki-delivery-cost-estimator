using KikiDelivery.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiDelivery.Console.Interfaces
{
	public interface IDeliveryCostService
	{
		OfferResult CalculateCost(Package pkg, double baseDeliveryCost);
	}
}
