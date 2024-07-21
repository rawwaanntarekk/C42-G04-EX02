using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal struct Subject
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public Exam? Exam { get; set; }

        // --------------------------------------------------------------------------------------------------------------------
        #endregion

        #region Constructors
        public Subject(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        // --------------------------------------------------------------------------------------------------------------------

        private static int ShowOptions()
        {
            int Type;
            do
            {
                Console.WriteLine("Please Enter The Number Of The Exam Type: ");
                Console.WriteLine("1- Practical Exam\n2- Final Exam");

            } while (!int.TryParse(Console.ReadLine(), out Type) || Type < 1 || Type > 2);



            return Type;
        }
        // --------------------------------------------------------------------------------------------------------------------

        public void CreateExam()
        {
            int Type = ShowOptions();

            if (Type == 1)
            {
                PracticalExam practicalExam = new();
                Exam = practicalExam.CreateExam();
            }
            else
            {
                FinalExam finalExam = new();
                Exam = finalExam.CreateExam();
            }


        }

        #endregion

    }
}
