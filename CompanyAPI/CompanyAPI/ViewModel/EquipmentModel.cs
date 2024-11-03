using System.ComponentModel.DataAnnotations.Schema;

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
