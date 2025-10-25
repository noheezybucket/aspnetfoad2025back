using System.ComponentModel.DataAnnotations;

namespace WebApIFaod2025.Entities
{
    public class Client:UsersColis
    {
        [MaxLength(160),  Required(ErrorMessage = "^*")]
        public String CodeClient { get; set; }
    }
}
