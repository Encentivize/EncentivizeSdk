using System;

namespace Entelect.Encentivize.Sdk.Clients
{
    public interface ICrudClientBase<TInput, TOutput> : IReadOnlyClientBase<TOutput> 
        where TInput : BaseInput 
        where TOutput : class, new()
    {
        TOutput Update(int id, TInput input);
        TOutput Update(long id, TInput input);
        TOutput Update(Guid id, TInput input);
        TOutput Update(string id, TInput input);
        TOutput Create(TInput input);
        void Delete(int id);
        void Delete(long id);
        void Delete(Guid id);
        void Delete(string id);
    }
}