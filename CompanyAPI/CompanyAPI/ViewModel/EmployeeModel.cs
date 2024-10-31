using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AreaId { get; set; }
     
        public AreaModel AreaLinked { get; set; }

        public double Salary { get; set; }

        public EmployeeModel() { }
        public EmployeeModel(string name, AreaModel area)
        {
            Name = name;
            AreaLinked = area;
        }


    }
}
