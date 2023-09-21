namespace Prueba;
using System;
using System.Security.Cryptography;

public class Numeros_Random
{
    public void Inside()
    {
        Console.WriteLine("Instancia de Random dentro del bucle");
        for (int i = 0; i < 10; i++)
        {
            Random random1 = new Random();
            int numeroEnteroEnRango = random1.Next(0, 101);
            Console.WriteLine($"Número entero en rango (0 a 100): {numeroEnteroEnRango}");

        }

    }

    public void Outside()
    {
        Console.WriteLine("Instancia de Random fuera del bucle");
        Random random2 = new Random();

        for (int i = 0; i < 10; i++)
        {
            int numeroEnteroEnRango = random2.Next(0, 101);
            Console.WriteLine($"Número entero en rango (0 a 100): {numeroEnteroEnRango}");
        }
    }

    public void Seed()
    {
        Console.WriteLine("Instancia de Random con semilla");
        Random random3 = new Random(874236);

        for (int i = 0; i < 10; i++)
        {
            int numeroEnteroEnRango = random3.Next(0, 101);
            Console.WriteLine($"Número entero en rango (0 a 100): {numeroEnteroEnRango}");
        }
    }

    public void HashSeed()
    {
        Console.WriteLine("Instancia de Random con semilla hashcode");
        Random random4 = new Random(Guid.NewGuid().GetHashCode());

        for (int i = 0; i < 10; i++)
        {
            int numeroEnteroEnRango = random4.Next(0, 101);
            Console.WriteLine($"Número entero en rango (0 a 100): {numeroEnteroEnRango}");
        }
    }

    public void TicksSeed()
    {
        Console.WriteLine("Instancia de Random con semilla hashcode multiplicada por los ticks del momento");
        Random random5 = new Random((int)DateTime.Now.Ticks);

        for (int i = 0; i < 10; i++)
        {
            int numeroEnteroEnRango = random5.Next(0, 101);
            Console.WriteLine($"Número entero en rango (0 a 100): {numeroEnteroEnRango}");
        }
    }



    public int GetRandomNumber()
    {
        using (RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider())
        {
            byte[] tokenBuffer = new byte[4];        // `int32` toma 4 bytes en C#
            rngCrypt.GetBytes(tokenBuffer);
            return BitConverter.ToInt32(tokenBuffer, 0);
        }
    }
}
