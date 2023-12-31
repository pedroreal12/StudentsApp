﻿using System;
using System.Collections.Generic;

namespace StudentsApp.Models;

public partial class ClassDetail
{
    public int Id { get; set; }

    public string StrName { get; set; } = null!;

    public string StrYear { get; set; } = null!;

    public int FkIdPerson { get; set; }

    public virtual Person FkIdPersonNavigation { get; set; } = null!;
}
