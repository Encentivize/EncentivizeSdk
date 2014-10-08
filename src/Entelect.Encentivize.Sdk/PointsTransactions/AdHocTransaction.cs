namespace Entelect.Encentivize.Sdk.PointsTransactions
{
    public class AdHocTransaction : PointsTransactionOutput, IEditableEntity<AdHocPointsInput>
    {
        public dynamic AdditionalInformation { get; set; }

        public AdHocPointsInput ToInput()
        {
            throw new System.NotImplementedException();
        }

        public string GetModificationUrl()
        {
            throw new System.NotImplementedException();
        }
    }
}