﻿using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.Program;
using RestSharp;

namespace Entelect.Encentivize.Sdk.MemberGrouping.Programs
{
    public class ProgramsClient
    {
        private readonly IEntityRetrievalService<ProgramOutput> _entityRetrievalService;
        public ProgramsClient(IRestClient restClient)
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