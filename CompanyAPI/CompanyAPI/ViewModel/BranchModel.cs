﻿using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    public class BranchModel
    {
        public int Id { get; set; }
        public string HeadOffice { get; set; }
        public double Expense { get; set; }

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