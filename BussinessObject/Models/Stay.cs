using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Stay
{
    public int StayId { get; set; }

    public int PetId { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public int RoomId { get; set; }

    public string? Status { get; set; }

    public virtual Pet Pet { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual ICollection<StayService> StayServices { get; set; } = new List<StayService>();
}
