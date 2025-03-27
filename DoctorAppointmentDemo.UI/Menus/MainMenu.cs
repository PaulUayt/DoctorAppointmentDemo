using DoctorAppointment.UI.Menus.Enums;

namespace DoctorAppointmentDemo.UI.Menus
{
    class MainMenu
    {
        private readonly PatientMenu _patientMenu;
        private readonly DoctorMenu _doctorMenu;
        private readonly AdminMenu _adminMenu;

        public MainMenu(PatientMenu patientMenu, DoctorMenu doctorMenu, AdminMenu adminMenu)
        {
            _patientMenu = patientMenu;
            _doctorMenu = doctorMenu;
            _adminMenu = adminMenu;
        }

        public void Show()
        {       
            while (true)
            {
                AddFuncs.DisplayMenuHeader("Doctor Appointment System");

                Console.WriteLine("1. Functional Page for Patient.");
                Console.WriteLine("2. Functional Page for Doctor.");
                Console.WriteLine("3. Functional Page for Administrator.");
                Console.WriteLine("0. Exit.\n");

                var operation = (MainMenuOption)AddFuncs.GetOperation("\nEnter number: ", 0, 3);

                switch (operation)
                {
                    case MainMenuOption.Exit:
                        return;

                    case MainMenuOption.Patient:
                        _patientMenu.Show();
                        break;

                    case MainMenuOption.Doctor:
                        //_doctorMenu.Show();
                        break;

                    case MainMenuOption.Administrator:
                        //_adminMenu.Show();
                        break;
                }
            }
        }
    }
}
