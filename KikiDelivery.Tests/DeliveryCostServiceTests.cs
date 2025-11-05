using KikiDelivery.Console.Models;
using KikiDelivery.Console.Offers;
using KikiDelivery.Console.Services;

namespace KikiDelivery.Tests
{
	public class DeliveryCostServiceTests
	{
		private readonly DeliveryCostService _svc;
		public DeliveryCostServiceTests()
		{
			var offers = new List<IOfferRule> { new OFR001(), new OFR002(), new OFR003() };
			_svc = new DeliveryCostService(offers);
		}

		[Fact]
		public void PKG1_NoOffer_DiscountZero()
		{
			var pkg = new Package { PackageId = "PKG1", Weight = 5, Distance = 5, OfferCode = "OFR001" };
			var res = _svc.CalculateCost(pkg, 100);
			Assert.Equal(0, res.Discount);
			Assert.Equal(175, res.FinalCost);
		}

		[Fact]
		public void PKG3_WithOFR003_DiscountApplied()
		{
			var pkg = new Package { PackageId = "PKG3", Weight = 10, Distance = 100, OfferCode = "OFR003" };
			var res = _svc.CalculateCost(pkg, 100);
			Assert.Equal(35, res.Discount);
			Assert.Equal(665, res.FinalCost);
		}
	}
}