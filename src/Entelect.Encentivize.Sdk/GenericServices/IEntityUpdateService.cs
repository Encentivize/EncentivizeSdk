using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityUpdateService<in TInput, TEntity> 
        where TInput : BaseInput
        where TEntity : class, IEditableEntity<TInput>, new()
    {
        TEntity Update(int id, TInput input);
        TEntity Update(long id, TInput input);
        TEntity Update(Guid id, TInput input);
        TEntity Update(string customPath, TInput input);
        TEntity Update(TEntity entity);
    }
}