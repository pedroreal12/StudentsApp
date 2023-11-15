using System;
using System.Collections.Generic;

namespace StudentsApp.Models;

public partial class ClassDetail
{
    public int Id { get; set; }

    public string? StrName { get; set; }

    public string? StrYear { get; set; }

    public int? FkIdTeacher { get; set; }

    public virtual Person? FkIdTeacherNavigation { get; set; }
}
