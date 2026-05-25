namespace MaoriQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;
            char difficulty;

            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine($"Welcome to the quiz, {name}!");

            difficulty = SelectDifficulty();
            Console.WriteLine($"you chose {difficulty} ");
        }
        static char SelectDifficulty()
        {
            char difficulty;
            Console.WriteLine("Would you like to play \"E\" Easy, \"M\" Medium, or \"H\" Hard?");
            difficulty = Convert.ToChar(Console.ReadLine());
            return difficulty;

        }
    }
}
