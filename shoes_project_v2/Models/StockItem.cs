using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

/// <summary>
/// Товарные позиции: модель + размер, количество доступное для заказа
/// </summary>
public partial class StockItem
{
    public int StockItemId { get; set; }

    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int QuantityAvailable { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
