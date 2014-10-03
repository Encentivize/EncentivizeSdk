using System.ComponentModel.DataAnnotations;

namespace Entelect.Encentivize.Sdk.SupportTickets
{
    public class SupportTicketInput
    {
        [Required(ErrorMessage = "Support ticket type is required")]
        public long SupportTicketTypeId { get; set; }

        [Required(ErrorMessage = "Support ticket category is required")]
        public long SupportTicketCategoryId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [Range(1,3)]
        public int SupportTicketPriorityId { get; set; }
    }
}