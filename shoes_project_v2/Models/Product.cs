using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

/// <summary>
/// Модели обуви (каталог)
/// </summary>
public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int SubcategoryId { get; set; }

    public int ManufacturerId { get; set; }

    public string? Image { get; set; }

    public string? Composition { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();

    public virtual Subcategory Subcategory { get; set; } = null!;
}
