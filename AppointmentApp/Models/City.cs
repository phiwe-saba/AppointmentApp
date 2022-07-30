using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        [DisplayName("City Name")]
        public string CityName { get; set; }
    }
}
