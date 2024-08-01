using Exam_C_.question;
using System;
using System.Collections.Generic;

namespace Exam_C_.exam
{
    public class FinalExam : Exam
    {
        public FinalExam()
        {
            Questions = new List<Question>(4);
            Console.WriteLine("Final Exam");
            Time = GetTime();
            NumOfQuestions = GetNumOfQuestions();
            AddQuestions();
        }

        protected override DateTime GetTime()
        {
            bool isValidInput = false;
            int timeForExam = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter the time for exam (15 to 180 minutes):");
                isValidInput = int.TryParse(Console.ReadLine(), out timeForExam);
                if ((timeForExam < 15 || timeForExam > 180) && isValidInput)
                {
                    isValidInput = false;
                }
                if (!isValidInput)
                {
                    Console.WriteLine("Please enter a valid time (15 to 180 minutes).");
                }
            }
            return DateTime.MinValue.AddMinutes(timeForExam);
        }

        protected override int GetNumOfQuestions()
        {
            bool isValidInput = false;
            int numOfQuestions = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter the number of questions:");
                isValidInput = int.TryParse(Console.ReadLine(), out numOfQuestions);
                if (numOfQuestions <= 0 && isValidInput)
                {
                    isValidInput = false;
                }
                if (!isValidInput)
                {
                    Console.WriteLine("Please enter a valid number (greater than 0).");
                }
            }
            return numOfQuestions;
        }

        protected override void AddQuestions()
        {
            for (int i = 0; i < NumOfQuestions; i++)
            {
                AddQuestion();
            }
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
                Console.WriteLine();
            }
        }

        public override void TakeExam()
        {
            Console.Clear();
            Console.WriteLine("Taking Final Exam:");

            int totalMarks = 0;
            int obtainedMarks = 0;
            var userResponses = new List<(Question Question,int userAnswer , bool isCorrect, TimeSpan TimeTaken)>();
            TimeSpan totalTimeTaken = TimeSpan.Zero;

            foreach (Question question in Questions)
            {
                Console.Clear();
                question.DisplayQuestion();
                DateTime startTime = DateTime.Now;

                int userAnswer = -1;
                bool isValidInput = false;

                while (!isValidInput)
                {
                    Console.Write("Enter your answer (index): ");
                    isValidInput = int.TryParse(Console.ReadLine(), out userAnswer);
                    if (isValidInput && userAnswer > 0 && userAnswer < question.Answers.Length+1)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index. Please enter a number between 1 and " + (question.Answers.Length ) + ".");
                    }
                }

                DateTime endTime = DateTime.Now;
                TimeSpan timeTaken = endTime - startTime;
                totalTimeTaken += timeTaken; 

                bool isCorrect = userAnswer == question.RightAnswer+1;
                if (isCorrect)
                {
                    obtainedMarks += question.Mark;
                }
                totalMarks += question.Mark;

                userResponses.Add((question, userAnswer , isCorrect, timeTaken));
            }

            Console.Clear();
            Console.WriteLine("Exam Finished!");
            Console.WriteLine($"Total Time Taken: {totalTimeTaken} ");
            Console.WriteLine($"Total Marks: {totalMarks}");
            TimeSpan time =  Time - DateTime.MinValue;
            if (totalTimeTaken > time)
            {
                Console.WriteLine($"Obtained Marks: {0}");
            }
            else 
            {
                Console.WriteLine($"Obtained Marks: {obtainedMarks}");
            }
            Console.WriteLine($"Obtained Marks: {obtainedMarks}");
            Console.WriteLine("Exam Results:");


            foreach (var response in userResponses)
            {
                response.Question.DisplayQuestion();
                Console.WriteLine($"Your Answer: {response.Question.Answers[response.userAnswer].Text}");
                Console.WriteLine($"Right Answer: {response.Question.Answers[response.Question.RightAnswer].Text}");
                Console.WriteLine($"Marks Awarded: {(response.isCorrect ? response.Question.Mark : 0)}");
                Console.WriteLine($"Time Taken: {response.TimeTaken}");
                Console.WriteLine();
            }
        }

        public override void EditExam()
        {
            Console.Clear();
            Console.WriteLine("Editing Final Exam:");

            Console.WriteLine("1. Add Question");
            Console.WriteLine("2. Edit Question");
            Console.WriteLine("3. Delete Question");
            Console.WriteLine("4. Return to Main Menu");

            bool isValidInput = false;
            int actionChoice = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Choose an action:");
                isValidInput = int.TryParse(Console.ReadLine(), out actionChoice);
                if (isValidInput && actionChoice >= 1 && actionChoice <= 4)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }

            switch (actionChoice)
            {
                case 1:
                    AddQuestion();
                    break;
                case 2:
                    EditQuestion();
                    break;
                case 3:
                    if (Questions.Count == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("you cna not Delete Question because Exam only have one Question");
                    }
                    else 
                    {
                        DeleteQuestion();
                    }
                    break;
                case 4:
                    // Logic to return to the main menu or exit
                    break;
            }
        }

        private void AddQuestion()
        {
            Console.Clear();
            Console.WriteLine("Adding a new question:");

            bool isValidInput = false;
            int qType = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Enter the type of Question (1 for MCQ and 2 for True/False):");
                isValidInput = int.TryParse(Console.ReadLine(), out qType);
                if ((qType != 1 && qType != 2) && isValidInput)
                {
                    isValidInput = false;
                }
                if (!isValidInput)
                {
                    Console.WriteLine("Please enter 1 or 2.");
                }
            }
            Console.Clear();
            if (qType == 1)
            {
                Questions.Add(new MCQQuestion());
            }
            else
            {
                Questions.Add(new TrueFalseQuestion());
            }
            Console.Clear();
        }

        private void EditQuestion()
        {
            Console.Clear();
            Console.WriteLine("Editing an existing question:");

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Questions[i].Body}");
            }

            bool isValidInput = false;
            int questionNumber = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Enter the number of the question you want to edit:");
                isValidInput = int.TryParse(Console.ReadLine(), out questionNumber);
                if (isValidInput && questionNumber > 0 && questionNumber <= Questions.Count)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid question number. Please enter a valid number.");
                }
            }

            var questionToEdit = Questions[questionNumber - 1];
            questionToEdit.EditQuestion();
        }

        private void DeleteQuestion()
        {
            Console.Clear();
            Console.WriteLine("Deleting an existing question:");

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Questions[i].Body}");
            }

            bool isValidInput = false;
            int questionNumber = 0;
            while (!isValidInput)
            {
                Console.WriteLine("Enter the number of the question you want to delete:");
                isValidInput = int.TryParse(Console.ReadLine(), out questionNumber);
                if (isValidInput && questionNumber > 0 && questionNumber <= Questions.Count)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid question number. Please enter a valid number.");
                }
            }

            Questions.RemoveAt(questionNumber - 1);
            Console.WriteLine("Question deleted successfully.");
        }
    }
}
