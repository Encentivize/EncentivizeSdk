using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Program
{
    public class ProgramsClient : IProgramsClient
    {
        private readonly IEntityRetrievalService<Program> _entityRetrievalService;

        public ProgramsClient(IEntityRetrievalService<Program> entityRetrievalService)
        {
            _entityRetrievalService = entityRetrievalService;
        }

        public ProgramsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Program", "Programs", "Programs");
            _entityRetrievalService = new EntityRetrievalService<Program>(restClient, entitySettings);
        }

        public virtual Program Get()
        {
            return _entityRetrievalService.Get("Programs");
        }
    }
}