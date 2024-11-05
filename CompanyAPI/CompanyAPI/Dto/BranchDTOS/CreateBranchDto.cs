using CompanyAPI.ViewModel;
using CompanyAPI.ViewModel.DateModel;
using System.Text.Json.Serialization;

namespace CompanyAPI.Dto.BranchDTOS
{
    public class CreateBranchDto
    {
        public int CompanyLinkedID { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [JsonConverter(typeof(CustomDate))]
        public DateTime CreationDate { get; set; }
    }
}
