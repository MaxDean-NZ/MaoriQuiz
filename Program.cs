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

            // More questions can easily be added by modifying the question and answer key.

            string[] easyQuestions = new string[] {
            "Question 1. What is Te Reo for Ocean? \nA. Moana\nB. Awa\nC. Whenua\nD. Maunga\n",
            "Question 2. What is 7 in Te Reo? \nA. Ono\nB. Rima\nC. Whitu\nD. Waru\n",
            "Question 3. What colour is Ma? \nA. Black\nB. White\nC. Brown\nD. Grey\n",
            "Question 4. What is Matariki in Maori culture? \nA. A type of food\nB. A place \nC. A person \nD. Maori New Year\n",
            "Question 5. Who is the Maori god of the forest?\nA. Tane Mahuta\nB. Tangaroa\nC. Ao\nD. Haere\n", };
            char[] easyAnswers = new char[] { 'A', 'C', 'B', 'D', 'A', };

            string[] mediumQuestions = new string[] {
            "Question 1. What is 100 in Te Reo? \nA. Kotahi Rau\nB. Tekau Tekau\nC. Kotahi Mano\nD. Miriona\n",
            "Question 2. What is Auckland in Maori? \nA. Tauranga\nB. Kirikiriroa\nC. Tamaki Makaurau\nD. Otautahi\n",
            "Question 3. What is the North Island in Maori? \nA. Te Ika a Maui\nB. Rotorua\nC. Te Waipounamu\nD. Te Tai Tokerau\n",
            "Question 4. What is the ancestral homeland of all Maori in Maori culture? \nA. Easter Island\nB. Hawaiki\nC. Samoa\nD. California\n",
            "Question 5. When did Maori arrive in Aotearoa? \nA. 200BC\nB. 1840AD\nC. 100AD\nD. 1300AD\n"};
            char[] mediumAnswers = new char[] { 'A', 'C', 'A', 'B', 'D' };

            string[] hardQuestions = new string[] {
            "Question 1. What is Mahunga / Makawe?\nA. Earlobe\nB. Toes\nC. Shoulders\nD. Hair\n",
            "Question 2. If you feel ngenge, you are: \nA. Happy\nB. Tired\nC. Sad\nD. Angry\n",
            "Question 3. If Te Kapua is tekau ma wha years old, how old is he? \nA. 15\nB. 14\nC. 21\nD. 24\n",
            "Question 4. An Ika could be found at a: \nA. Maunga\nB. Awa\nC. Whenua\nD. Tahora\n",
            "Question 5. Which of these is not a member of the first 7 canoes to Aotearoa. \nA. Te Arawa\nB. Tainui\nC. Aotea\nD. Te Kawau\n"};
            char[] hardAnswers = new char[] { 'D', 'B', 'B', 'B', 'D' };

            // prompts the user for their name
            name = SelectName();
            Console.WriteLine($"\nWelcome to the Maori quiz, {name}!");

            // This is the main gameplay loop
            do
            {
                // displays highscore and welcome message after repeated play through.
                if (highscoreCorrect > 0)
                {
                    Console.WriteLine($"Welcome back, {name}!");
                    Console.WriteLine($"Your highscore is {highscorepercentage}%, with {highscoreCorrect} out of {highscoreCorrect + highscoreIncorrect}.");
                }

                quizDifficulty = Convert.ToChar(SelectDifficulty());
                Console.Clear();
                // This switch loads the difficulties questions into the LoadQuestions() function, with it returning the number of incorrect and correct answers so the players grade / result can be calculated.
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

                /*calculates whether it is a highscore or not
                if it is a new highscore it changes the old highscore to the new highscore.*/

                if (percentage > highscorepercentage)
                {
                    highscorepercentage = percentage;
                    highscoreCorrect = correctAnswers;
                    highscoreIncorrect = incorrectAnswers;

                    Console.WriteLine($"Well done, {name}! You have a new high score with {correctAnswers} correct answers and {incorrectAnswers} incorrect answers, with a percentage of {percentage}%");
                }
                else
                {
                    Console.WriteLine($"Thanks for playing the quiz, {name}. You have {correctAnswers} correct answers and {incorrectAnswers} incorrect answers, with a percentage of {percentage}%");
                }

                //asks whether the player would like to replay or not
                replay = Replay();
                if (replay == 'Y') Console.Clear();
            } while (replay == 'Y');
        }

        // Takes user input for the name, validates it then returns it to the main loop.
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
                // checks whether it is in the boundaries (3 -> 20 characters)
                if (name.Length > 20 || name.Length < 3 && name != "") Console.WriteLine("Name has to be between 20 and 3 characters.\n");

                // the name meets the requirements above, it then checks whether it contains any invalid characters.
                if (name.Length < 21 && name.Length > 2 && name != "")
                {
                    nameToUpper = name.ToUpper();
                    char[] namechars = nameToUpper.ToCharArray();

                    do
                    {
                        // checks each individual letter whether its a valid letter or not
                        foreach (char letter in namechars)
                        {
                            // if the char is not in the list of valid letters (A -> Z, a -> z) it sets the bool containsinvalidletter to true, which breaks the loop and reprompts the user for a new name.
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

        // This method takes player input, validates it, then returns the difficulty to the main loop
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
            string answerTemp;
            char userAnswer = 'X';
            // valid inputs decides what characters are allowed.
            // the list is modifiable allowing flexability in the amount of answers.
            char[] validinputs = new char[] { 'A', 'B', 'C', 'D' };

            for (int i = 0; i < questions.Length; i++)
            {
                //writes question number + question
                Console.WriteLine(questions[i]);

                // user input.
                do
                {
                    Console.WriteLine("Enter answer:");
                    answerTemp = Console.ReadLine().ToUpper().Trim();
                    // checks if the answer is null
                    if (answerTemp == "") Console.WriteLine("Invalid Input. Empty values are not allowed.");
                    // checks if the answer is greater than 1 char
                    if (answerTemp.Length > 1) Console.WriteLine("Invalid Input. Please enter a single character.");
                    
                    if (!(answerTemp.Length > 1) && answerTemp != "") userAnswer = Convert.ToChar(answerTemp);
                    // checks if the answer is in the valid list of chars
                    if ((validinputs.Contains(userAnswer)) != true && answerTemp.Length == 1) Console.WriteLine("Invalid Input. Please enter A, B, C or D\n");
                } while ((validinputs.Contains(userAnswer)) != true);

                //checks if the answer is correct or wrong
                if (userAnswer == answers[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!\n");
                    Console.ResetColor();
                    correctAnswers++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect.");
                    Console.WriteLine($"The answer was {answers[i]}\n");
                    Console.ResetColor();
                    incorrectAnswers++;
                }

                answerTemp = "";
                userAnswer = 'X';
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

        //replay function , if player answers Y, it resarts gameplay loop, if player answers N, it exits gameplay loop.
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
