using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    public class AreaModel
    {
        public int Id { get; set; }

        public string NameArea { get; set; }

        public BranchModel LinkedBranch { get; set; }

        public double Expense { get; set; }

        [JsonIgnore]
        public ICollection<EmployeeModel> Employees { get; set; }

        [JsonIgnore]
        public ICollection<EquipmentModel> Equipments { get; set; }

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
