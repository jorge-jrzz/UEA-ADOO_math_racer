using Numbers;

namespace Equation
{
    public class EquationsFirstLevel
    {
        NumbersForOperations numbers = new NumbersForOperations();

        private double CorrectResponse(int a, int b, int c)
        {
            double correctResponse = 500;

            double cD = (double)(c + 0.0);
            if (a != 0)
            {
                double x = (cD - b) / a;
                correctResponse = x;
            }

            return correctResponse;
        }

        public void Equitions()
        {
            int score = 10;
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                if (score <= 7)
                {
                    Console.WriteLine("Perdiste");
                    break;
                }

                int a;
                do
                {
                    // ElapsedEventArgs cociente con la variable, no puede ser 0
                    a = numbers.NumberRandom(-100, 100);
                }
                while (a == 0);
                int b = numbers.NumberRandom(-100, 100);
                int c = numbers.NumberRandom(-100, 100);

                double correctResponse = CorrectResponse(a, b, c);
                double incorrectResponse = numbers.IncorrectResponseDecimal(correctResponse);

                Console.WriteLine($"{a}x + {b} = {c}");

                // Se muestra la respuesta correcta y la incorrecta en orden aleatorio.
                int randomAwser = random.Next(1, 3);
                if (randomAwser == 1)
                {
                    Console.WriteLine($"1) x = {correctResponse.ToString("F2")}");
                    Console.WriteLine($"2) x = {incorrectResponse.ToString("F2")}");
                }
                else
                {
                    Console.WriteLine($"1) x = {incorrectResponse.ToString("F2")}");
                    Console.WriteLine($"2) x = {correctResponse.ToString("F2")}");
                }

                int userResponse = Convert.ToInt32(Console.ReadLine());

                // Se valida si la respuesta del usuario es correcta o incorrecta dependiendo del acomodo del fragmento de codigo de arriba.
                if (randomAwser == 1)
                {
                    if (userResponse == 1)
                    {
                        Console.WriteLine("Correcto");
                    }
                    else
                    {
                        Console.WriteLine("Incorrecto");
                        score--;
                    }
                }
                else
                {
                    if (userResponse == 2)
                    {
                        Console.WriteLine("Correcto");
                    }
                    else
                    {
                        Console.WriteLine("Incorrecto");
                        score--;
                    }
                }
            }
        }
    }
}