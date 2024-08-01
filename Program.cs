using System;
using System.Collections.Generic;
using Exam_C_.subject;

namespace Exam_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> subjects = new List<Subject>();
            bool exit = false;

            Console.WriteLine("Welcome to the Exam Management System");
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Add Subject");
                Console.WriteLine("2. Manage Subjects");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                bool isValidInput = int.TryParse(Console.ReadLine(), out int mainChoice);

                switch (mainChoice)
                {
                    case 1:
                        // Add a new subject
                        Console.Clear();
                        Console.WriteLine("Adding a New Subject");
                        Subject newSubject = new Subject(subjects.Count + 1);
                        subjects.Add(newSubject);
                        Console.WriteLine("Subject added successfully. Press any key to continue.");
                        Console.ReadKey();
                        break;

                    case 2:
                        // Manage subjects
                        ManageSubjects(subjects);
                        break;

                    case 3:
                        // Exit program
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Exiting program. Press any key to continue.");
            Console.ReadKey();
        }

        static void ManageSubjects(List<Subject> subjects)
        {
            bool manageSubjects = true;

            while (manageSubjects)
            {
                Console.Clear();
                Console.WriteLine("Subjects:");
                for (int i = 0; i < subjects.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {subjects[i].Name}");
                }
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select a subject to manage or 0 to go back: ");
                bool isValidInput = int.TryParse(Console.ReadLine(), out int subjectChoice);

                if (subjectChoice == 0)
                {
                    manageSubjects = false;
                    continue;
                }

                if (subjectChoice < 1 || subjectChoice > subjects.Count)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                Subject selectedSubject = subjects[subjectChoice - 1];
                selectedSubject.ShowSubjectManagementOptions();
            }
        }
    }
}
