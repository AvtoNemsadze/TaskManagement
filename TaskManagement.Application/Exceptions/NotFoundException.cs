namespace TaskManagement.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name}({key}) wast not found")
        {

        }
    }
}
