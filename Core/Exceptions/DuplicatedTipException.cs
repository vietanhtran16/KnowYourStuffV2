using System;

namespace KnowYourStuffCore.Exceptions
{
    public class DuplicatedTipException : Exception
    {
        public DuplicatedTipException(string snippet): base($"Tip with snippet of '{snippet}' already exists") {}
    }
}