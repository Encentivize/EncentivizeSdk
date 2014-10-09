using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public class EditSupportTicketInput : BaseInput
    {
        [Required]
        public string NewComment { get; set; }

        public bool IsResolved { get; set; }
    }
}