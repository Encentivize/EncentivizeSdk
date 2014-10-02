using System;

namespace Entelect.Encentivize.Sdk.Clients
{
    public interface IReadOnlyClientBase<TOutput> where TOutput : class, new()
    {
        TOutput GetById(int id);
        TOutput GetById(long id);
        TOutput GetById(Guid id);
        TOutput GetById(string id);
    }
}