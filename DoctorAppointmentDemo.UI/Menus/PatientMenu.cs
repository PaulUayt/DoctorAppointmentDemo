using DoctorAppointment.UI.Menus.Enums;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.Interfaces;

namespace DoctorAppointmentDemo.UI.Menus
{
    class PatientMenu
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public PatientMenu(IPatientService patientService, IDoctorService doctorService,IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }

        public void Show()
        {
            while (true)
            {
                AddFuncs.DisplayMenuHeader("Functional Page of Patient");

                if (!AddFuncs.GetConfirmation("Are you registered patient?"))
                {
                    RegistrationPatient();
                    continue;
                }

                AddFuncs.DisplayMenuHeader("Functional Page of Patient");

                Console.Write("Enter your phone number: ");
                string? phone = Console.ReadLine();

                if (!CheckPatient(phone) || string.IsNullOrEmpty(phone))
                {
                    Console.WriteLine("Patient with this phone number is not found. Please register.\n");
                    RegistrationPatient();
                    continue;
                }

                Console.WriteLine("You are logged in successfully!\n\n");

                PatientMenuShow(phone);
            }
        }

        private void PatientMenuShow(string phone) 
        {
            while (true)
            {
                AddFuncs.DisplayMenuHeader("Functional Page of Patient");
                Console.WriteLine("1. Show my info.");
                Console.WriteLine("2. Update my info.");
                Console.WriteLine("3. Show doctors list.");
                Console.WriteLine("4. Create appointment.");
                Console.WriteLine("5. Show my appointments.");
                Console.WriteLine("0. Exit");

                var patientOption = (PatientMenuOption)AddFuncs.GetOperation("\nEnter number: ", 0, 5);

                switch (patientOption)
                {
                    case PatientMenuOption.Exit:
                        return;
                    case PatientMenuOption.ShowMyInfo:
                        ShowPatientInfo(phone);
                        break;
                    case PatientMenuOption.UpdateMyInfo:
                        UpdatePatientInfo();
                        break;
                    case PatientMenuOption.ShowDoctorsList:
                        ShowDoctorsList();
                        break;
                    case PatientMenuOption.CreateAppointment:
                        CreateAppointment();
                        break;
                    case PatientMenuOption.ShowMyAppointments:
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

        private void ShowDoctorsList()
        {
            var doctors = _doctorService.GetAll();
            if (doctors.Count() == 0)
            {
                Console.WriteLine("There are no doctors in the system.");
                return;
            }
            foreach (var doctor in doctors)
            {
                _doctorService.ShowInfo(doctor);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdatePatientInfo()
        {
            throw new NotImplementedException();
        }

        private void ShowPatientInfo(string phone)
        {
            var patient = _patientService.Get(phone);

            Console.WriteLine();
            if (patient != null) _patientService.ShowInfo(patient);
            else Console.WriteLine("Patient with this phone number is not found.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private bool CheckPatient(string? phone) => _patientService.GetAll().Any(p => p.Phone == phone);

        private void RegistrationPatient()
        {
            Console.WriteLine("\nYou need to register.\n\nEnter info:");

            var newPatient = new Patient
            {
                Name = AddFuncs.GetRequiredInput("Name"),
                Surname = AddFuncs.GetRequiredInput("Surname"),
                Phone = GetUniquePhone(),
                Email = AddFuncs.GetOptionalInput("Email"),
                IllnessType = AddFuncs.GetIllnessType(),
                Address = AddFuncs.GetOptionalInput("Address"),
                AdditionalInfo = AddFuncs.GetOptionalInput("Additional info")
            };

            _patientService.Create(newPatient);
            Console.WriteLine("You are registered successfully!\n\nEnter any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private string GetUniquePhone()
        {
            string phone;
            do
            {
                phone = AddFuncs.GetRequiredInput("Phone");
                if (CheckPatient(phone))
                {
                    Console.WriteLine("Patient with this phone number already exists. Please enter another phone number.");
                }
            } while (CheckPatient(phone));
            return phone;
        }
    }
}
