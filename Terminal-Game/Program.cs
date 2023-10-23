using AddAndSub;
using MulAndDiv;
using Equation;


AdditionSubstraction easyOperations = new AdditionSubstraction();
MultiplicationDivision middleOperations = new MultiplicationDivision();
EquationsFirstLevel hardOperations = new EquationsFirstLevel();

Console.WriteLine("Elige el nivel de dificultad: \n1. Facil \n2. Medio \n3. Dificil");
int UserResponse = Convert.ToInt32(Console.ReadLine());

if (UserResponse == 1)
{
    Console.WriteLine("Facil");
    easyOperations.AddsSubs();
}
else if (UserResponse == 2)
{
    Console.WriteLine("Medio");
    middleOperations.MulsDivs();
}
else if (UserResponse == 3)
{
    Console.WriteLine("Dificil");
    hardOperations.Equitions();
}