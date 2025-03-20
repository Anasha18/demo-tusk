using System;
using System.Collections.Generic;

namespace demo_tusk.Model;

public partial class Client
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> OrderClientFroms { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderClientTos { get; set; } = new List<Order>();
}
