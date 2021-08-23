using System;

namespace Domain.Exceptions
{
    //custom exceptions makes it easier to catch different user input errors
    public class InvalidIdException : Exception { }
    public class DuplicateIdException : Exception { }
    public class EmptyIdException : Exception { }
    public class EmptyTitleException : Exception { }
    public class EmptyDescriptionException : Exception { }
    public class EmptyPriceException : Exception { }
    public class InvalidPriceException : Exception { }
}
