using Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes;

namespace Entelect.Encentivize.Sdk.Achievements.GroupTypes
{
    public interface IGroupTypeClient
    {
        GroupTypeOutput Get(long groupTypeId);
        PagedResult<GroupTypeOutput> Search(GroupTypeSearchCriteria groupTypeSearchCriteria);
        GroupTypeOutput Create(GroupTypeInput groupTypeInput);
        GroupTypeOutput Update(long groupTypeId, GroupTypeInput groupTypeInput);
        void Delete(long groupTypeId);
    }
}