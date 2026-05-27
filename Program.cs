namespace MaoriQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;
            char quizDifficulty;

            string[] easyQuestions = new string[] { "easy mode question one", "two", "three" };
            char[] easyAnswers = new char[] { 'e', 'B', 'C' };

            string[] mediumQuestions = new string[] { "medium mode question one", "two", "three" };
            char[] mediumAnswers = new char[] { 'm', 'B', 'C' };

            string[] hardQuestions = new string[] { "hard mode question one", "two", "three" };
            char[] hardAnswers = new char[] { 'h', 'B', 'C' };

            // asks name, loops if left null or empty
            do
            {
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine().Trim();
                // checks whether is null or empty
                if (name == null || name == "") Console.WriteLine("Name is not allowed to be empty.\n");
                // checks whether it obeys lower and upper bound
                if (name.Length > 20 || name.Length < 3) Console.WriteLine("Name has to be between 20 and 3 characters.\n");
            } while(name == null || name == "" || name.Length > 20 || name.Length < 3);

            Console.WriteLine($"Welcome to the quiz, {name}!");

            quizDifficulty = Convert.ToChar(SelectDifficulty());

            // clears console then initiates the quiz from difficulty given
            Console.Clear();
            switch (quizDifficulty)
            {
                // Loads Easy Mode
                case 'E':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Easy");
                    Console.ResetColor();
                    LoadQuestions(easyQuestions,easyAnswers);
                    break;

                // Loads Medium Mode
                case 'M':
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Medium");
                    Console.ResetColor();
                    LoadQuestions(mediumQuestions, mediumAnswers);
                    break;

                // Loads Hard Mode
                case 'H':
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Hard");
                    Console.ResetColor();
                    LoadQuestions(hardQuestions, hardAnswers);
                    break;
            }
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

            //if (quizDifficulty == "E") Environment.Exit(0);
            return quizDifficulty;
        }

        static int LoadQuestions(string[] questions, char[] answers)
        {
            int correctAnswers = 0;
            char answertemp;
            char[] validinputs = new char[] { 'A', 'B', 'C', 'D' };
            Console.WriteLine(questions[0]);
            Console.WriteLine(answers[0]);
            
            // checks if its a valid input.
            answertemp = Convert.ToChar(Console.ReadLine().ToUpper()[0]);
            if (validinputs.Contains(answertemp)) Console.WriteLine("valid input");
            if ((validinputs.Contains(answertemp))!= true) Console.WriteLine("invalid input");

            return correctAnswers;
        }
    }
}
