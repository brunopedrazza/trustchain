using System.ComponentModel.DataAnnotations;

namespace Trustchain.Front.Data
{
    public class Contract
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Owner { get; set; }
        [Required]
        public string OwnerCompany { get; set; }
        [Required]
        public string Hired { get; set; }
        [Required]
        public string HiredCompany { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string ConclusionDate { get; set; }
        public bool JobApproved { get; set; }
        public bool JobDone { get; set; }
    }
}