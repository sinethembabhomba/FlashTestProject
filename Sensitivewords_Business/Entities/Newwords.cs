using System.ComponentModel.DataAnnotations;
namespace Sensitivewords_Business.Entities
{
    public class Newwords
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
