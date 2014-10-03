using System;
using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Clients
{
    public class ReadOnlyClientBase<TOutput> : IReadOnlyClientBase<TOutput> 
        where TOutput : class, new()
    {
        private readonly IEntityRetrievalService<TOutput> _entityRetrievalService;

        public ReadOnlyClientBase(IEntityRetrievalService<TOutput> entityRetrievalService )
        {
            _entityRetrievalService = entityRetrievalService;
        }

        public virtual TOutput GetById(int id)
        {
            return _entityRetrievalService.GetById(id);
        }

        public virtual TOutput GetById(long id)
        {
            return _entityRetrievalService.GetById(id);
        }

        public virtual TOutput GetById(Guid id)
        {
            return _entityRetrievalService.GetById(id);
        }

        public virtual TOutput GetById(string id)
        {
            return _entityRetrievalService.GetById(id);
        }
    }
}