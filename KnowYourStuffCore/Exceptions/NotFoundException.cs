using System;

namespace KnowYourStuffCore.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not found") {}
    }
}