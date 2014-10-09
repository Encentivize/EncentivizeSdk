namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers
{
    public class GroupMemberInput: BaseInput
    {
        public long MemberId { get; set; }
        public long? GroupRoleId { get; set; }
    }
}