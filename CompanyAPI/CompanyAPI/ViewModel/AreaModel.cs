using CompanyAPI.ViewModel.DateModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    [Table("Areas")]
    public class AreaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of area is required")]
        public string NameArea { get; set; }

        public int BranchId { get; set; }

        public BranchModel LinkedBranch { get; set; }

        public string Description { get; set; }

        [JsonConverter(typeof(CustomDate))]
        public DateTime CreationDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Expense { get; set; }

        public double EmployeesExpense { get; set; }

        public double EquipmentsExpense { get; set; }

        public int EmployeeCount => Employees?.Count ?? 0;

        public int EquipmentCount => Equipments?.Count ?? 0;

        public ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();

        public ICollection<EquipmentModel> Equipments { get; set; } = new List<EquipmentModel>();


        public AreaModel()
        {

        }

        public AreaModel(int id, string nameArea, BranchModel branch)
        {
            Id = id;
            NameArea = nameArea;
            LinkedBranch = branch;
          
        }

    }
}
