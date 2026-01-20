using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TlkpRole
{
    public int IdRole { get; set; }

    public string? RoleDescription { get; set; }

    public virtual ICollection<TUser> TUsers { get; set; } = new List<TUser>();
}
