using Exam_C_.answer;
using System;

namespace Exam_C_.question
{
    public class MCQQuestion : Question
    {
        public MCQQuestion()
        {
            Answers = new Answer[4];
            Console.WriteLine("MCQ Question");
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
                if (mark <= 0)
                {
                    isValidInput = false;
                    Console.WriteLine("Please enter a valid mark (greater than 0).");
                }
            }
            return mark;
        }

        protected override void AddChoices()
        {
            for (int i = 0; i < Answers.Length; i++)
            {
                string choice;
                do
                {
                    Console.WriteLine($"Please enter choice number {i + 1}:");
                    choice = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(choice))
                    {
                        Console.WriteLine("The choice cannot be empty. Please try again.");
                    }
                } while (string.IsNullOrWhiteSpace(choice));

                Answers[i] = new Answer(i, choice);
            }
        }

        protected override int GetRightAnswer()
        {
            bool isValidInput = false;
            int ans = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter the Right Answer ID (1 to 4):");
                isValidInput = int.TryParse(Console.ReadLine(), out ans);
                if (ans < 1 || ans > 4)
                {
                    isValidInput = false;
                    Console.WriteLine("Please enter a valid ID (1 to 4).");
                }
            }
            return ans - 1;
        }

        public override Answer DisplayAnswer()
        {
            return Answers[RightAnswer];
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine(Body);
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine($"{Answers[i].Id + 1}: {Answers[i].Text}"); // ID displayed as 1-based
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
                Console.WriteLine($"3. Edit Choices");
                Console.WriteLine($"4. Edit Right Answer");
                Console.WriteLine($"5. Exit");

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
                        bool isEditingChoices = true;
                        while (isEditingChoices)
                        {
                            Console.Clear();
                            Console.WriteLine("Current Choices:");
                            for (int i = 0; i < Answers.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}. {Answers[i].Text}");
                            }
                            Console.WriteLine("Enter the number of the choice to edit (1 to 4), or 0 to exit:");

                            isValidInput = int.TryParse(Console.ReadLine(), out int choiceToEdit);
                            if (isValidInput && choiceToEdit >= 0 && choiceToEdit <= Answers.Length)
                            {
                                if (choiceToEdit == 0)
                                {
                                    isEditingChoices = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Editing Choice {choiceToEdit}:");
                                    Console.WriteLine("Enter the new text for this choice:");
                                    string newChoiceText = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(newChoiceText))
                                    {
                                        Answers[choiceToEdit - 1].Text = newChoiceText;
                                        Console.WriteLine("Choice updated successfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Choice text cannot be empty.");
                                    }
                                    Console.WriteLine("New Choices:");
                                    for (int i = 0; i < Answers.Length; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {Answers[i].Text}");
                                    }
                                    RightAnswer = GetRightAnswer();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice number. Please enter a number between 0 and 4.");
                            }
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Current Choices:");
                        for (int i = 0; i < Answers.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {Answers[i].Text}");
                        }
                        Console.WriteLine($"Current Right Answer is {Answers[RightAnswer]}");
                        Console.WriteLine("Enter the index of the new right answer (1 to 4):");
                        isValidInput = int.TryParse(Console.ReadLine(), out int newRightAnswer);
                        if (isValidInput && newRightAnswer >= 1 && newRightAnswer <= Answers.Length)
                        {
                            RightAnswer = newRightAnswer - 1;
                            Console.WriteLine("Right answer updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid index. Please enter a valid index (1 to 4).");
                        }
                        break;

                    case 5:
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
