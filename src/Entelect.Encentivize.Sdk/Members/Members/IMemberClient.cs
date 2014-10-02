using Entelect.Encentivize.Sdk.Members.Members;

namespace Entelect.Encentivize.Sdk.Members
{
    public interface IMemberClient
    {
        MemberOutput GetMemberByExternalReference(string externalReference);
        MemberOutput GetMemberByMobileNumber(string mobileNumber);
        MemberOutput GetMemberByEmailAddress(string emailAddress);
        PagedResult<MemberOutput> GetMembers(int? pageSize, int? pageNumber);
        MemberOutput GetMe();
        void ResetPasswordPin(long memberId); 
        void UpdateMember(MemberInput customer, long encentivizeMemberId);
        void UpdateMember(MemberUpdate customer, long encentivizeMemberId);
        void AddMember(MemberInput customer);
        void WriteTimestoreForMember(long memberId, dynamic timestore);
        dynamic GetTimestoreForMember(long memberId);
    }
}
