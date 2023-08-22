namespace QuickHealthClinic.Configurations.Exceptions
{
    public class ApiNotFoundException : ApiException
    {
        public ApiNotFoundException()
        {
        }

        public ApiNotFoundException(string message) : base(message)
        {
        }

        public ApiNotFoundException(string resource, string key) : base($"{resource} with key {key} not found.")
        {
        }
    }
}
