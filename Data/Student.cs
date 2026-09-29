using System.ComponentModel.DataAnnotations;

namespace Gurin_0._5.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
