﻿using System;
using System.Collections.Generic;

namespace DbFirstSample.Models;

public partial class CategoryMenu
{
    public string CategoryName { get; set; } = null!;

    public int? Quantity { get; set; }
}
