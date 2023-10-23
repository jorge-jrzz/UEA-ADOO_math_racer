using Numbers;

namespace MulAndDiv
{
    public class MultiplicationDivision
    {
        NumbersForOperations numbers = new NumbersForOperations();

        private double[] CorrectResponse(int num1, int num2)
        {
            double correctResponse;
            int operation = numbers.NumberRandom(1, 1000);
            int isPair = operation % 2;
            double[] valores = new double[2];

            // Si el numero (operation) es par, entonces la operacion es multiplicacion, si es impar, entonces la operacion es division.
            // 0 es multiplicacion y 1 es division.

            double num1D = (double)(num1 + 0.0);

            if (isPair == 0)
            {
                correctResponse = (double)(num1 * num2);
            }
            else
            {
                correctResponse = (double)(num1D / num2);
            }

            valores[0] = correctResponse;
            valores[1] = isPair;

            return valores;
        }

        public void MulsDivs()
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

                int num1 = numbers.NumberRandom(-100, 100);
                int num2 = numbers.NumberRandom(-100, 100);
                double[] valores = CorrectResponse(num1, num2);
                double correctResponse = valores[0];
                double isPair = valores[1];
                double incorrectResponse = numbers.IncorrectResponseDecimal(correctResponse);

                // Dependiendo la operacion, se muestra el signo de la operacion.
                if (isPair == 0)
                {
                    Console.WriteLine($"{num1} * {num2} = ?");
                }
                else
                {
                    Console.WriteLine($"{num1} / {num2} = ?");
                }



                // Se muestra la respuesta correcta y la incorrecta en orden aleatorio.
                int randomAwser = random.Next(1, 3);
                if (randomAwser == 1)
                {
                    Console.WriteLine($"1) {correctResponse.ToString("F2")}");
                    Console.WriteLine($"2) {incorrectResponse.ToString("F2")}");
                }
                else
                {
                    Console.WriteLine($"1) {incorrectResponse.ToString("F2")}");
                    Console.WriteLine($"2) {correctResponse.ToString("F2")}");
                }

                int UserResponse = Convert.ToInt32(Console.ReadLine());

                // Se valida si la respuesta del usuario es correcta o incorrecta dependiendo del acomodo del fragmento de codigo de arriba.
                if (randomAwser == 1)
                {
                    if (UserResponse == 1)
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
                    if (UserResponse == 2)
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