using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
            _appointmentService = new AppointmentService();
        }

        private enum MainMenuOption
        {
            Exit = 0,
            Patient = 1,
            Doctor = 2,
            Administrator = 3
        }

        private enum PatientMenuOption
        {
            Exit = 0,
            ShowMyInfo = 1,
            UpdateMyInfo = 2,
            ShowDoctorsList = 3,
            CreateAppointment = 4,
            ShowMyAppointments = 5
        }

        private enum DoctorMenuOption
        {
            Exit = 0,
        }

        private enum AdministratorMenuOption
        {
            Exit = 0,
        }

        public void Menu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("| Doctor Appointment System |");
                Console.WriteLine("-----------------------------\n");
                Console.WriteLine("1. Functional Page for Patient.");
                Console.WriteLine("2. Functional Page for Doctor.");
                Console.WriteLine("3. Functional Page for Administrator.");
                Console.WriteLine("0. Exit.\n");

                MainMenuOption operation = (MainMenuOption)GetOperation("\nEnter number: ", 3);

                switch (operation)
                {
                    case MainMenuOption.Exit:
                        isRunning = false;
                        break;

                    case MainMenuOption.Patient:
                        HandlePatientMenu();
                        break;

                    case MainMenuOption.Doctor:
                        //HandleDoctorMenu();
                        break;

                    case MainMenuOption.Administrator:
                        //HandleAdministratorMenu();
                        break;
                }
            }
        }

        private void HandlePatientMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("| Functional Page of Patient |");
                Console.WriteLine("------------------------------\n");

                Console.WriteLine("Are you registered patient? \n1 - yes, 2 - no.");

                byte operation = GetOperation("\nEnter number: ", 2);

                if (operation == 2)
                {
                    RegistrationPatient();
                    continue;
                }

                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("| Functional Page of Patient |");
                Console.WriteLine("------------------------------\n");
                Console.Write("Enter your phone number: ");
                string? phone = Console.ReadLine();

                if (!CheckPatient(phone) || string.IsNullOrEmpty(phone))
                {
                    Console.WriteLine("Patient with this phone number is not found. Please register.\n");
                    RegistrationPatient();
                    continue;
                }

                Console.WriteLine("You are logged in successfully!\n\n");

                while (isRunning)
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("| Functional Page of Patient |");
                    Console.WriteLine("------------------------------\n");
                    Console.WriteLine("1. Show my info.");
                    Console.WriteLine("2. Update my info.");
                    Console.WriteLine("3. Show doctors list.");
                    Console.WriteLine("4. Create appointment.");
                    Console.WriteLine("5. Show my appointments.");
                    Console.WriteLine("0. Exit");

                    PatientMenuOption patientOption = (PatientMenuOption)GetOperation("\nEnter number: ", 5);

                    switch (patientOption)
                    {
                        case PatientMenuOption.Exit:
                            isRunning = false;
                            break;
                        case PatientMenuOption.ShowMyInfo:
                            ShowPatientInfo(phone);
                            break;
                        case PatientMenuOption.UpdateMyInfo:
                            UpdatePatientInfo();
                            break;
                        case PatientMenuOption.ShowDoctorsList:
                            //ShowDoctorsList();
                            break;
                        case PatientMenuOption.CreateAppointment:
                            //CreateAppointment();
                            break;
                        case PatientMenuOption.ShowMyAppointments:
                            //ShowMyAppointments();
                            break;
                    }
                }
            }
        }

        private void UpdatePatientInfo()
        {
            throw new NotImplementedException();
        }

        private void ShowPatientInfo(string phone)
        {
            var patient = _patientService.Get(phone);

            Console.WriteLine();
            if (patient != null)
            {
                _patientService.ShowInfo(patient);
            }
            else
            {
                Console.WriteLine("Patient with this phone number is not found.");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private bool CheckPatient(string? phone)
        {
            var patients = _patientService.GetAll();
            foreach (var patient in patients)
            {
                if (patient.Phone == phone)
                {
                    return true;
                }
            }
            return false;
        }

        private static byte GetOperation(string prompt, byte maxOperations)
        {
            byte operation;
            Console.Write(prompt);
            while (!byte.TryParse(Console.ReadLine(), out operation) || operation < 0 || operation > maxOperations)
            {
                Console.WriteLine("Invalid operation. Please enter a number between 0 and 8:");
            }
            return operation;
        }

        private void RegistrationPatient()
        {
            var newPatient = new Patient();

            Console.WriteLine("You need to register.\nEnter info:");
            Console.Write("Name: ");
            newPatient.Name = Console.ReadLine();
            Console.Write("Surname: ");
            newPatient.Surname = Console.ReadLine();
            Console.Write("Phone: ");
            newPatient.Phone = Console.ReadLine();
            Console.Write("Email (optional): ");
            newPatient.Email = Console.ReadLine();
            Console.WriteLine("List of illness:");
            foreach (IllnessTypes illness in Enum.GetValues(typeof(IllnessTypes)))
            {
                Console.WriteLine($"{(int)illness} - {illness}");
            }
            newPatient.IllnessType = (IllnessTypes)GetOperation("Illness type: ", 5);

            Console.Write("Adress (optional): ");
            newPatient.Address = Console.ReadLine();
            Console.Write("Additional info (optional): ");
            newPatient.AdditionalInfo = Console.ReadLine();

            _patientService.Create(newPatient);
            Console.WriteLine("You are registered successfully!\n\n");
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public static class Program
    {
        public static void Main()
        {
            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    }
}