using CompanyAPI.ViewModel.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Dto.CompanyDTOS
{
    public class EditCompanyDTOS
    {
        public int IdOfCompany { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public CompanyTypeEnum CompanyType { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double MonthlyBilling { get; set; } = 0.0;






    }
}
