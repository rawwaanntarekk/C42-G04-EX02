using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam
    {
        #region Properties

        public int Time { get; set; }
        public int QuestionNumber { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer>? StudentAnswers { get; set; }

        #endregion

        // --------------------------------------------------------------------------------------------------------------------

        #region Constructors
        public Exam(int _time, int _questionNumber, List<Question> _questions)
        {
            Time = _time;
            QuestionNumber = _questionNumber;
            Questions = _questions;
            StudentAnswers = new List<Answer>();
        }

        // --------------------------------------------------------------------------------------------------------------------

        protected Exam()
        {

        }

        // --------------------------------------------------------------------------------------------------------------------


        #endregion


        #region Methods


        private protected static int ValidateTime()
        {
            int time;

            do
            {
                Console.Write("Please Enter The Time Of The Exam: ");
            } while (!int.TryParse(Console.ReadLine(), out time) || time <= 0);

            return time;
        }

        // --------------------------------------------------------------------------------------------------------------------

        private protected static int ValidateQuestionNumber()
        {
            int questionNumber;
            do
            {

                Console.Write("Please Enter The Number Of Questions: ");
            } while (!int.TryParse(Console.ReadLine(), out questionNumber) || questionNumber <= 0);


            return questionNumber;
        }

        // --------------------------------------------------------------------------------------------------------------------

        private protected static int ShowAndChooseOption()
        {
            Console.WriteLine("What Type Of Exam You Need?");
            Console.WriteLine("1- Practical Exam\n 2- Final Exam");
            int type;
            do
            {
                Console.Write("Please Enter The Number Of The Exam Type: ");
            } while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 2);

            return type;
        }

        // --------------------------------------------------------------------------------------------------------------------

        public abstract Exam CreateExam();


        // --------------------------------------------------------------------------------------------------------------------

        public abstract void ShowResults();

        // --------------------------------------------------------------------------------------------------------------------

        public void ShowExam()
        {

            Console.WriteLine($"Time: {Time} minutes");
            Console.WriteLine($"Number Of Questions: {QuestionNumber}");
            for (int i = 0; i < QuestionNumber; i++)
            {
                Console.WriteLine($"Question Number {i + 1}");
                Console.WriteLine("-------------------------------");
                Console.WriteLine(Questions[i].ToString());
                Console.WriteLine("-------------------------------");
                StudentAnswers?.Add(Questions[i].RecieveAnswer());
                Console.Clear();

            }

            ShowResults();
        }




        // --------------------------------------------------------------------------------------------------------------------

        #endregion
    }
}
