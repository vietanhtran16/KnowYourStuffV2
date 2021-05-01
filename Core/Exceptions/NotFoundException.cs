using System;

namespace KnowYourStuffCore.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, Guid id) : base($"{entityName} with id of {id} not found") {}
    }
}