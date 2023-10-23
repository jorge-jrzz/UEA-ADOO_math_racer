namespace Numbers
{
    public class NumbersForOperations
    {
        public int NumberRandom(int min, int max)
        {
            Random random = new Random();
            double numeroDecimalAleatorio = random.NextDouble();
            int numeroEnteroAleatorio = random.Next(min, max);
            int numberRandom = (int)(numeroDecimalAleatorio * numeroEnteroAleatorio);
            return numberRandom;
        }

        public int IncorrectResponseInt(int correctResponse)
        {
            Random random = new Random();
            int incorrectResponse;

            do
            {
                // Se pueden modificar los rangos para poner mas difultad al juego.
                incorrectResponse = random.Next((correctResponse - 20), (correctResponse + 20));
            }
            while (incorrectResponse == correctResponse);

            return incorrectResponse;
        }

        public double IncorrectResponseDecimal(double correctResponse)
        {
            Random random = new Random();
            int correct = (int)(correctResponse);
            double incorrectResponse;

            do
            {
                // Se pueden modificar los rangos para poner mas difultad al juego.
                incorrectResponse = random.Next((correct - 20), (correct + 20));
            }
            while (incorrectResponse == correctResponse);

            incorrectResponse = incorrectResponse * 1.11324456;

            return incorrectResponse;
        }
    }
}