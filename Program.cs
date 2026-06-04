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

            string[] easyQuestions = new string[] {
            "Question 1. What is Te Reo for Ocean? \nA. Moana\nB. Awa\nC. Whenua\nD. Maunga\n",
            "Question 2. What is 7 in Te Reo? \nA. Ono\nB. Rima\nC. Whitu\nD. Waru\n",
            "Question 3. What colour is Ma? \nA. Black\nB. White\nC. Brown\nD. Grey\n",
            "Question 4. What is Matariki in Maori culture? \nA. A type of food\nB. A place \nC. A person \nD. Maori New Year",
            "Question 5. Who is the Maori god of the forest?\nA. Tane Mahuta\nB. Tangaroa\nC. Ao\nD. Haere\n",
            "Question 6. What is Tane widely known for\nA. Creating the big bang\nB. Creating fire\nC. Inventing the weekend\nD. Seperating the sky and earth\n",
            "Question 7. Who brought fire to the humans in Maori mythology? \nA. Tangaroa\nB. Maui\nC. Zeus\nD. Kahukura\n",
            "Question 8. Who chopped down the flagstaff repeatedly, starting the flagstaff war?\nA. Hone Heke \nB. Whina Cooper\nC. Taika Waititi\nD. Rawiri Waititi\n",
            "Question 9. What colour is Kakariki? \nA. Blue\nB. Black\nC. Green\nD. Brown\n",
            "Question 10. When was the Treaty of Waitangi / Te Tiriti?\nA. 1800\nB. 1880\nC. 1860\nD. 1840\n",};
            char[] easyAnswers = new char[] { 'A', 'C', 'B', 'D', 'A', 'D', 'B', 'A', 'C', 'D' };

            string[] mediumQuestions = new string[] {
            "Question 1. What is 100 in Te Reo \nA. Kotahi Rau\nB. Tekau Tekau\nC. Kotahi Mano\nD. Miriona\n",
            "Question 2. What is Auckland in Maori? \nA. Tauranga\nB. Kirikiriroa\nC. Tamaki Makau Rau\nD. Otautahi\n",
            "Question 3. What is the North Island in Maori? \nA. Te Ika a Maui\nB. Rotorua\nC. Te Waipounamu\nD. Te Tai Tokerau\n",
            "Question 4. What is the ancestral homeland of all Maori in Maori culture?\nA. Easter Island\nB. Hawaiki\nC. Samoa\nD. California\n",
            "Question 5. When did Maori arrive in Aotearoa?\nA. 200BC\nB. 1840AD\nC. 100AD\nD. 1300AD\n",
            "Question 6. What is a puku? \nA. Stomach\nB. Head\nC. Shoulders\nD. Knees\n",
            "Question 7. What day is Rahina? \nA. Sunday\nB. Friday\nC. Tuesday\nD. Monday\n",
            "Question 8. Where are taniwha depicted living? \nA. Mountains\nB. Forest\nC. Ocean / Lakes\nD. Desert\n",
            "Question 9. Who was the one to slow down the sun? \nA. Ranginui\nB. Maui\nC. Tane\nD. Te Po\n",
            "Question 10. Which of these are not a real Maori place \nA. Ngamotu\nB. Te Tihi o Maru\nC. Taumatawhakatangi­hangakoauauotamatea­turipukakapikimaunga­horonukupokaiwhen­uakitanatahu\nD. Rukahu Reira\n", };
            char[] mediumAnswers = new char[] { 'A', 'C', 'A', 'B', 'D', 'A', 'D', 'C', 'B', 'D' };

            string[] hardQuestions = new string[] {
            "Question 1. What is Mahunga / Makawe?\nA. Earlobe\nB. Toes\nC. Shoulders\nD. Hair\n",
            "Question 2. \nA.\nB.\nC.\nD.\n",
            "Question 3. \nA.\nB.\nC.\nD.\n",
            "Question 4. \nA.\nB.\nC.\nD.\n",
            "Question 5. \nA.\nB.\nC.\nD.\n",
            "Question 6. \nA.\nB.\nC.\nD.\n",
            "Question 7. \nA.\nB.\nC.\nD.\n",
            "Question 8. \nA.\nB.\nC.\nD.\n",
            "Question 9. \nA.\nB.\nC.\nD.\n",
            "Question 10. \nA.\nB.\nC.\nD."};
            char[] hardAnswers = new char[] { 'D', 'B', 'C' };

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
                        (correctAnswers, incorrectAnswers) = LoadQuestions(easyQuestions, easyAnswers);
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
                if (percentage > highscorepercentage)
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
                if (replay == 'Y') Console.Clear();
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
                //writes question number + question
                Console.WriteLine(questions[i]);

                //user input
                do
                {
                    Console.WriteLine("Enter answer");
                    // checks if its a valid input by seeing if its a item of the array of valid answers.
                    answerTemp = Convert.ToChar(Console.ReadLine().ToUpper()[0]);
                    // remember to check for null values.
                    if ((validinputs.Contains(answerTemp)) != true) Console.WriteLine("invalid input\n");
                } while ((validinputs.Contains(answerTemp)) != true);

                //checks if the answer is correct or wrong
                if (answerTemp == answers[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    correctAnswers++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect.");
                    Console.ResetColor();
                    incorrectAnswers++;
                }
                Console.WriteLine($"You have {correctAnswers} correct answers and {incorrectAnswers} incorrect answers.\n");
            }
            return (correctAnswers, incorrectAnswers);
        }

        //calculates percentage which is used for high score + regular score
        static decimal CalculatePercentage(int correctAnswers, int incorrectAnswers)
        {
            decimal percentage;
            percentage = Math.Round(((decimal)correctAnswers / (incorrectAnswers + correctAnswers)) * 100, 2);
            return percentage;
        }

        //replay function
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
