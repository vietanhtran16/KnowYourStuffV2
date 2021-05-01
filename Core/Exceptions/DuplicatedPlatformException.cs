using System;

namespace KnowYourStuffCore.Exceptions
{
    public class DuplicatedPlatformException : Exception
    {
        public DuplicatedPlatformException(string name): base($"Platform with name of {name} already exists") {}
    }
}