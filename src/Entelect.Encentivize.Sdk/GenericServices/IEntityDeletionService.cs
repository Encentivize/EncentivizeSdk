using System;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityDeletionService
    {
        void Delete(int id);
        void Delete(long id);
        void Delete(Guid id);
        void Delete(string customPath);
    }
}