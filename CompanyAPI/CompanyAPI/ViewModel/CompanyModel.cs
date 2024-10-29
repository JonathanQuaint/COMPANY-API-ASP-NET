using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.ViewModel
{
    public class CompanyModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double MonthyBilling { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Expense { get; set; }

        public ICollection<BranchModel> Branch { get; set; } = new List<BranchModel>(); 

        public CompanyModel()
        {
        }

        public CompanyModel(string name, double monthyBilling)
        {
            Name = name;
            MonthyBilling = monthyBilling;
        }

           

    }
}
