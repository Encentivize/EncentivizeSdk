namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class AdHocTransaction : PointsTransaction, IEditableEntity<AdHocPointsInput>
    {
        public dynamic AdditionalInformation { get; set; }

        public AdHocPointsInput ToInput()
        {
            return new AdHocPointsInput
            {
                AdditionalInformation = AdditionalInformation,
                PointsToAdd = PointsValue
            };
        }

        public string GetModificationUrl()
        {
            throw new System.NotSupportedException("AdHoc transactions cannot be modified");
        }
    }
}