using System;
using System.Collections.Generic;

namespace COMP003AFinalProject
{
    // TODO: Add missing exception handling.
    class Program
    {
        // Function to validate and get user input
        static T GetUserInput<T>(string prompt, Func<string, (bool isValid, T value)> validationFunc)
        {
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                var validationResult = validationFunc(userInput);

                if (validationResult.isValid)
                {
                    return validationResult.value;
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        // Function to validate birth year
        static (bool isValid, int value) ValidateBirthYear(string input)
        {
            if (int.TryParse(input, out int year))
            {
                int currentYear = DateTime.Now.Year;
                return (1900 <= year && year <= currentYear, year);
            }

            return (false, 0);
        }

        // Function to validate gender
        static (bool isValid, string value) ValidateGender(string input)
        {
            string normalizedInput = input.ToUpper();
            return (normalizedInput == "M" || normalizedInput == "F" || normalizedInput == "O", normalizedInput);
        }

        // Function to display profile summary
        static void DisplayProfileSummary(string firstName, string lastName, int birthYear, string gender, List<(string question, string response)> responses)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            Console.WriteLine($"Full Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {age}");

            Dictionary<string, string> genderMap = new Dictionary<string, string>
            {
                { "M", "Male" },
                { "F", "Female" },
                { "O", "Other" }
            };

            string genderDescription = genderMap.TryGetValue(gender, out string genderValue) ? genderValue : "Unknown";
            Console.WriteLine($"Gender: {genderDescription}");

            foreach (var (question, response) in responses)
            {
                Console.WriteLine($"Question: {question}");
                Console.WriteLine($"Response: {response}");
                Console.WriteLine();
            }
        }

        // Main method
        static void Main()
        {
            Console.WriteLine("Welcome to the Dating App Console Application!");

            string firstName = GetUserInput("Enter your First Name: ", input => (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit) && !input.Any(char.IsPunctuation), input));
            string lastName = GetUserInput("Enter your Last Name: ", input => (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit) && !input.Any(char.IsPunctuation), input));
            int birthYear = GetUserInput("Enter your Birth Year: ", ValidateBirthYear);
            string gender = GetUserInput("Enter your Gender (M/F/O): ", ValidateGender);

            List<string> questions = new List<string>
            {
            "What is your favorite color?",
            "Would you say you prefer staying in or going out?",
            "Describe your ideal date night.",
            "What are your hobbies?",
            "Have you dated in the past?",
            "If so how many people have you dated?, (if not just say NA)",
            "What are you looking for (one night stand, long term, see where things go)?",
            "Whats your prefered partners gender?",
            "Would you say you prefer staying in or going out?",
            "Is there anything specific you would like people to know when meeting you?",
                // Add more questions as needed
            };

            List<(string question, string response)> responses = new List<(string question, string response)>();

            foreach (var question in questions)
            {
                Console.Write(question + " ");
                string response = Console.ReadLine();
                responses.Add((question, response));
            }

            DisplayProfileSummary(firstName, lastName, birthYear, gender, responses);
        }
    }
}