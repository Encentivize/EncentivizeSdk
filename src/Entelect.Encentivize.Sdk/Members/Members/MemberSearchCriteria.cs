using System;

namespace Entelect.Encentivize.Sdk.Members.Members
{
    public class MemberSearchCriteria : BaseSearchCriteria
    {
        public long? MemberId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public int? LifetimePoints { get; set; }
        public int? CurrentPoints { get; set; }
        public string ExternalReferenceCode { get; set; }
        public long? StructureId { get; set; }
        public int? MemberStatusId { get; set; }
        public long? MemberTypeId { get; set; }
        public DateTime? CreatedDateUtcFrom { get; set; }
        public DateTime? CreatedDateUtcTo { get; set; }
        public long? RoleId { get; set; }
        public DateTime? LastLoginDateUtcFrom { get; set; }
        public DateTime? LastLoginDateUtcTo { get; set; }
    }
}