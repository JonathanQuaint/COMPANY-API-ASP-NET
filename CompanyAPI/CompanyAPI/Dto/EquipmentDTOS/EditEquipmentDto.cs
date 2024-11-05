using CompanyAPI.ViewModel.DateModel;
using System.Text.Json.Serialization;

namespace CompanyAPI.Dto.EquipmentDTOS
{
    public class EditEquipmentDto
    {
        public int Id { get; set; }
        public int AreaId { get; set; }

        public string NameEquipment { get; set; }
        public double Price { get; set; }

        [JsonConverter(typeof(CustomDate))]
        public DateTime AcquisitionDate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }



    }
}
