namespace MaoriQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;
            String quizDifficulty;

            do
            {
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine().Trim();
                // checks whether is null or empty
                if (name == null || name == "") Console.WriteLine("Name is not allowed to be empty.\n");
                // checks whether it obeys lower and upper bound
                if (name.Length > 20 || name.Length < 3) Console.WriteLine("Name has to be between 20 and 3 characters.\n");
            } while(name == null || name == "");

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
                // checks if input is valid
                if (quizDifficulty != "E" && quizDifficulty != "M" && quizDifficulty != "H") Console.WriteLine("Invalid input. Please enter E, M, or H\n");
            } while (quizDifficulty != "E" && quizDifficulty != "M" && quizDifficulty != "H");

            if (quizDifficulty == "E") Environment.Exit(0);
            return quizDifficulty;

        }
    }
}
