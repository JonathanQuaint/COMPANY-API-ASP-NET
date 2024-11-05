using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    [Table("Employees")]
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int AreaId { get; set; }
     
        public AreaModel AreaLinked { get; set; }
        public string IdentificationNumber { get; set; }

        public string Position { get; set; }
        public string Department { get; set; }

        [Range(0, double.MaxValue)]
        public double Salary { get; set; }


        public EmployeeModel() { }
        public EmployeeModel(string name, AreaModel area)
        {
            Name = name;
            AreaLinked = area;
        }


    }
}
