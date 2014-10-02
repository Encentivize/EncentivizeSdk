using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.Members.Members
{
    public class MemberInput
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(255)]
        public string EmailAddress { get; set; }

        [StringLength(15)]
        public string MobileNumber { get; set; }
        
        [StringLength(50)]
        public string ExternalReferenceCode { get; set; }

        public bool? CanSpendPoints { get; set; }
        public bool? CanEarnPoints { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long StructureId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public int MemberStatusId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long MemberTypeId { get; set; }

        public string ProfilePictureUrl { get; set; }
    }
}