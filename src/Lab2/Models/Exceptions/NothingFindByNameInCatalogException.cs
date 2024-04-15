using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions;

public class NothingFindByNameInCatalogException : Exception
{
    public NothingFindByNameInCatalogException()
    {
    }

    public NothingFindByNameInCatalogException(string message)
        : base(message)
    {
    }

    public NothingFindByNameInCatalogException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}