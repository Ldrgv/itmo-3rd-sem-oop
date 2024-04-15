using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class RepositoryBase<T> : IRepository<T>
    where T : IName
{
    private readonly List<T> _catalog;

    protected RepositoryBase()
    {
        _catalog = new List<T>();
    }

    protected RepositoryBase(IEnumerable<T> catalog)
    {
        _catalog = catalog.ToList();
    }

    public void Add(T value)
    {
        _catalog.Add(value);
    }

    public T GetByName(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));

        T value = _catalog.First(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase)) ??
                  throw new NothingFindByNameInCatalogException($"Component with name {name} does not exist.");

        return value;
    }

    public void Update(string name, T newValue)
    {
        Delete(name);
        Add(newValue);
    }

    public void Delete(string name)
    {
        _catalog.RemoveAll(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase));
    }
}