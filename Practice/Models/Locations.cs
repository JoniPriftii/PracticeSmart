using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Models
{
    public class Locations
    {
        public int Id { get; set; }    
        public string LocationAddress { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public int StateProvince { get; set; }
        public int CountriesId { get; set; }
        
        public virtual Countries Countries { get; set; }

    }
}
