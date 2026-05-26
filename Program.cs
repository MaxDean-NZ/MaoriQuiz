namespace MaoriQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;
            String quizDifficulty;

            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine().Trim();
            Console.WriteLine($"Welcome to the quiz, {name}!");

            quizDifficulty = SelectDifficulty();
            Console.WriteLine($"you chose {quizDifficulty} ");
        }
        static String SelectDifficulty()
        {
            String quizDifficulty;
            do
            {
                Console.WriteLine("Would you like to play \"E\" Easy, \"M\" Medium, or \"H\" Hard?");
                quizDifficulty = Console.ReadLine().Trim().ToUpper();
                if (quizDifficulty != "E" && quizDifficulty != "M" && quizDifficulty != "H") Console.WriteLine("Invalid input. Please enter E, M, or H");
            } while (quizDifficulty != "E" && quizDifficulty != "M" && quizDifficulty != "H");
            
            if (quizDifficulty == "E") Environment.Exit(0);
            return quizDifficulty;

        }
    }
}
