﻿namespace QuickHealthClinic.Configurations.Exceptions
{
    public class NotFoundApiException : ApiException
    {
        public NotFoundApiException()
        {
        }

        public NotFoundApiException(string message) : base(message)
        {
        }

        public NotFoundApiException(string resource, string key) : base($"{resource} with key {key} not found.")
        {
        }
    }
}
