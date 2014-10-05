using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityRetrievalService<TOutput> 
        where TOutput : class, new()
    {
        TOutput GetById(int id);
        TOutput GetById(long id);
        TOutput GetById(Guid id);
        TOutput Get(string customPath);
        PagedResult<TOutput> FindBySearchCriteria(BaseSearchCriteria searchCriteria);
    }
}