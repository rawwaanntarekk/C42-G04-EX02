using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TFQuestion : Question
    {
        #region Constructors
        // Constructor takes the body of the question, the mark of the question, and the correct answer
        // the header and the answers are fixed for this type of question
        private TFQuestion(string _body, int _mark, Answer _correctAnswer)
            : base("True | False Question", _body, _mark, _correctAnswer, [new Answer(1, "True"), new Answer(2, "False")]) { }

        // ----------------------------------------------------------------------------------------------------------------------------------------

        public TFQuestion()
        {

            Header = "True | False Question";
            Answers = [new Answer(1, "True"), new Answer(2, "False")];

        }
        #endregion


        // ----------------------------------------------------------------------------------------------------------------------------------------


        #region Methods
        private protected override int ValidateCorrectAnswerIndex()
        {
            int index;
            do
            {

                Console.Write("Please Enter A Number Of The Correct Answer [1 For True , 2 For False]: ");

            } while (!int.TryParse(Console.ReadLine() ?? "0", out index) || index < 1 || index > 2);

            return index;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------

        public override Question CreateQuestion()
        {
            Console.WriteLine(Header);
            string body = ValidateBody();
            int mark = ValidateMark();
            Answer correctAnswer = Answers[ValidateCorrectAnswerIndex() - 1];
            return new TFQuestion(body, mark, correctAnswer);

        } 
        #endregion

        // ----------------------------------------------------------------------------------------------------------------------------------------


    }
}

