using System;

namespace Entelect.Encentivize.Sdk.Members
{
    public class Member
    {
        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string ExternalReferenceCode { get; set; }
        public long StructureId { get; set; }
        public MemberStatus MemberStatus { get; set; }
        public MemberType MemberType { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string ProfilePictureUrl { get; set; }
        public decimal CurrentPoints { get; set; }
        public decimal LifetimePoints { get; set; }
        public bool CanSpendPoints { get; set; }
        public bool CanEarnPoints { get; set; }
    }
}
