using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityRetrievalService<TOutput,TInput>
        where TInput: BaseInput
        where TOutput : class, IBaseOutput<TInput>, new()
    {
        TOutput GetById(int id);
        TOutput GetById(long id);
        TOutput GetById(Guid id);
        TOutput Get(string customPath);
        PagedResult<TOutput> FindBySearchCriteria(BaseSearchCriteria searchCriteria);
        PagedResult<TOutput> FindBySearchCriteria(string customPath, BaseSearchCriteria searchCriteria);
    }
}