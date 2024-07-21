using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        #region Constructors
        public PracticalExam() { }

        private PracticalExam(int _time, int _questionNumber, List<Question> _questions)
               : base(_time, _questionNumber, _questions) { }
        #endregion


        // --------------------------------------------------------------------------------------------------------------------


        #region Methods
        public override Exam CreateExam()
        {
            int time = ValidateTime();
            int questionNumber = ValidateQuestionNumber();
            Console.Clear();

            List<Question> questions = new List<Question>(QuestionNumber);

            for (int i = 0; i < questionNumber; i++)
            {
                Console.WriteLine($"Question Number {i + 1}:");
                Console.WriteLine("--------------------------------");
                questions.Add(new MultipleChoiceQuestion().CreateQuestion());

                Console.Clear();
            }
            return new PracticalExam(time, questionNumber, questions);

        }

        // --------------------------------------------------------------------------------------------------------------------

       

        #endregion
        // --------------------------------------------------------------------------------------------------------------------

    }
}
