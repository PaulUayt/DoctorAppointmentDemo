﻿using DoctorAppointment.Domain.Enums;

namespace DoctorAppointmentDemo.UI.Menus
{
    static class AddFuncs
    {
        internal static byte GetOperation(string prompt, byte minOperation, byte maxOperation)
        {
            byte operation;
            Console.Write(prompt);
            while (!byte.TryParse(Console.ReadLine(), out operation) || operation < minOperation || operation > maxOperation)
            {
                Console.WriteLine($"Invalid operation. Please enter a number between {minOperation} and {maxOperation}:");
            }
            return operation;
        }

        internal static string GetRequiredInput(string fieldName)
        {
            string? input;
            do
            {
                Console.Write($"{fieldName}: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine($"{fieldName} cannot be empty. Please enter a valid value.");
                }
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        internal static string GetOptionalInput(string fieldName)
        {
            Console.WriteLine($"{fieldName} (optional): ");
            return Console.ReadLine() ?? string.Empty;
        }

        internal static decimal GetNumeInput(string fieldName)
        {
            decimal num;
            Console.Write($"{fieldName}: ");
            while (!decimal.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine($"Invalid {fieldName}. Please enter a valid number:");
            }
            return num;
        }

        internal static void DisplayMenuHeader(string header)
        {
            Console.Clear();
            Console.WriteLine(new string('-', header.Length + 4));
            Console.WriteLine($"| {header} |");
            Console.WriteLine(new string('-', header.Length + 4));
            Console.WriteLine();
        }

        internal static bool GetConfirmation(string message)
        {
            Console.Write($"{message} (y/n): ");
            while (true)
            {
                string? input = Console.ReadLine()?.ToLower();
                if (input == "y") return true;
                if (input == "n") return false;
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        }

        internal static IllnessTypes GetIllnessType()
        {
            Console.WriteLine("List of illness:");
            foreach (IllnessTypes illness in Enum.GetValues(typeof(IllnessTypes)))
            {
                Console.WriteLine($"{(int)illness} - {illness}");
            }
            return (IllnessTypes)AddFuncs.GetOperation("Illness type: ", 1, 6);
        }
    }
}
