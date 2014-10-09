namespace Entelect.Encentivize.Sdk.Members.Members
{
    public interface IMembersClient
    {
        Member GetMe();
        PagedResult<Member> Search(MemberSearchCriteria memberSearchCriteria);
        Member Get(long memberId);
        Member UpdateMember(long memberId, MemberInput memberInput);
        Member UpdateMember(Member member);
        Member CreateMember(MemberInput memberInput);
        dynamic GetTimestoreForMember(long memberId);
        void WriteTimestoreForMember(long memberId, dynamic timestoreData);
        void ResetPasswordPin(long memberId);
    }
}