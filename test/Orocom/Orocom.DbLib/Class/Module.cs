using System;
using System.Collections.Generic;

namespace Orocom.DbLib.Class;

public partial class Module
{
    public ulong Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
