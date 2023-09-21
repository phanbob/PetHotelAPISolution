using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string? Price { get; set; }

    public string? RoomName { get; set; }

    public virtual Room RoomTypeNavigation { get; set; } = null!;
}
