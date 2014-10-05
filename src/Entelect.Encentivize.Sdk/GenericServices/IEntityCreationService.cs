namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityCreationService<TInput, TOutput> where TInput : BaseInput where TOutput : class, new()
    {
        TOutput Create(TInput input);
        TOutput Create(string customPath, TInput input);
    }
}