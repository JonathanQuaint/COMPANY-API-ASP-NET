using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    [Table("Branchs")]
    public class BranchModel
    {
        public int Id { get; set; }
        public string HeadOffice { get; set; }

        public int CompanyID { get; set; }

        public CompanyModel CompanyLinked { get; set; }

        [JsonIgnore]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Expense { get; set; }  

        public double AreasExpense { get; set; }

        public double EquipmentsExpense { get; set; }

        public double EmployeesExpense { get; set; }

        [JsonIgnore]
        public ICollection<AreaModel> Areas { get; set; } = new List<AreaModel>();

        [JsonIgnore]
        public ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();

        [JsonIgnore]
        public ICollection<EquipmentModel> Equipments { get; set; } = new List<EquipmentModel>();


        public BranchModel()
        { 
        }

        public BranchModel(int id, string headOffice)
        {
            Id = id;
            HeadOffice = headOffice;
          
        }
    }
}
