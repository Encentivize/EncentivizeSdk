namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityCreationService<in TInput, out TEntity> 
        where TInput : BaseInput
        where TEntity : class, IEntity, new()
    {
        TEntity Create(TInput input);
        TEntity Create(string customPath, TInput input);
        void CreateExpectNullResponse(TInput input);
        void CreateExpectNullResponse(string customPath, TInput input);
    }

    public interface IEntityCreationService<in TInput>
        where TInput : BaseInput
    {
        void Create(TInput input);
        void Create(string customPath, TInput input);
    }

    public interface IEntityCreationService
    {
        dynamic Create(dynamic input);
        dynamic Create(string customPath, dynamic input);
    }
}