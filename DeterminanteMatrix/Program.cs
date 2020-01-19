using System;

namespace DeterminanteMatriz
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] matriz = new int[2, 2] { { 1, 2 }, { 2, 4 } };
            var matriz2x2 = new Matriz(new int[2, 2] { { 2, 9 }, { -1, 6 } });
            matriz2x2.print2DMatriz(matriz2x2.GetMatrizValue());
            System.Console.WriteLine("Determinante 2x2 = "+ matriz2x2.CalcularDeterminante2x2(matriz2x2.GetMatrizValue()));

            var _matriz3x3 = new Matriz(new int[,] { { 2, 1, 2 }, { -3, 4, 1 }, { 3, 2, 5 } });
            System.Console.WriteLine("Determinante 3x3 = " + _matriz3x3.CalcularDeterminanteNxN(_matriz3x3.GetMatrizValue(), 1));

            var _matriz4x4 = new Matriz(new int[,] { { 4, 5, -3, 0 }, { 2, -1, 3, 1 }, { 1, -3, 2, 1 }, { 0, 2, -2, 5 } });
            System.Console.WriteLine("Determinante 4x4 = " + _matriz4x4.CalcularDeterminanteNxN(_matriz4x4.GetMatrizValue(), 1));

            var _matriz5x5 = new Matriz(new int[,] { { 1, 2, 3, -3, 1 }, { 0, 4, 0, 0, 0 }, { 0, 1, 0, 1, 1 }, { 0, -6, 6, 1, 3 }, { 0, 2, 0, -1, 1 } });
            System.Console.WriteLine("Determinante 5x5 = " + _matriz5x5.CalcularDeterminanteNxN(_matriz5x5.GetMatrizValue(), 1));

        }
    }
}
