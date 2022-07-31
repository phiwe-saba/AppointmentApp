using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Address Line")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        [DisplayName("Suburb Name")]
        public int SuburbId { get; set; }
        public Suburb Suburb { get; set; }
        //public ICollection<Appointment> Appointments { get; set; }
    }
}
