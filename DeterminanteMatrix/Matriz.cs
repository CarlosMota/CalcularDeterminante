using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DeterminanteMatriz
{
    public class Matriz
    {

        private int[,] _matrizValue = null;
        private StringBuilder _showDeterminante;


        public Matriz(int[,] matriz)
        {
            _matrizValue = matriz;
            _showDeterminante = new StringBuilder();
        }

        public int numColunas = 0;

        public void print2DMatriz(int[,] matriz, bool space = false)
        {
            for(int i = 0; i < matriz.GetLength(0); i++)
            {
                if (i > 0 && space)
                {
                    Debug.Write("                  |");
                }
                else {
                    Debug.Write("|");
                }
                
                for (int j = 0; j < matriz.GetLength(0); j++)
                {
                    Debug.Write(string.Format(" ({0},{1})={2} ", i + 1, j + 1, matriz[i, j]));
                }
                Debug.WriteLine("|");
            }
        }

        public Double CalcularDeterminante2x2(int[,] matriz)
        {
            if(matriz.GetLength(0) != 2)
            {
                System.Console.WriteLine("Não é uma matriz 2x2");
                return Double.NaN;
            }
            else
            {
                return matriz[0, 0] * matriz[1,1] - matriz[0,1] * matriz[1,0];
            }
        }

        public Double CalcularLaplace3x3(int[,] matriz, int linha)
        {
            double determinante = 0;
            int _linha = linha;
            int coluna = 1;

            print2DMatriz(matriz);

            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                if(x == (_linha - 1))
                {
                    for (int y = 0; y < matriz.GetLength(1); y++)
                    {
                        determinante += matriz[x, y] * CalcularCofator(_linha,coluna, matriz);
                        coluna++;
                    }
                }
            }

            return determinante;
        }

        public Double CalcularDeterminanteNxN(int[,] matriz, int linha)
        {
            var showDeterminante = new StringBuilder();
            showDeterminante.Append("D = ");
            double determinante = 0;
            int _linha = linha;
            int _coluna = 1;

            Debug.WriteLine("");
            print2DMatriz(matriz);
            Debug.WriteLine("");

            if(matriz.GetLength(0) == 2)
            {
                return CalcularDeterminante2x2(matriz);
            }

            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                if (x == (linha - 1))
                {
                    //Debug.WriteLine("");
                    for (int y = 0; y < matriz.GetLength(1); y++)
                    {
                        var cofator = CalcularCofator(_linha, _coluna, matriz);
                        determinante += matriz[x, y] * cofator;
                        showDeterminante.Append($"{matriz[x, y]} x {cofator}");
                        _coluna++;
                        if((y+1) < matriz.GetLength(1))
                        {
                            showDeterminante.Append(" + ");
                        }
                    }
                    //Debug.WriteLine("");
                }
            }

            showDeterminante.Append($" = {determinante}");
            Debug.WriteLine(showDeterminante.ToString());
            //Debug.WriteLine("Determinante = "+determinante);

            return determinante;
        }

        public int[,] RemoveLinhaEColuna(int[,] matriz,int linha, int coluna)
        {
            int[,] newMatriz = new int[matriz.GetLength(0) - 1, matriz.GetLength(1) - 1];
            int newX = 0;
            int newY = 0;

            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                if(x != linha-1)
                {
                    for (int y = 0; y < matriz.GetLength(0); y++)
                    {
                        if(y != coluna-1)
                        {
                            newMatriz[newX, newY] = matriz[x, y];
                            newY++;
                        }
                    }

                    newX++;
                    newY = 0;
                }
            }

            return newMatriz;
        }

        public int[,] GetMatrizValue()
        {
            return _matrizValue;
        }

        public Double CalcularCofator(int linha, int coluna, int[,] matriz)
        {
            var newTable = RemoveLinhaEColuna(matriz, linha, coluna);
            var determinante = CalcularDeterminante(newTable);
            var cofator = Math.Pow(-1, (linha) + (coluna)) * determinante;
            Debug.WriteLine("");
            Debug.Write($"Cofator = A({linha}{coluna}) x ");
            print2DMatriz(newTable, true);
            Debug.WriteLine("Cofator = "+cofator);
            return cofator;
        }

        public Double CalcularDeterminante(int[,] matriz)
        {
            if(matriz.GetLength(0) == 2)
            {
                return CalcularDeterminante2x2(matriz);
            }

            return CalcularDeterminanteNxN(matriz, 1);
            
            //return Double.NaN;
        }

    }
}
