using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

/// <summary>
/// Производители
/// </summary>
public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
