using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityRetrievalService<TOutput> 
        where TOutput : class, new()
    {
        TOutput GetById(int id, bool returnDynamic = false);
        TOutput GetById(long id, bool returnDynamic = false);
        TOutput GetById(Guid id, bool returnDynamic = false);
        TOutput Get(string customPath, bool returnDynamic = false);
        PagedResult<TOutput> FindBySearchCriteria(BaseSearchCriteria searchCriteria);
        PagedResult<TOutput> FindBySearchCriteria(string customPath, BaseSearchCriteria searchCriteria);
    }
}