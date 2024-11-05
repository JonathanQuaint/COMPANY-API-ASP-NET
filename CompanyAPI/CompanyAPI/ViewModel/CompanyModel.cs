using CompanyAPI.ViewModel.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    [Table("Companies")]
    public class CompanyModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of company is required")]
        public string Name { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public CompanyTypeEnum CompanyType { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double MonthlyBilling { get; set; } = 0.0;

        [DisplayFormat(DataFormatString = "{0:F2}")] 
        public double Expense { get; set; } = 0.0;

        public ICollection<BranchModel> Branch { get; set; } = new List<BranchModel>();

        public CompanyModel()
        {
        }

        public CompanyModel(string name, double monthlyBilling, string country)
        {
            Name = name;
            MonthlyBilling = monthlyBilling;
            Country = country;
        }



    }
}
