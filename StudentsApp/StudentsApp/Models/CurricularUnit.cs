using System;
using System.Collections.Generic;

namespace StudentsApp.Models;

public partial class CurricularUnit
{
    public int Id { get; set; }

    public string? StrName { get; set; }

    public int? FkIdCurricularUnit { get; set; }

    public virtual CurricularUnit? FkIdCurricularUnitNavigation { get; set; }

    public virtual ICollection<CurricularUnit> InverseFkIdCurricularUnitNavigation { get; set; } = new List<CurricularUnit>();

    public virtual ICollection<Objective> Objectives { get; set; } = new List<Objective>();
}
