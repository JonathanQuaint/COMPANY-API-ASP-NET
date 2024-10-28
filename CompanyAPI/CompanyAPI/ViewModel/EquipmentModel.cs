namespace CompanyAPI.ViewModel
{
    public class EquipmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AreaModel Area { get; set; }

        public double Price { get; set; }


        public EquipmentModel()
        {
            
        }

        public EquipmentModel(int id, string name, double price, AreaModel area)
        {
            Id = id;
            Name = name;
            Price = price;
            Area = area;
        }
    }
}
