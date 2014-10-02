namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers
{
    public class MemberGroupInput: BaseInput
    {
        public long MemberId { get; set; }
        public long? GroupRoleId { get; set; }
    }
}