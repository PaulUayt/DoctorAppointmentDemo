using DoctorAppointment.Service.Interfaces;

namespace DoctorAppointmentDemo.UI.Menus
{
    class AdminMenu
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public AdminMenu(IPatientService patientService, IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }
    }
}
