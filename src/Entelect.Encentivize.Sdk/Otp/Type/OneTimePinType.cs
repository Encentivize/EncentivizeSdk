﻿namespace Entelect.Encentivize.Sdk.Otp.Type
{
    public class OneTimePinType : IEntity
    {
        public int OneTimePinTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SystemEmailTemplateId { get; set; }
    }
}