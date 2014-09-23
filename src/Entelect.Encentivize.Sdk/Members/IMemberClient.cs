namespace Entelect.Encentivize.Sdk.Members
{
    public interface IMemberClient
    {
        Member GetMemberByExternalReference(string externalReference);
        Member GetMemberByMobileNumber(string mobileNumber);
        Member GetMemberByEmailAddress(string emailAddress);
        PagedResult<Member> GetMembers(int? pageSize, int? pageNumber);
        Member GetMe();
        void ResetPasswordPin(long memberId); 
        void UpdateMember(MemberInput customer, long encentivizeMemberId);
        void UpdateMember(MemberUpdate customer, long encentivizeMemberId);
        void AddMember(MemberInput customer);
        void WriteTimestoreForMember(long memberId, dynamic timestore);
        dynamic GetTimestoreForMember(long memberId);
    }
}
