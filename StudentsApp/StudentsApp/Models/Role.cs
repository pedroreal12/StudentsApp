using System;
using System.Collections.Generic;

namespace StudentsApp.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? StrLabel { get; set; }

    public string? StrDescription { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
