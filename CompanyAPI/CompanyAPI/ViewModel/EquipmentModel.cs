using CompanyAPI.ViewModel.DateModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyAPI.ViewModel
{
    [Table("Equipments")]
    public class EquipmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AreaId { get; set; }

        public AreaModel AreaLinked { get; set; }

        public double Price { get; set; }

        [JsonConverter(typeof(CustomDate))]
        public DateTime AcquisitionDate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public EquipmentModel()
        {
            
        }

        public EquipmentModel(int id, string name, double price, AreaModel area)
        {
            Id = id;
            Name = name;
            Price = price;
            AreaLinked = area;
        }
    }
}
