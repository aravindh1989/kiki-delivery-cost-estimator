README — Delivery Cost Estimator


A command-line tool that calculates total delivery cost for each package including base cost, weight & distance charge, and discount based on valid offer codes.

Designed to be scalable for additional offer codes
Clean architecture
Unit test support read

Cost Formula

Delivery Cost = Base Delivery Cost + (Package Weight × 10) + (Distance × 5) - Discount (if applicable)

Offer code rules

Only one valid offer can be applied
If invalid → discount = 0

Input Format

<base_delivery_cost> <no_of_packages>
<pkg_id> <weight_kg> <distance_km> <offer_code>

Example input

100 3
PKG1 5 5 OFR001
PKG2 15 5 OFR002
PKG3 10 100 OFR003

Output format

<pkg_id> <discount> <total_cost>

Example output

PKG1 0 175
PKG2 0 275
PKG3 35 665


Running the App

dotnet run


Run Unit Tests

dotnet test


