﻿using Entelect.Encentivize.Sdk.GenericServices;

namespace Entelect.Encentivize.Sdk.Program
{
    public class ProgramsClient : IProgramsClient
    {
        private readonly IEntityRetrievalService<ProgramOutput> _entityRetrievalService;
        public ProgramsClient(IEncentivizeRestClient restClient)
        {
            var entitySettings = new EntitySettings("Program", "Programs", "Programs");
            _entityRetrievalService = new EntityRetrievalService<ProgramOutput>(restClient, entitySettings);
        }

        public ProgramOutput Get()
        {
            return _entityRetrievalService.Get("Programs");
        }
    }
}