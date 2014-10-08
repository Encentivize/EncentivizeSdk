using System;

namespace Entelect.Encentivize.Sdk.Members.Members
{
    public class Member : IEditableEntity<MemberInput>
    {
        public long MemberId { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public string ExternalReferenceCode { get; set; }

        public long StructureId { get; set; }

        public decimal LifetimePoints { get; set; }

        public decimal CurrentPoints { get; set; }

        public int KudosBalance { get; set; }

        public long LifettimeRanking { get; set; }

        public MemberStatus MemberStatus { get; set; }
        
        public MemberType MemberType { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public bool CanSpendPoints { get; set; }
        
        public bool CanEarnPoints { get; set; }

        public string ProfilePictureUrl { get; set; }

        public MemberInput ToInput()
        {
            return new MemberInput()
                   {
                       CanEarnPoints = CanEarnPoints,
                       CanSpendPoints = CanSpendPoints,
                       EmailAddress = EmailAddress,
                       ExternalReferenceCode = ExternalReferenceCode,
                       FirstName = FirstName,
                       MemberStatusId = MemberStatus.MemberStatusId,
                       MemberTypeId = MemberType.MemberTypeId,
                       MobileNumber = MobileNumber,
                       ProfilePictureUrl = ProfilePictureUrl,
                       StructureId = StructureId,
                       Surname = Surname
                   };
        }

        public string GetModificationUrl()
        {
            throw new NotImplementedException();
        }
    }
}