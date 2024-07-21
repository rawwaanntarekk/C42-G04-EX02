using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {

        #region Constructors
        public FinalExam()
        {

        }


        public FinalExam(int _time, int _questionNumber, List<Question> _questions)
               : base(_time, _questionNumber, _questions) { }
        #endregion

        // --------------------------------------------------------------------------------------------------------------------

        #region Methods
        private static int ShowOptions()
        {
            Console.WriteLine("What Type Of Question You Need?");
            Console.WriteLine("1- Multiple Choice Question\n2- True Or False Question\n");
            int type;
            do
            {
                Console.Write("Please Enter The Number Of The Question Type: ");
            } while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 2);

            Console.Clear();

            return type;
        }

        // --------------------------------------------------------------------------------------------------------------------

        public override Exam CreateExam()

        {
            int time = ValidateTime();
            int questionNumber = ValidateQuestionNumber();
            Console.Clear();
            List<Question> questions = new(QuestionNumber);
            for (int i = 0; i < questionNumber; i++)
            {
                Console.WriteLine($"Question Number {i + 1}:");

                Console.WriteLine("-----------------------------------");

                int type = ShowOptions();
                if (type == 1)
                {
                    questions.Add(new MultipleChoiceQuestion().CreateQuestion());

                }
                else
                {
                    questions.Add(new TFQuestion().CreateQuestion());
                }
                Console.Clear();




            }
            return new FinalExam(time, questionNumber, questions);

        }

        // ---------------------------------------------------------------------------------------------------------------------


        // Print Each Question with the chosen answer for the student
        private void PrintQuestionAndAnswers()
        {
            Console.WriteLine("Your Answers:");
            if (StudentAnswers is not null)
                for (int i = 0; i < Questions.Count; i++)
                {
                    Console.WriteLine($"Q{i + 1})\t {Questions[i].Body}: {(StudentAnswers[i].Text) ?? ""}");
                    Console.WriteLine($"The correct answer is: {Questions[i].CorrectAnswer.Text} ");
                    Console.WriteLine("-----------------------");

                }
        }

        // --------------------------------------------------------------------------------------------------------------------


        public override void ShowResults()
        {
            // Show the student mark after finishing + Calling PrintQuestionAndAnswers()
            int ExamMark = 0, GainedMark = 0;
            if (StudentAnswers is not null)
            for (int i = 0; i < Questions.Count; i++)
            {
                ExamMark += Questions[i].Mark;
                if (Questions[i].CorrectAnswer.Equals(StudentAnswers[i]))
                {
                    GainedMark += Questions[i].Mark;
                }
            }

            PrintQuestionAndAnswers();
            Console.WriteLine($"\nYou Got {GainedMark} out of {ExamMark}");
        }

        // --------------------------------------------------------------------------------------------------------------------


        
        

        #endregion
    }
}
