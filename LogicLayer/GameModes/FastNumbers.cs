using System.Text;

namespace BrainGames.BLL
{
    public class FastNumbers
    {

        private StringBuilder _gameUIBuilder = new StringBuilder();
        public int Score { get; set; } = default;
        private int _lives = default;

        public void RunGame()
        {
            _lives = 3;
            while (_lives > 0)
            {
                Random randMathOperation = new();

                int mathOperation = Convert.ToInt32(randMathOperation.Next(1, 5));
                int userAnswer = default;

                switch (mathOperation)
                {
                    case 1:
                        GenerateAddition(out int additionAnswer);
                        userAnswer = Convert.ToInt32(Console.ReadLine());
                        CheckAnswer(userAnswer, additionAnswer);
                        ClearUI();
                        break;
                    case 2:
                        GenerateSubtraction(out int substitutionAnswer);
                        userAnswer = Convert.ToInt32(Console.ReadLine());
                        CheckAnswer(userAnswer, substitutionAnswer);
                        ClearUI();
                        break;
                    case 3:
                        GenerateMultiplication(out int multiplicationAnswer);
                        userAnswer = Convert.ToInt32(Console.ReadLine());
                        CheckAnswer(userAnswer, multiplicationAnswer);
                        ClearUI();
                        break;
                    case 4:
                        GenerateDivision(out int divisionAnswer);
                        userAnswer = Convert.ToInt32(Console.ReadLine());
                        CheckAnswer(userAnswer, divisionAnswer);
                        ClearUI();
                        break;
                }
            }
        }

        private void GenerateNumbers(out int firstNumber, out int secondNumber, int min = 1, int max = 20)
        {
            Random randFirstNumber = new();
            Random randSecondNumber = new();

            firstNumber = Convert.ToInt32(randFirstNumber.Next(min, max));
            secondNumber = Convert.ToInt32(randSecondNumber.Next(min, max));
        }

        private void GenerateNumbersForDivision(out int firstNumber, out int secondNumber, int min = 1, int max = 20)
        {
            Random randFirstNumber = new();
            Random randSecondNumber = new();

            firstNumber = Convert.ToInt32(randFirstNumber.Next(min, max));
            secondNumber = Convert.ToInt32(randSecondNumber.Next(min, max));

            if (firstNumber % secondNumber != 0)
                GenerateNumbersForDivision(out firstNumber, out secondNumber);
        }

        private void CheckAnswer(int userAnswer, int answer)
        {
            if (userAnswer == answer) Score++;
            else _lives--;

            if (_lives == 0)
                return;
        }

        private void GenerateAddition(out int answer)
        {
            GenerateNumbers(out int firstNumber, out int secondNumber);
            answer = firstNumber + secondNumber;

            _gameUIBuilder.AppendLine($"Lives left: {_lives}  Score: {Score}");
            _gameUIBuilder.AppendLine($"{firstNumber} + {secondNumber} = ");
            Console.WriteLine(_gameUIBuilder.ToString());
        }

        private void GenerateSubtraction(out int answer)
        {
            GenerateNumbers(out int firstNumber, out int secondNumber);
            answer = firstNumber - secondNumber;

            _gameUIBuilder.AppendLine($"Lives left: {_lives}  Score: {Score}");
            _gameUIBuilder.AppendLine($"{firstNumber} - {secondNumber} = ");
            Console.WriteLine(_gameUIBuilder.ToString());
        }

        private void GenerateMultiplication(out int answer)
        {
            GenerateNumbers(out int firstNumber, out int secondNumber, max: 10);
            answer = firstNumber * secondNumber;

            _gameUIBuilder.AppendLine($"Lives left: {_lives}  Score: {Score}");
            _gameUIBuilder.AppendLine($"{firstNumber} * {secondNumber} = ");
            Console.WriteLine(_gameUIBuilder.ToString());
        }

        private void GenerateDivision(out int answer)
        {
            GenerateNumbersForDivision(out int firstNumber, out int secondNumber);
            answer = firstNumber / secondNumber;

            _gameUIBuilder.AppendLine($"Lives left: {_lives}  Score: {Score}");
            _gameUIBuilder.AppendLine($"{firstNumber} / {secondNumber} = ");
            Console.WriteLine(_gameUIBuilder.ToString());
        }

        private void ClearUI()
        {
            _gameUIBuilder.Clear();
            Console.Clear();
        }
    }
}
