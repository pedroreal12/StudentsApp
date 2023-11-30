using System;
using System.Collections.Generic;

namespace StudentsApp.Models;

public partial class Class
{
    public int Id { get; set; }

    public int FkIdPerson { get; set; }

    public int FkIdClassDetails { get; set; }
}
