using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public string? Name { get; set; }

    public int? PetTypeId { get; set; }

    public string? Breed { get; set; }

    public int? OwnerId { get; set; }

    public virtual PetOwner? Owner { get; set; }

    public virtual PetType? PetType { get; set; }

    public virtual ICollection<Stay> Stays { get; set; } = new List<Stay>();
}
