using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KikiDelivery.Console.Interfaces;
using KikiDelivery.Console.Offers;
using KikiDelivery.Console.Services;
using KikiDelivery.Console.Models;

using var host = Host.CreateDefaultBuilder(args)
	.ConfigureLogging(logging => logging.ClearProviders().AddConsole())
	.ConfigureServices((context, services) =>
	{
		// Register offer rules
		services.AddSingleton<IOfferRule, OFR001>();
		services.AddSingleton<IOfferRule, OFR002>();
		services.AddSingleton<IOfferRule, OFR003>();

		// Register services
		services.AddSingleton<IDeliveryCostService, DeliveryCostService>();
	})
	.Build();

var svc = host.Services.GetRequiredService<IDeliveryCostService>();
Console.WriteLine("Kiki Delivery — Delivery Cost Estimator (Cost only)");
Console.WriteLine("Enter base_delivery_cost and number_of_packages (space separated), e.g.: 100 3");

var header = Console.ReadLine();
if (string.IsNullOrWhiteSpace(header)) return;
var headerParts = header.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
if (headerParts.Length < 2)
{
	Console.WriteLine("Invalid header. Expected: <base_cost> <num_packages>"); return;
}

if (!double.TryParse(headerParts[0], out var baseCost))
{
	Console.WriteLine("Invalid base cost"); return;
}

if (!int.TryParse(headerParts[1], out var n))
{
	Console.WriteLine("Invalid package count"); return;
}

var packages = new List<Package>();
Console.WriteLine("Enter packages (one per line) in format: <pkgId> <weightKg> <distanceKm> <offerCode> (offerCode optional)");

for (int i = 0; i < n; i++)
{
	var line = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(line)) { i--; continue; }
	var parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
	if (parts.Length < 3)
	{
		Console.WriteLine("Invalid package line; expected at least 3 parts. Try again."); i--; continue;
	}
	var pkg = new Package
	{
		PackageId = parts[0],
		Weight = double.TryParse(parts[1], out var w) ? w : 0,
		Distance = double.TryParse(parts[2], out var d) ? d : 0,
		OfferCode = parts.Length >= 4 ? parts[3] : string.Empty
	};
	packages.Add(pkg);
}

Console.WriteLine("\nResults:");
foreach (var pkg in packages)
{
	var res = svc.CalculateCost(pkg, baseCost);
	Console.WriteLine($"{pkg.PackageId} {res.Discount} {res.FinalCost}");
}
