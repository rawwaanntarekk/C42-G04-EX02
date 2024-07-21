using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MultipleChoiceQuestion : Question
    {
        #region Constructors

        public MultipleChoiceQuestion()
        {
            Header = "Choose One Answer Correct";
        }

        // Constructor takes the body of the question, the mark of the question, the correct answer and the answers
        // the header is fixed for this type of question.

        private MultipleChoiceQuestion(string _body, int _mark, Answer _correctAnswer, List<Answer> _answers)
            : base("Choose One Answer Correct", _body, _mark, _correctAnswer, _answers) { }

        // ----------------------------------------------------------------------------------------------------------------------------------------

        #endregion

        #region Methods

        // Recieving & Validating the Answers => No Null or Empty Answers and Answer = 4
        private static List<Answer> ValidateAnswers()
        {
            List<Answer> answers = new(4);
            string text;

            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.Write($"Please Enter The Answer Number {i + 1}: ");
                    text = Console.ReadLine() ?? "";
                    while (answers.Any(answer => answer.Text == text))
                    {
                        Console.WriteLine("You Can't Add Duplicate Answers");
                        text = "";

                    }

                } while (string.IsNullOrEmpty(text) || !text.Any(char.IsLetterOrDigit));

                answers.Add(new Answer(i + 1, text));

            }
            return answers;

        }

        // ----------------------------------------------------------------------------------------------------------------------------------------

        private protected override int ValidateCorrectAnswerIndex()
        {
            int index;
            do
            {
                Console.Write("Please Enter The Number of The Correct Answer: ");
            } while (!int.TryParse(Console.ReadLine() ?? "0", out index) || index < 1 || index > 4);

            return index;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------


        public override Question CreateQuestion()
        {

            Console.WriteLine(Header);
            string body = ValidateBody();
            int mark = ValidateMark();
            List<Answer> answers = ValidateAnswers();
            int correctAnswerIndex = ValidateCorrectAnswerIndex();
            Answer correctAnswer = answers[correctAnswerIndex - 1];

            return new MultipleChoiceQuestion(body, mark, correctAnswer, answers);

        }

        // ----------------------------------------------------------------------------------------------------------------------------------------




        #endregion
    }
}
