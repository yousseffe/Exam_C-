using Exam_C_.answer;
using System;

namespace Exam_C_.question
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion()
        {
            Answers = new Answer[2];
            Console.WriteLine("True/False Question");
            Body = GetBody();
            Mark = GetMark();
            AddChoices();
            RightAnswer = GetRightAnswer();
        }

        protected override string GetBody()
        {
            string input;
            do
            {
                Console.WriteLine("Please enter the question body (cannot be empty):");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("The question body cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        protected override int GetMark()
        {
            bool isValidInput = false;
            int mark = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter the question mark:");
                isValidInput = int.TryParse(Console.ReadLine(), out mark);
                if ((mark <= 0) && isValidInput)
                {
                    isValidInput = false;
                }
                if (!isValidInput)
                {
                    Console.WriteLine("Please enter a valid mark (greater than 0).");
                }
            }
            return mark;
        }

        protected override void AddChoices()
        {
            Answers[0] = new Answer(1, "True");
            Answers[1] = new Answer(2, "False");
        }

        protected override int GetRightAnswer()
        {
            bool isValidInput = false;
            int ans = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter the Right Answer ID (1 for True and 2 for False):");
                isValidInput = int.TryParse(Console.ReadLine(), out ans);
                if ((ans < 1 || ans > 2) && isValidInput)
                {
                    isValidInput = false;
                }
                if (!isValidInput)
                {
                    Console.WriteLine("Please enter a valid ID (1 or 2).");
                }
            }
            return ans - 1; // Adjusting for 0-based index
        }

        public override Answer DisplayAnswer()
        {
            return Answers[RightAnswer];
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine(Body);
            foreach (var answer in Answers)
            {
                Console.WriteLine($"{answer.Id}: {answer.Text}");
            }
        }

        public override void EditQuestion()
        {
            bool isEditing = true;
            while (isEditing)
            {
                Console.Clear();
                Console.WriteLine("Editing Question:");
                Console.WriteLine($"1. Edit Body");
                Console.WriteLine($"2. Edit Marks");
                Console.WriteLine($"3. Edit Right Answer");
                Console.WriteLine($"4. Exit");

                bool isValidInput = int.TryParse(Console.ReadLine(), out int editOption);

                switch (editOption)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the new question text:");
                        string newText = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newText))
                        {
                            Body = newText;
                            Console.WriteLine("Question body updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Question body cannot be empty.");
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter the new mark for the question:");
                        isValidInput = int.TryParse(Console.ReadLine(), out int newMark);
                        if (isValidInput && newMark > 0)
                        {
                            Mark = newMark;
                            Console.WriteLine("Marks updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid mark. Please enter a positive number.");
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Current Right Answer is {Answers[RightAnswer]}");
                        Console.WriteLine("Enter 1 for True or 2 for False:");
                        isValidInput = int.TryParse(Console.ReadLine(), out int newRightAnswer);
                        if (isValidInput && (newRightAnswer == 1 || newRightAnswer == 2))
                        {
                            RightAnswer = newRightAnswer - 1; 
                            Console.WriteLine("Right answer updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                        }
                        break;

                    case 4:
                        isEditing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }

    }
}
