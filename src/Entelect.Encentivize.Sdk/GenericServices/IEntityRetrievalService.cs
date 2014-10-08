using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityRetrievalService<TEntity>
        where TEntity : class, IEntity, new()
    {
        TEntity GetById(int id);
        TEntity GetById(long id);
        TEntity GetById(Guid id);
        TEntity Get(string customPath);
        PagedResult<TEntity> FindBySearchCriteria(BaseSearchCriteria searchCriteria);
        PagedResult<TEntity> FindBySearchCriteria(string customPath, BaseSearchCriteria searchCriteria);
    }

    public interface IEntityRetrievalService
    {
        dynamic Get(string customPath);
        PagedResult<dynamic> FindBySearchCriteria(BaseSearchCriteria searchCriteria);
        PagedResult<dynamic> FindBySearchCriteria(string customPath, BaseSearchCriteria searchCriteria);
    }
}