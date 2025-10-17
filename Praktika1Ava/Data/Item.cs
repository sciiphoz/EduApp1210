using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Praktika1Ava.Data;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Desc { get; set; }

    public int? Price { get; set; }

    [Display(AutoGenerateField = false)]
    public virtual ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
}
