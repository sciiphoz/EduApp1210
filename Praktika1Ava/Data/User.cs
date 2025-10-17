using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Praktika1Ava.Data;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? Role { get; set; } = 0;

    [Display(AutoGenerateField = false)]
    public virtual ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
}
