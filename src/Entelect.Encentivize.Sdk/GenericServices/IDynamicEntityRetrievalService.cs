using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IDynamicEntityRetrievalService
    {
        dynamic GetById(int id);
        dynamic GetById(long id);
        dynamic GetById(Guid id);
        dynamic Get(string customPath);
    }
}