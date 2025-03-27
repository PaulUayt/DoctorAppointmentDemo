using DoctorAppointment.Service.Interfaces;

namespace DoctorAppointmentDemo.UI.Menus
{
    class DoctorMenu
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public DoctorMenu(IPatientService patientService, IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }
    }
}
