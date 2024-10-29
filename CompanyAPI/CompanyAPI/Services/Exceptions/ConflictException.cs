namespace CompanyAPI.Services.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public ConflictException(string? message) : base(message)
        {
        }
    }
}
