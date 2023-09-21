using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<StayService> StayServices { get; set; } = new List<StayService>();
}
