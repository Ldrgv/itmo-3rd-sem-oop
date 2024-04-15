using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public interface IRepository<T>
    where T : IName
{
    public void Add(T value);
    public T GetByName(string name);
    public void Update(string name, T newValue);
    public void Delete(string name);
}