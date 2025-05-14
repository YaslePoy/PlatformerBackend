using System.ComponentModel.DataAnnotations;

namespace PlatformerBackend.Models
{
    public class DbEntity
    {
        [Key]
        public int Id { get; set; }
    }
}