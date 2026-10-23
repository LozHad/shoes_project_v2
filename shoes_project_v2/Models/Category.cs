using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

/// <summary>
/// Категории обуви: детская, женская, мужская
/// </summary>
public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
