
namespace Entelect.Encentivize.Sdk
{
    public interface IEditableEntity<out TInput> : IEntity
        where TInput : BaseInput
    {
        TInput ToInput();
        string GetModificationUrl();
    }
}