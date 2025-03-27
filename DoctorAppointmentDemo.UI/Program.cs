using DoctorAppointmentDemo.UI.Menus;
using DoctorAppointment.Service.Services;
using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Service.Interfaces;

namespace DoctorAppointment
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Select data format:");
            Console.WriteLine("1 - JSON");
            Console.WriteLine("2 - XML");

            byte formatChoice = AddFuncs.GetOperation("Enter number: ", 1, 2);

            IPatientService patientService;
            IDoctorService doctorService;
            IAppointmentService appointmentService;

            switch (formatChoice)
            {
                case 1:
                    patientService = new PatientService(Constants.AppSettingsPathJson, new JsonSerializerService());
                    doctorService = new DoctorService(Constants.AppSettingsPathJson, new JsonSerializerService());
                    appointmentService = new AppointmentService(Constants.AppSettingsPathJson, new JsonSerializerService());
                    break;
                case 2:
                    patientService = new PatientService(Constants.AppSettingsPathXml, new XmlSerializerService());
                    doctorService = new DoctorService(Constants.AppSettingsPathXml, new XmlSerializerService());
                    appointmentService = new AppointmentService(Constants.AppSettingsPathXml, new XmlSerializerService());
                    break;
                default:
                    Console.WriteLine("Invalid selection. Exiting...");
                    return;
            }

            var menu = new MainMenu(
                new PatientMenu(patientService, doctorService, appointmentService),
                new DoctorMenu(patientService, doctorService, appointmentService),
                new AdminMenu(patientService, doctorService, appointmentService));

            menu.Show();
        }
    }
}