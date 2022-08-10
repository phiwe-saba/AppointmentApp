using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class Appointment
    {
        [Key]
        public int AppId { get; set; }
        [Required]
        [DisplayName("Appointment Date")]
        public DateTime AppDate { get; set; }
        [Required]
        [DisplayName("Appointment Time")]
        public DateTime AppTime { get; set; }
        [Required]
        [DisplayName("Appointment Status")]
        public string AppStatus { get; set; }
        public int PatientId { get; set; }
        public Patient Patients { get; set; }
        public int Doctor { get; set; }
        public Doctor Doctors { get; set; }
    }
}
