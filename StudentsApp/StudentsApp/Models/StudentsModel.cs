using System.ComponentModel;
namespace StudentsApp.Models
{
    public class StudentsModel
    {
        public int Id { get; set; }
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
