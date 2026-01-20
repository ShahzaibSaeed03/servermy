using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TlkpCountry
{
    public int IdCountry { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<TUser> TUsers { get; set; } = new List<TUser>();
}
