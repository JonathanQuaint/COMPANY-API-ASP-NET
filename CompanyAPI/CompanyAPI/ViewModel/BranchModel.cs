using CompanyAPI.ViewModel.DateModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    [Table("Branchs")]
    public class BranchModel
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public CompanyModel CompanyLinked { get; set; }

        [Required(ErrorMessage = "The state is required")]
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [JsonConverter(typeof(CustomDate))]
        public DateTime CreationDate { get; set; }
        public int EmployeeCount => Employees?.Count ?? 0;
        public int EquipmetCount => Equipments?.Count ?? 0;
        public int AreasCount => Areas?.Count ?? 0;

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Expense { get; set; }

        public double AreasExpense { get; set; }

        public double EquipmentsExpense { get; set; }

        public double EmployeesExpense { get; set; }

        public ICollection<AreaModel> Areas { get; set; } = new List<AreaModel>();

        public ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();

        public ICollection<EquipmentModel> Equipments { get; set; } = new List<EquipmentModel>();


        public BranchModel()
        {
        }

        public BranchModel(int id, string state)
        {
            Id = id;
            State = state;

        }
    }
}
