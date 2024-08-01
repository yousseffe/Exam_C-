using Exam_C_.answer;
using System;
using System.Collections.Generic;

namespace Exam_C_.question
{
    public abstract class Question
    {
        public string Body { get; set; }
        public int Mark { get; set; }
        public int RightAnswer { get; set; }
        public Answer[] Answers { get; set; }
        public int MyAnswer { get; set; }
        protected abstract string GetBody();
        protected abstract int GetMark();
        protected abstract void AddChoices();
        protected abstract int GetRightAnswer();
        public abstract void DisplayQuestion();
        public abstract Answer DisplayAnswer();
        public abstract void EditQuestion();
    }
}
