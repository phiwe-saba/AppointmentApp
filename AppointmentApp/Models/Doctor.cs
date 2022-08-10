using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
