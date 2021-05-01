using System;

namespace KnowYourStuffCore.Exceptions
{
    public class MissingPropertyException : Exception
    {
        public MissingPropertyException(string modelName, string propertyName): base($"{modelName} is missing {propertyName}") {}
    }
}