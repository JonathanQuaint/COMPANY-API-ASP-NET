namespace CompanyAPI.Dto.BranchDTOS
{
    public class EditBranchDto
    {
        public int IdBranch { get; set; }
        public int CompanyLinkedID { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
