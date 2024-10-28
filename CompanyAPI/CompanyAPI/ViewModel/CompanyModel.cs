namespace CompanyAPI.ViewModel
{
    public class CompanyModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public double MonthyBilling { get; set; }

        public double Expense { get; set; } = 0;

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
