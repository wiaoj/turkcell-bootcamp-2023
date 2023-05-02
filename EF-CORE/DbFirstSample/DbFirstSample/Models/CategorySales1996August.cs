using System;
using System.Collections.Generic;

namespace DbFirstSample.Models;

public partial class CategorySales1996August
{
    public string CategoryName { get; set; } = null!;

    public int? TotalOrder { get; set; }

    public double? TotalPrice { get; set; }
}
