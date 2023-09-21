using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public int? RoomTypeId { get; set; }

    public string? Status { get; set; }

    public virtual RoomType? RoomType { get; set; }

    public virtual ICollection<Stay> Stays { get; set; } = new List<Stay>();
}
