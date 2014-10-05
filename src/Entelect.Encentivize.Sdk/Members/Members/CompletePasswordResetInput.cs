using System;

namespace Entelect.Encentivize.Sdk.Members.Members
{
    public class CompletePasswordResetInput : BaseInput
    {
        public String Guid { get; set; }

        public String Password { get; set; }
    }
}
