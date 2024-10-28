using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        [JsonIgnore]
        public AreaModel Area { get; set; }

        public EmployeeModel() { }
        public EmployeeModel(string name, AreaModel area)
        {
            Name = name;
            Area = area;
        }


    }
}
