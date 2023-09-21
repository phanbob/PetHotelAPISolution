using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class StayService
{
    public int StayServicesId { get; set; }

    public int? StayId { get; set; }

    public int? ServiceId { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Stay? Stay { get; set; }
}
