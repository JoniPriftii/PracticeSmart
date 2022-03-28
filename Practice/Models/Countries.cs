using Microsoft.Azure.Cosmos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? RegionsId { get; set; }
        public virtual Regions Regions { get; set; }

    }
}
