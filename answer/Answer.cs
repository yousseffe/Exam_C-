using System;

namespace Exam_C_.answer
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Answer(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return $"{Id}: {Text}";
        }
    }
}
