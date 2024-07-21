using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C#");
            subject.CreateExam();

            Console.WriteLine("Do You Want To Start The Exam?");
            Console.WriteLine("1- Yes\n2- No");
            int choice;
            do
            {
                Console.Write("Please Enter The Number Of Your Choice: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2);

            Console.Clear();

            Stopwatch stopwatch = new Stopwatch();

            if (subject.Exam is not null && choice == 1)
            {
                stopwatch.Start();
                subject.Exam.ShowExam();
                stopwatch.Stop();
                Console.WriteLine($"The Exam Time Is: {stopwatch.Elapsed}");

            }
        }
    }
}
