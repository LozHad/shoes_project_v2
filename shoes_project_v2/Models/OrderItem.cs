using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

/// <summary>
/// Состав заказа: товарная позиция, количество, цена за единицу
/// </summary>
public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int StockItemId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual StockItem StockItem { get; set; } = null!;
}
