using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRazorApp.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


   

    public class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Org")]
        public int OrganizationId { get; set; } // Foreign key to Organization

        public Organization? Org { get; set; } //
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        [ForeignKey("Dept")]
        public int DepartmentId { get; set; } // Foreign key to Department
        public Department? Dept { get; set; } // Navigation property to Department
    }
}
