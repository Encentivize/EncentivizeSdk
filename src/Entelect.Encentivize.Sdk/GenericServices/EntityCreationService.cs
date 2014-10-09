using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntityCreationService<TInput, TEntity> : BaseCreationService, IEntityCreationService<TInput, TEntity> 
        where TInput : BaseInput
        where TEntity : class, IEditableEntity<TInput>, new()
    {
        public EntityCreationService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        public TEntity Create(TInput input)
        {
            return DoCreate(new RestRequest(string.Format("{0}", EntitySettings.BaseRoute)), input);
        }

        public TEntity Create(TEntity entity)
        {
            return Create(entity.ToInput());
        }

        public TEntity Create(string customPath, TInput input)
        {
            return DoCreate(new RestRequest(customPath), input);
        }
        
        public void CreateExpectNullResponse(TInput input)
        {
            DoCreateExpectNullResponse(new RestRequest(string.Format("{0}", EntitySettings.BaseRoute)), input);
        }

        public void CreateExpectNullResponse(TEntity entity)
        {
            CreateExpectNullResponse(entity.ToInput());
        }

        public void CreateExpectNullResponse(string customPath, TInput input)
        {
            DoCreateExpectNullResponse(new RestRequest(customPath), input);
        }

        protected virtual TEntity DoCreate(RestRequest restRequest, TInput input)
        {
            input.Validate();
            PrepareCreateRequest(restRequest, input);
            var response = RestClient.Execute<TEntity>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
            return response.Data;
        }

        protected virtual void DoCreateExpectNullResponse(RestRequest restRequest, TInput input)
        {
            input.Validate();
            PrepareCreateRequest(restRequest, input);
            var response = RestClient.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
        }
    }

    public class EntityCreationService<TInput> : BaseCreationService, IEntityCreationService<TInput>
        where TInput : BaseInput
    {
        public EntityCreationService(IEncentivizeRestClient restClient, EntitySettings entitySettings) 
            : base(restClient, entitySettings)
        {
        }

        public void Create(TInput input)
        {
            DoCreate(new RestRequest(string.Format("{0}", EntitySettings.BaseRoute)), input);
        }

        public void Create(string customPath, TInput input)
        {
            DoCreate(new RestRequest(customPath), input);
        }

        protected virtual void DoCreate(RestRequest restRequest, TInput input)
        {
            input.Validate();
            PrepareCreateRequest(restRequest, input);
            var response = RestClient.Execute(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
        }
    }

    public class EntityCreationService : BaseCreationService, IEntityCreationService
    {
        public EntityCreationService(IEncentivizeRestClient restClient)
            : base(restClient, new EntitySettings("dynamic", "dynamic",null))
        {
            
        }


        public dynamic Create(dynamic input)
        {
            return DoCreate(new RestRequest(string.Format("{0}", EntitySettings.BaseRoute)), input);
        }

        public dynamic Create(string customPath, dynamic input)
        {
            return DoCreate(new RestRequest(customPath), input);
        }

        protected virtual dynamic DoCreate(RestRequest restRequest, dynamic input)
        {
            PrepareCreateRequest(restRequest, input);
            var response = RestClient.Execute<dynamic>(restRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new CreationFailedException(response);
            }
            return response.Data;
        }
    }
}