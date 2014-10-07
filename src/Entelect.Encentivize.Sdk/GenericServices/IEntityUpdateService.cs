using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityUpdateService<TInput, TOutput> 
        where TInput : BaseInput 
        where TOutput : class, new()
    {
        TOutput Update(int id, TInput input);
        TOutput Update(long id, TInput input);
        TOutput Update(Guid id, TInput input);
        TOutput Update(string customPath, TInput input);
        /* todo rk, implement this across all outputs */
        //TOutput Update<TOutput>(TOutput output)
        //    where TOutput : BaseOutput<TInput>;
    }
}