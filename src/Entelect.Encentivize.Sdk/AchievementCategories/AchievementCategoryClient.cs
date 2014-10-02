using Entelect.Encentivize.Sdk.Clients;

namespace Entelect.Encentivize.Sdk.AchievementCategories
{
    public class AchievementCategoryClient : CrudClientBase<AchievementCategoryInput,AchievementCategoryOutput>, IAchievementCategoryClient
    {
        public AchievementCategoryClient(EncentivizeSettings settings)
            : base(settings, "AchievementCategories")
        {
        }
    }
}