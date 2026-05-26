namespace MaoriQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;
            char quizDifficulty;

            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine($"Welcome to the quiz, {name}!");

            quizDifficulty = SelectDifficulty();
            Console.WriteLine($"you chose {quizDifficulty} ");
        }
        static char SelectDifficulty()
        {
            char quizDifficulty;
            Console.WriteLine("Would you like to play \"E\" Easy, \"M\" Medium, or \"H\" Hard?");
            quizDifficulty = Convert.ToChar(Console.ReadLine().Trim().ToUpper()[0]);
            if (quizDifficulty == 'E') Environment.Exit(0);
            return quizDifficulty;

        }
    }
}
