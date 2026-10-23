using System;
using System.Collections.Generic;

namespace shoes_project_v2.Models;

public partial class VOrdersSummary
{
    public int? OrderId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? ClientFullName { get; set; }

    public long? ItemsCount { get; set; }

    public decimal? TotalAmount { get; set; }
}
