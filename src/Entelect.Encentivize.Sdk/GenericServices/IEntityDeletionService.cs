using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityDeletionService<TInput, in TEntity>
        where TInput : BaseInput
        where TEntity : class, IEditableEntity<TInput>, new()
    {
        void Delete(int id);
        void Delete(long id);
        void Delete(Guid id);
        void Delete(string customPath);
        void Delete(TEntity entity);
    }
}