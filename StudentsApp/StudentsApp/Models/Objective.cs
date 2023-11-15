using System;
using System.Collections.Generic;

namespace StudentsApp.Models;

public partial class Objective
{
    public int Id { get; set; }

    public string? StrLabel { get; set; }

    public int? FkIdCurricularUnits { get; set; }

    public virtual CurricularUnit? FkIdCurricularUnitsNavigation { get; set; }
}
