﻿namespace CleanArchitecture.API.Common.Errors
{
    public class Error(string code = null, string message = null)
    {
        public string Code { get; set; } = code;
        public string Message { get; set; } = message;
        public string Property { get; set; }

        public void AddErrorProperty(ErrorProperty property)
        {
            Property = property.Property;
        }
    }
}
