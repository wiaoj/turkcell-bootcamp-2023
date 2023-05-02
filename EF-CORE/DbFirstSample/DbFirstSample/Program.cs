//dotnet ef dbcontext scaffold "Server=localhost,1434;Database=Northwind; User Id=sa; Password=MssqlPassword1.;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models

using DbFirstSample.Data;
using DbFirstSample.Models;
using Microsoft.EntityFrameworkCore;

List<Product> products = new NorthwindContext().Products.Include(p => p.Category).ToList();

products.ForEach(p => Console.WriteLine(@$"{p.ProductName}.....{p.UnitPrice:.00}"));

Console.WriteLine(new String('-', 50));

var productAndCategoryName = products.Select(p => new {
    p.ProductName,
    p.UnitPrice,
    p.Category?.CategoryName
}).ToList();

productAndCategoryName.ForEach(p => Console.WriteLine($@"{p.ProductName}.....{p.UnitPrice}.....{p.CategoryName}"));