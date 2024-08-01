using Exam_C_.question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exam_C_.exam
{
    public abstract class Exam
    {
        protected DateTime Time { get; set; }
        protected int NumOfQuestions { get; set; }
        protected List<Question> Questions { get; set; }

        public abstract void ShowExam();
        protected abstract int GetNumOfQuestions();
        protected abstract void AddQuestions();
        protected abstract DateTime GetTime();
        public abstract void TakeExam();
        public abstract void EditExam();
    }
}
