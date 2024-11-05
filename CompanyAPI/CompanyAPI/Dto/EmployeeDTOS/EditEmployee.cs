namespace CompanyAPI.Dto.EmployeeDTOS
{
    public class EditEmployee
    {
        public int Id { get; set; }

        public int AreaId { get; set; }

        public string NameEmployee { get; set; }

        public double Salary { get; set; }

        public string IdentificationNumber { get; set; }

        public string Position { get; set; }
        public string Department { get; set; }

    }
}
