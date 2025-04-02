using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointment.UI.Menus.Enums;

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

        public void Show()
        {
            while (true)
            {
                AddFuncs.DisplayMenuHeader("Functional Page of Doctor");

                if (!AddFuncs.GetConfirmation("Are you registered doctor?"))
                {
                    RegistrationDoctor();
                    continue;
                }

                AddFuncs.DisplayMenuHeader("Functional Page of Doctor");

                Console.Write("Enter your phone number: ");
                string? phone = Console.ReadLine();

                if (!CheckDoctor(phone) || string.IsNullOrEmpty(phone))
                {
                    Console.WriteLine("Doctor with this phone number is not found. Please register.\n");
                    RegistrationDoctor();
                    continue;
                }

                Console.WriteLine("You are logged in successfully!\n\n");

                DoctorMenuShow(phone);
            }
        }

        private void DoctorMenuShow(string phone)
        {
            while (true)
            {
                AddFuncs.DisplayMenuHeader("Functional Page of Doctor");
                Console.WriteLine("1. Show my info.");
                Console.WriteLine("2. Update my info.");
                Console.WriteLine("3. Show patients list.");
                Console.WriteLine("4. Create appointment.");
                Console.WriteLine("5. Show my appointments.");
                Console.WriteLine("0. Exit");

                var doctorOption = (DoctorMenuOption)AddFuncs.GetOperation("\nEnter number: ", 0, 5);

                switch (doctorOption)
                {
                    case DoctorMenuOption.Exit:
                        return;
                    case DoctorMenuOption.ShowMyInfo:
                        ShowDoctorInfo(phone);
                        break;
                    case DoctorMenuOption.UpdateMyInfo:
                        UpdateDoctorInfo();
                        break;
                    case DoctorMenuOption.ShowPatientsList:
                        ShowPatientsList();
                        break;
                    case DoctorMenuOption.CreateAppointment:
                        CreateAppointment();
                        break;
                    case DoctorMenuOption.ShowMyAppointments:
                        ShowMyAppointments();
                        break;
                }
            }
        }

        private void ShowMyAppointments()
        {
            throw new NotImplementedException();
        }

        private void CreateAppointment()
        {
            throw new NotImplementedException();
        }

        private void ShowPatientsList()
        {
            var patients = _patientService.GetAll();
            if (patients.Count() == 0)
            {
                Console.WriteLine("There are no patients in the system.");
                return;
            }
            foreach (var patient in patients)
            {
                _patientService.ShowInfo(patient);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdateDoctorInfo()
        {
            throw new NotImplementedException();
        }

        private void ShowDoctorInfo(string phone)
        {
            var doctor = _doctorService.Get(phone);

            Console.WriteLine();
            if (doctor != null) _doctorService.ShowInfo(doctor);
            else Console.WriteLine("Patient with this phone number is not found.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private bool CheckDoctor(string? phone) => _doctorService.GetAll().Any(p => p.Phone == phone);

        private void RegistrationDoctor()
        {
            Console.WriteLine("\nYou need to register.\n\nEnter info:");

            var newDoctor = new Doctor
            {
                Name = AddFuncs.GetRequiredInput("Name"),
                Surname = AddFuncs.GetRequiredInput("Surname"),
                Phone = GetUniquePhone(),
                Email = AddFuncs.GetOptionalInput("Email"),
                DoctorType = GetDoctorType(),
                Experience = (byte)AddFuncs.GetNumeInput("Experience"),
                Salary = AddFuncs.GetNumeInput("Salary"),
            };
  

            _doctorService.Create(newDoctor);
            Console.WriteLine("You are registered successfully!\n\nEnter any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static DoctorTypes GetDoctorType()
        {
            Console.WriteLine("List of doctor types:");
            foreach (DoctorTypes illness in Enum.GetValues(typeof(DoctorTypes)))
            {
                Console.WriteLine($"{(int)illness} - {illness}");
            }
            return (DoctorTypes)AddFuncs.GetOperation("Doctor type: ", 1, 4);
        }

        private string GetUniquePhone()
        {
            string phone;
            do
            {
                phone = AddFuncs.GetRequiredInput("Phone");
                if (CheckDoctor(phone))
                {
                    Console.WriteLine("Patient with this phone number already exists. Please enter another phone number.");
                }
            } while (CheckDoctor(phone));
            return phone;
        }        
    }
}
