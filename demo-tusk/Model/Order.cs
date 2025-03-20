using System;
using System.Collections.Generic;

namespace demo_tusk.Model;

public partial class Order
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public int UserId { get; set; }

    public string Address { get; set; } = null!;

    public int ClientFromId { get; set; }

    public int ClientToId { get; set; }

    public DateTime StartOrder { get; set; }

    public DateTime FinishOrder { get; set; }

    public decimal Width { get; set; }

    public decimal Length { get; set; }

    public decimal Weight { get; set; }

    public decimal Cost { get; set; }

    public int? TypeId { get; set; }

    public virtual Client ClientFrom { get; set; } = null!;

    public virtual Client ClientTo { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual TypeOrder? Type { get; set; }

    public virtual User User { get; set; } = null!;
}
