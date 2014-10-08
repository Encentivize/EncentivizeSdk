namespace Entelect.Encentivize.Sdk
{
    public interface IBaseOutput<TInput>
        where TInput : BaseInput
    {
        TInput ToInput();
        string GetIdentityUrlString();
    }
}