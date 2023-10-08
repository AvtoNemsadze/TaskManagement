﻿namespace TaskManagement.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name}({key}) wast not found")
        {

        }
    }
}
