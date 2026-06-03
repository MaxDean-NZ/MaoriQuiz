namespace MaoriQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;
            char quizDifficulty;
            char replay = 'Y';
            
            int correctAnswers = 0, incorrectAnswers = 0;
            int highscoreCorrect = 0, highscoreIncorrect = 0;
            decimal percentage = 0, highscorepercentage = 0;

            string[] easyQuestions = new string[] { "easy mode question one", "two", "three" };
            char[] easyAnswers = new char[] { 'A', 'B', 'C' };

            string[] mediumQuestions = new string[] { "medium mode question one", "two", "three" };
            char[] mediumAnswers = new char[] { 'A', 'B', 'C' };

            string[] hardQuestions = new string[] { "hard mode question one", "two", "three" };
            char[] hardAnswers = new char[] { 'A', 'B', 'C' };

            // prompts the user for their name
            name = SelectName();
            Console.WriteLine($"\nWelcome to the quiz, {name}!");

            do
            {
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
                        (correctAnswers, incorrectAnswers) =  LoadQuestions(easyQuestions, easyAnswers);
                        break;

                    // Loads Medium Mode
                    case 'M':
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Medium");
                        Console.ResetColor();
                        (correctAnswers, incorrectAnswers) = LoadQuestions(mediumQuestions, mediumAnswers);
                        break;

                    // Loads Hard Mode
                    case 'H':
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Hard");
                        Console.ResetColor();
                        (correctAnswers, incorrectAnswers) = LoadQuestions(hardQuestions, hardAnswers);
                        break;
                }

                //calculates percentage score
                percentage = CalculatePercentage(correctAnswers, incorrectAnswers);

                //calculates whether it is a highscore or not
                if(percentage > highscorepercentage)
                {
                    highscorepercentage = percentage;
                    highscoreCorrect = correctAnswers;
                    highscoreIncorrect = incorrectAnswers;

                    Console.WriteLine($"You have a new high score with {correctAnswers} correct answers and {incorrectAnswers} incorrect answers, with a percentage of {percentage}%");
                }
                else
                {
                    Console.WriteLine($"You have {correctAnswers} correct answers and {incorrectAnswers} incorrect answers, with a percentage of {percentage}%");
                }

                //asks whether the player would like to replay or not
                replay = Replay();
                if(replay == 'Y') Console.Clear();
            } while (replay == 'Y');
        }

        static String SelectName()
        {
            String name, nameToUpper;
            char[] allowedLetters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ' };

            bool containsinvalidletter = false;
            bool validname = false;

            //do while loop makes it so it keeps reprompting until its within the requirements (3-20 char, only A-Z, not null)
            do
            {
                containsinvalidletter = false;
                validname = false;

                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine().Trim();
                // checks whether is null or empty
                if (name == null || name == "") Console.WriteLine("Name is not allowed to be empty.\n");
                // checks whether it obeys lower and upper bound
                if (name.Length > 20 || name.Length < 3 && name != "") Console.WriteLine("Name has to be between 20 and 3 characters.\n");

                if (name.Length < 21 && name.Length > 2 && name != "")
                {
                    nameToUpper = name.ToUpper();
                    char[] namechars = nameToUpper.ToCharArray();

                    do
                    {
                        // checks each individual letter whether its a valid letter or not
                        foreach (char letter in namechars)
                        {
                            if ((allowedLetters.Contains(letter)) != true)
                            {
                                containsinvalidletter = true;
                            }
                        }
                        validname = true;
                    } while (containsinvalidletter == false && validname == false);
                    if (containsinvalidletter) Console.WriteLine("Invalid characters, please enter A-Z only.\n");
                }
            } while (name == null || name == "" || name.Length > 20 || name.Length < 3 || validname == false || containsinvalidletter == true);
            return name;
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

        static (int, int) LoadQuestions(string[] questions, char[] answers)
        {
            int correctAnswers = 0, incorrectAnswers = 0;
            char answerTemp = 'X';
            //valid inputs decides what characters are allowed
            char[] validinputs = new char[] { 'A', 'B', 'C', 'D' };

            for (int i = 0; i < questions.Length; i++)
            {
                //writes question
                Console.WriteLine(questions[i]);

                //user input
                do
                {
                    Console.WriteLine("Enter answer");
                    // checks if its a valid input by seeing if its a item of the array of valid answers.
                    answerTemp = Convert.ToChar(Console.ReadLine().ToUpper()[0]);
                    // remember to check for null values.
                    if (validinputs.Contains(answerTemp)) Console.WriteLine("valid input");
                    if ((validinputs.Contains(answerTemp)) != true) Console.WriteLine("invalid input\n");
                } while ((validinputs.Contains(answerTemp)) != true);

                //checks if the answer is correct or wrong
                if (answerTemp == answers[i])
                {
                    Console.WriteLine("answer is correct");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine("answer is wrong.");
                    incorrectAnswers++;
                }
                Console.WriteLine($"You have {correctAnswers} correct answers and {incorrectAnswers} incorrect answers.\n");
            }
            return (correctAnswers, incorrectAnswers);
        }

        static decimal CalculatePercentage(int correctAnswers, int incorrectAnswers)
        {
            decimal percentage;
            percentage = Math.Round(((decimal)correctAnswers / (incorrectAnswers+correctAnswers))*100,2);
            return percentage;
        }

        static char Replay()
        {
            String replay = " ";
            do
            {
                Console.WriteLine("Would you like to replay? [Y/N]: ");
                replay = Console.ReadLine().Trim().ToUpper();
                if (replay != "Y" && replay != "N") Console.WriteLine("Invalid input, please enter [Y/N].");
            } while (replay != "Y" && replay != "N");
            return Convert.ToChar(replay);
        }
    }
}
