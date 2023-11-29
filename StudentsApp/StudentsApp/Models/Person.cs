using System;
using System.Collections.Generic;

namespace StudentsApp.Models;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public int FkIdRoles { get; set; }

    public virtual ICollection<ClassDetail> ClassDetails { get; set; } = new List<ClassDetail>();

    public virtual Role FkIdRolesNavigation { get; set; } = null!;
}
