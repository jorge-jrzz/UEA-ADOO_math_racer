using Numbers;

namespace AddAndSub
{
    public class AdditionSubstraction
    {
        NumbersForOperations numbers = new NumbersForOperations();

        private int[] CorrectResponse(int num1, int num2)
        {
            int correctResponse;
            int operation = numbers.NumberRandom(1, 1000);
            int isPair = operation % 2;
            int[] valores = new int[2];

            // Si el numero (operation) es par, entonces la operacion es suma, si es impar, entonces la operacion es resta.
            // 0 es suma y 1 es resta.

            if (isPair == 0)
            {
                correctResponse = num1 + num2;
            }
            else
            {
                correctResponse = num1 - num2;
            }

            valores[0] = correctResponse;
            valores[1] = isPair;

            return valores;
        }


        public void AddsSubs()
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

                int num1 = numbers.NumberRandom(-300, 300);
                int num2 = numbers.NumberRandom(-300, 300);
                int[] valores = CorrectResponse(num1, num2);
                int correctResponse = valores[0];
                int isPair = valores[1];
                int incorrectResponse = numbers.IncorrectResponseInt(correctResponse);

                // Dependiendo la operacion, se muestra el signo de la operacion.
                if (isPair == 0)
                {
                    Console.WriteLine($"{num1} + {num2} = ?");
                }
                else
                {
                    Console.WriteLine($"{num1} - {num2} = ?");
                }

                // Se muestra la respuesta correcta y la incorrecta en orden aleatorio.
                int randomAwser = random.Next(1, 3);
                if (randomAwser == 1)
                {
                    Console.WriteLine($"1) {correctResponse}");
                    Console.WriteLine($"2) {incorrectResponse}");
                }
                else
                {
                    Console.WriteLine($"1) {incorrectResponse}");
                    Console.WriteLine($"2) {correctResponse}");
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
