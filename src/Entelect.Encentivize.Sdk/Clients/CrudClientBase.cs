using System;
using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Clients
{
    public class CrudClientBase<TInput, TOutput> : ReadOnlyClientBase<TOutput>, ICrudClientBase<TInput, TOutput> 
        where TInput : BaseInput
        where TOutput : class, new()
    {
        private readonly IEntityUpdateService<TInput, TOutput> _entityUpdateService;
        private readonly IEntityCreationService<TInput, TOutput> _entityCreationService;
        private readonly IEntityDeletionService _entityDeletionService;

        public CrudClientBase(
            IEntityUpdateService<TInput, TOutput> entityUpdateService,
            IEntityRetrievalService<TOutput> entityRetrievalService,
            IEntityCreationService<TInput, TOutput> entityCreationService,
            IEntityDeletionService entityDeletionService)
            : base(entityRetrievalService)
        {
            _entityUpdateService = entityUpdateService;
            _entityCreationService = entityCreationService;
            _entityDeletionService = entityDeletionService;
        }

        #region Update

        public virtual TOutput Update(int id, TInput input)
        {
            return _entityUpdateService.Update(id, input);
        }

        public virtual TOutput Update(long id, TInput input)
        {
            return _entityUpdateService.Update(id, input);
        }

        public virtual TOutput Update(Guid id, TInput input)
        {
            return _entityUpdateService.Update(id, input);
        }

        public virtual TOutput Update(string id, TInput input)
        {
            return _entityUpdateService.Update(id, input);
        }

        #endregion

        #region Create

        public TOutput Create(TInput input)
        {
            return _entityCreationService.Create(input);
        }

        #endregion

        #region Delete

        public virtual void Delete(int id)
        {
            _entityDeletionService.Delete(id);
        }

        public virtual void Delete(long id)
        {
            _entityDeletionService.Delete(id);
        }

        public virtual void Delete(Guid id)
        {
            _entityDeletionService.Delete(id);
        }

        public virtual void Delete(string id)
        {
            _entityDeletionService.Delete(id);
        }

        #endregion
    }
}