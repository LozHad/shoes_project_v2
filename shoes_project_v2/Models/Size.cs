using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

/// <summary>
/// Размерный ряд
/// </summary>
public partial class Size
{
    public int SizeId { get; set; }

    public decimal SizeValue { get; set; }

    public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();
}
