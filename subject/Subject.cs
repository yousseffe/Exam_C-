using Exam_C_.exam;
using System;

namespace Exam_C_.subject
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FinalExam FinalExam { get; set; }
        public PracticalExam PracticalExam { get; set; }

        public Subject(int id)
        {
            Id = id;
            SetName();
        }

        private void SetName()
        {
            Console.WriteLine("Please Enter subject Name");
            string name;
            do
            {
                Console.WriteLine("Please enter the Subject name (cannot be empty):");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("The Subject name cannot be empty. Please try again.");
                }
            }
            while (string.IsNullOrWhiteSpace(name));
            Name = name;
        }

        public void ShowSubjectManagementOptions()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Managing Subject: {Name}");

                if (FinalExam == null && PracticalExam == null)
                {
                    Console.WriteLine("1. Add Final Exam");
                    Console.WriteLine("2. Add Practical Exam");
                }
                else
                {
                    if (FinalExam != null)
                    {
                        Console.WriteLine("1. Edit Final Exam");
                        Console.WriteLine("2. Take Final Exam");
                    }
                    else
                    {
                        Console.WriteLine("1. Add Final Exam");
                    }

                    if (PracticalExam != null && FinalExam == null)
                    {
                        Console.WriteLine("2. Edit Practical Exam");
                        Console.WriteLine("3. Take Practical Exam");
                    }
                    else if(PracticalExam != null)
                    {
                        Console.WriteLine("3. Edit Practical Exam");
                        Console.WriteLine("4. Take Practical Exam");
                    }
                    else
                    {
                        Console.WriteLine("3. Add Practical Exam");
                    }
                }

                Console.WriteLine("0. Back to Subject List");
                Console.Write("Enter your choice: ");

                bool isValidInput = int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        if (FinalExam == null)
                        {
                            FinalExam = new FinalExam();
                            Console.WriteLine("Final Exam added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Editing Final Exam.");
                            FinalExam.EditExam();
                        }
                        break;

                    case 2:
                        if (FinalExam != null)
                        {
                            FinalExam.TakeExam();
                        }
                        else
                        {
                            PracticalExam = new PracticalExam();
                        }
                        break;

                    case 3:
                        if (PracticalExam == null)
                        {
                            PracticalExam = new PracticalExam();
                            Console.WriteLine("Practical Exam added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Editing Practical Exam.");
                            PracticalExam.EditExam();
                        }
                        break;

                    case 4:
                        if (PracticalExam != null)
                        {
                            PracticalExam.TakeExam();
                        }
                        else
                        {
                            Console.WriteLine("Practical Exam does not exist. Please add one first.");
                        }
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

    }
}
