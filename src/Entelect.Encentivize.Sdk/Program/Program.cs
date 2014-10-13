using System;

namespace Entelect.Encentivize.Sdk.Program
{
    public class Program : IEntity
    {
        public string SystemURL { get; set; }
        public long ProgramId { get; set; }
        public int? ResellerId { get; set; }
        public string Name { get; set; }
        public decimal Ratio { get; set; }
        public bool IsActive { get; set; }
        public bool IsDemoSite { get; set; }
        public string PrimaryColour { get; set; }
        public string SecondaryColour { get; set; }
        public string LogoExtension { get; set; }
        public string PointsIconExtension { get; set; }
        public string CurrencyIconExtension { get; set; }
        public string PortalName { get; set; }
        public string GlobalBccEmailAddresses { get; set; }
        public long? ActiveDirectoryDetailId { get; set; }
        public bool KudosEnabled { get; set; }
        public bool SendWeeklySummaryToMembers { get; set; }
        public bool PartnerPlatformStoreEnabled { get; set; }
        public DateTime? ExpiryDateUtc { get; set; }
        public long CreatedById { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public long? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUtc { get; set; }
        public byte SyncAttempts { get; set; }
        public DateTime? LastSyncAttemptUtc { get; set; }
        public DateTime? LastSyncDateUtc { get; set; }
        public bool AllowDecimalsInPoints { get; set; }

    }
}