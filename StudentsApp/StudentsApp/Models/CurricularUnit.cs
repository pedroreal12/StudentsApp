using System;
using System.Collections.Generic;

namespace StudentsApp.Models;

public partial class CurricularUnit
{
    public int Id { get; set; }

    public string StrName { get; set; } = null!;

    public virtual ICollection<ClassDetail> ClassDetails { get; set; } = new List<ClassDetail>();
}
