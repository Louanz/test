using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orocom.DbLib.Class;

public partial class Product
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Tax { get; set; } = null!;

    [ForeignKey(nameof(Product.Module))]
    public ulong ModuleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Module Module { get; set; }
}
