namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityCreationService<in TInput, TEntity> 
        where TInput : BaseInput
        where TEntity : class, IEditableEntity<TInput>, new()
    {
        TEntity Create(TInput input);
        TEntity Create(string customPath, TInput input);
        TEntity Create(TEntity entity);
        void CreateExpectNullResponse(TInput input);
        void CreateExpectNullResponse(string customPath, TInput input);
        void CreateExpectNullResponse(TEntity entity);
    }
}