
using System;
using Entelect.Encentivize.Sdk.Members.Members;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers
{
    public class GroupMember : IEditableEntity<GroupMemberInput>
    {
        public long GroupId { get; set; }
        public long? GroupRoleId { get; set; }
        public Member Member { get; set; }

        public GroupMember()
        {
            Member = new Member();
        }

        public GroupMemberInput ToInput()
        {
            return new GroupMemberInput
            {
                GroupRoleId = GroupRoleId,
                MemberId = Member.MemberId
            };
        }

        public string GetModificationUrl()
        {
            return GetModificationUrl(GroupId, Member.MemberId);
        }

        public static string GetModificationUrl(long groupId, long memberId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException(string.Format("Invalid groupId : {0}, must be a positive long",groupId));
            }
            if (memberId <= 0)
            {
                throw new ArgumentException(string.Format("Invalid groupId : {0}, must be a positive long", groupId));
            }
            return string.Format("Groups/{0}/Members/{1}", groupId, memberId);
        }
    }
}