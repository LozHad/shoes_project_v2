using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

public partial class VProductsCatalog
{
    public int? ProductId { get; set; }

    public string? CategoryName { get; set; }

    public string? SubcategoryName { get; set; }

    public string? ManufacturerName { get; set; }

    public string? ProductName { get; set; }

    public string? Image { get; set; }

    public string? Composition { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public decimal? SizeMin { get; set; }

    public decimal? SizeMax { get; set; }

    public string? AvailableSizes { get; set; }

    public long? TotalQuantity { get; set; }
}
