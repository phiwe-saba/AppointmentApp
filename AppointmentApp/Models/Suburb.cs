using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class Suburb
    {
        [Key]
        public int SuburbId { get; set; }
        [Required]
        [DisplayName("Suburb Name")]
        public string SuburbName { get; set; }
        [Required]
        [DisplayName("Postal Code")]
        public int PostalCode { get; set; }
        [Required]
        [DisplayName("City Name:")]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
