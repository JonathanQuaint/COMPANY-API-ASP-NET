using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    [Table("Companys")]
    public class CompanyModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double MonthlyBilling { get; set; }


        [JsonIgnore]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Expense { get; set; }

      
        public ICollection<BranchModel> Branch { get; set; } = new List<BranchModel>();

        public CompanyModel()
        {
        }

        public CompanyModel(string name, double monthyBilling)
        {
            Name = name;
            MonthlyBilling = monthyBilling;
        }

           

    }
}
