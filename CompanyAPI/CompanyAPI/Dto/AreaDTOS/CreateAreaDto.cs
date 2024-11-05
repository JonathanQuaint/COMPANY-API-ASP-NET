using CompanyAPI.ViewModel.DateModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompanyAPI.Dto.AreaDTOS
{
    public class CreateAreaDto
    {
        public string NameArea { get; set; }

        public int BranchLinkedId { get; set; }

        public string Description { get; set; }

        [JsonConverter(typeof(CustomDate))]
        public DateTime CreationDate { get; set; }

     

    }
}
