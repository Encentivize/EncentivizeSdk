using Entelect.Encentivize.Sdk.Clients;
using Entelect.Encentivize.Sdk.GenericServices;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Achievements.AchievementCategories
{
    public class AchievementCategoryClient : CrudClientBase<AchievementCategoryInput,AchievementCategoryOutput>, IAchievementCategoryClient
    {
        public AchievementCategoryClient(IRestClient restClient)
            : base(new EntityUpdateService<AchievementCategoryInput, AchievementCategoryOutput>(restClient,"AchievementCategories"),
            new EntityRetrievalService<AchievementCategoryOutput>(restClient, "AchievementCategories"),
            new EntityCreationService<AchievementCategoryInput, AchievementCategoryOutput>(restClient, "AchievementCategories"),
            new EntityDeletionService(restClient, "AchievementCategories"))
        {
        }
    }
}