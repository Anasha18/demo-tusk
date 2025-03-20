using System;
using System.Collections.Generic;

namespace demo_tusk.Model;

public partial class TypeOrder
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
