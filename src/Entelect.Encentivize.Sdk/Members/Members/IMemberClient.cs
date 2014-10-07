namespace Entelect.Encentivize.Sdk.Members.Members
{
    public interface IMemberClient
    {
        MemberOutput GetMe();
        PagedResult<MemberOutput> Search(MemberSearchCriteria memberSearchCriteria);
        MemberOutput Get(long memberId);
        MemberOutput UpdateMember(long memberId, MemberInput memberInput);
        MemberOutput UpdateMember(MemberOutput memberOutput);
        MemberOutput CreateMember(MemberInput memberInput);
        dynamic GetTimestoreForMember(long memberId);
        void WriteTimestoreForMember(long memberId, dynamic timestoreData);
        void ResetPasswordPin(long memberId);
    }
}