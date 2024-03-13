/*
 * Author: Anthony Alvarez
 * Course: COMP-003A
 * Purpose: COMP-003A final project
 */
// TODO: Missing exception handling.
namespace COMP003AFinalProject
{
    class Program
    {
        // TODO: a note, these are not functions, they are called methods in C#
        // Main function
        static void Main()
        {
            // TODO: by convention methods should be below the Main method
            // TODO: what is the purpose of "T" in this method?
            // TODO: what is the purpose of "Func" here?
            // TODO: what is the purpose of this method?
            // TODO: add xml comments here
            // The generic type parameter "T" allows flexibility for working with different data types.
            // The "Func<string, (bool isValid, T value)>" is a delegate representing a validation function.
            // It takes a string input and returns a tuple with a boolean indicating validity and a value of type T.
            // This method gets user input from the console, validating it based on the provided validation function.
            // It keeps prompting the user until a valid input is provided.

            /// <summary>
            /// Gets and validates user input from the console.
            static T GetUserInput<T>(string prompt, Func<string, (bool isValid, T value)> validationFunc)
            {
                // An infinite loop continues prompting the user until a valid input is provided.
                while (true)
                {
                    Console.Write(prompt);
                    string userInput = Console.ReadLine();

                    // "var" allows the compiler to automatically infer the type based on the return type of the validationFunc.
                    var validationResult = validationFunc(userInput);

                    // If the input is valid, return the validated value and exit the loop.
                    if (validationResult.isValid)
                    {
                        return validationResult.value;
                    }

                    Console.WriteLine("Invalid input. Please try again.");
                }
            }


            // TODO: by convention methods should be below the Main method
            // TODO: what is the purpose of (bool isValid, int value) here?
            // The return type (bool isValid, int value) is a tuple. It is used to convey both the validity of the input and the parsed integer value.
            // The boolean "isValid" indicates whether the input could be successfully converted to an integer, and "value" contains the parsed integer.

            // TODO: what is the purpose of this method?
            // This method is designed to validate a string input as a birth year. It checks if the input can be parsed into an integer and falls within a valid range (1900 to the current year).

            // TODO: add XML comments here
            /// <summary>
            /// Validates the input as a birth year.
            static (bool isValid, int value) ValidateBirthYear(string input)
            {
                // TODO: what does int.TryParse do?
                // The int.TryParse method attempts to parse the provided string as an integer. It returns a boolean indicating whether the parsing was successful and an output parameter (out int year) containing the parsed integer value.

                // TODO: what does out int year do?
                // The "out int year" parameter is used to store the parsed integer value obtained from the int.TryParse method.
                if (int.TryParse(input, out int year))
                {
                    int currentYear = DateTime.Now.Year;
                    // TODO: what is the purpose of the line below?
                    // This line checks if the parsed year falls within a valid range (1900 to the current year) and returns a tuple with the validity and the parsed year.
                    return (1900 <= year && year <= currentYear, year);
                }

                // TODO: what does the line below do?
                // The line below is reached when the input cannot be parsed as an integer. It returns a tuple indicating that the input is invalid, with a value of 0 (since the parsing failed).

                // TODO: why is it returning more than one value? What is this concept called?
                // The method is returning a tuple, which is a data structure that can hold multiple values of different types. In this case, it returns both a boolean indicating validity and an integer value.
                return (false, 0);
            }

            // TODO: what is the purpose of (bool isValid, string value) here?
            // The return type (bool isValid, string value) is a tuple. It is used to convey both the validity of the input and the normalized string value.
            // The boolean "isValid" indicates whether the input is a valid gender value ("M", "F", or "O"), and "value" contains the normalized input string.

            // TODO: what is the purpose of this method?
            // This method is designed to validate a string input as a gender value. It checks if the input is either "M", "F", or "O" (case-insensitive) and returns a tuple indicating the validity and the normalized input.

            // TODO: add XML comments here
            /// <summary>
            /// Validates the input as a gender value.
            static (bool isValid, string value) ValidateGender(string input)
            {
                // TODO: what does this line do?
                // The line converts the input string to uppercase using the ToUpper() method, ensuring case-insensitivity in the comparison.
                string normalizedInput = input.ToUpper();
                // TODO: what does the line below do?
                // This line checks if the normalized input is equal to "M", "F", or "O", and returns a tuple indicating the validity and the normalized input.
                return (normalizedInput == "M" || normalizedInput == "F" || normalizedInput == "O", normalizedInput);
            }

            // TODO: by convention methods should be below the Main method
            // TODO: what is the purpose of this method?
            // This method is designed to display a summary of a user's profile information. It takes various personal details such as first name, last name, birth year, gender, and a list of responses to questions.

            // TODO: what does List<(string question, string response)> mean?
            // The type List<(string question, string response)> represents a list of tuples where each tuple consists of two strings: a question and a response. It's a collection that allows storing pairs of question and corresponding responses.

            // TODO: what is this concept called List<(string question, string response)>?
            // The concept is called a List of Tuples. In this case, it's a List of tuples where each tuple contains a string for the question and a string for the response. This is leveraging the tuple syntax introduced in C# 7.

            // TODO: add XML comments here
            /// <summary>
            /// Displays a summary of the user's profile information.
            static void DisplayProfileSummary(string firstName, string lastName, int birthYear, string gender, List<(string question, string response)> responses)
            {
                // Calculate age
                int currentYear = DateTime.Now.Year;
                int age = currentYear - birthYear;

                // Display profile information
                Console.WriteLine($"Full Name: {lastName}, {firstName}");
                Console.WriteLine($"Age: {age}");

                // TODO: what is the purpose of this data structure?
                // TODO: how is the Dictionary dictionary called?
                // The Dictionary<string, string> is called a "Dictionary" and is used to store a collection of key-value pairs. In this specific case, it's used to map gender abbreviations to their full descriptions.

                // TODO: what does the two data types mean in the Dictionary?
                // In the Dictionary<string, string>, the first string represents the data type of the keys (gender abbreviations like "M", "F", "O"), and the second string represents the data type of the values (full descriptions like "Male", "Female", "Other").

                // Map gender to full description
                Dictionary<string, string> genderMap = new Dictionary<string, string>
        {
            { "M", "Male" },
            { "F", "Female" },
            { "O", "Other" }
        };

                // TODO: what is genderMap.ContainsKey()?
                // The genderMap.ContainsKey(gender) method checks whether the Dictionary (genderMap) contains a specific key (gender). It returns true if the key is found, and false otherwise.

                // TODO: what is ? : called?
                // The "? :" is called the conditional (ternary) operator. In the line "string genderDescription = genderMap.ContainsKey(gender) ? genderMap[gender] : "Unknown";", it is used to assign the value of genderMap[gender] to genderDescription if genderMap contains the key 'gender'. If the key is not found, it assigns the string "Unknown" to genderDescription.
                string genderDescription = genderMap.ContainsKey(gender) ? genderMap[gender] : "Unknown";
                Console.WriteLine($"Gender: {genderDescription}");

                // Display user responses
                for (int i = 0; i < responses.Count; i++)
                {
                    Console.WriteLine($"Question {i + 1}: {responses[i].question}");
                    Console.WriteLine($"Response {i + 1}: {responses[i].response}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Welcome to the Dating App Console Application!");

            // TODO: what does => mean?
            // it's used when defining rules or conditions for something.It's a way of saying, "If something, then become something else."

            // TODO: what is this expression => called?
            // Equal greater than

            // TODO: what is this operator && called?
            // The "&&" is the logical AND operator, returning true if both conditions are true.

            // TODO: what is this operator ! called?
            // The "!" is the logical NOT operator, negating the boolean value.

            // TODO: what is this operator .Any() called?
            // ".Any()" is a LINQ method checking if any element in a collection satisfies a given condition.

            // TODO: how does char.IsDigit work?
            // "char.IsDigit" returns true if a character is a decimal digit ('0' to '9').

            // TODO: how does char.IsPunctuation work?
            // "char.IsPunctuation" returns true if a character is a punctuation mark.

            string firstName = GetUserInput("Enter your First Name: ", input => (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit) && !input.Any(char.IsPunctuation), input));
            string lastName = GetUserInput("Enter your Last Name: ", input => (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit) && !input.Any(char.IsPunctuation), input));
            int birthYear = GetUserInput("Enter your Birth Year: ", ValidateBirthYear);
            string gender = GetUserInput("Enter your Gender (M/F/O): ", ValidateGender);

            // Create a questionnaire with 10 questions
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
            "Last question is about us, how did you find this app?",
            // Add more questions as needed
        };

            // TODO: what is the purpose of List<(string question, string response)>?
            // It's a list that keeps track of pairs of questions and responses using tuples.

            // TODO: what is this concept called List<(string question, string response)>?
            // This is a List of Tuples, where each Tuple has two strings: one for a question and one for a response.

            // TODO: how does this concept work List<(string question, string response)>?
            // It works by allowing you to store and manage pairs of questions and responses in a dynamic list.
            // Example usage to get user responses:
            List<(string question, string response)> responses = new List<(string question, string response)>();

            // TODO: What does this code do?
            // It goes through each 'question' in the 'questions' collection.
            foreach (string question in questions)
            {
                Console.Write(question + " ");
                // TODO: add a method that validates this user input so it does not allow null/empty/whitespace entries before adding it to the list
                string response = Console.ReadLine();
                responses.Add((question, response));
            }
            // TODO: what does this line do?
            // Display profile summary
            DisplayProfileSummary(firstName, lastName, birthYear, gender, responses);

        }
    }
}