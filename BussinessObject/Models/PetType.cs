using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class PetType
{
    public int PetTypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
