namespace Entelect.Encentivize.Sdk
{
    public abstract class BaseOutput<TInput>
        where TInput : BaseInput
    {
        public abstract TInput ToInput();
        public abstract string GetIdentityUrlString();
    }
}