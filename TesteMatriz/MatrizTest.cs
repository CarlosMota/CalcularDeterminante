using DeterminanteMatriz;
using System;
using Xunit;

namespace TesteMatriz
{
    public class MatrizTest
    {
        [Fact]
        public void RemoveLinhaEColunaTest()
        {
            var _matriz = new Matriz(new int[,] { { 2, 1, 2 }, { -3, 4, 1 }, { 3, 2, 5 } });
            var _matrizReduzida = _matriz.RemoveLinhaEColuna(_matriz.GetMatrizValue(),2,3);
            Assert.True(_matrizReduzida.GetLength(0) == 2);
        }

        [Fact]
        public void RemoveLinhaEColuna4x4Test()
        {
            var _matriz = new Matriz(new int[,] { { 4, 5, -3, 0 }, { 2, -1, 3, 1 }, { 1, -3, 2, 1 }, { 0, 2, -2, 5 } });
            var _matrizReduzida = _matriz.RemoveLinhaEColuna(_matriz.GetMatrizValue(), 1, 1);
            Assert.True(_matrizReduzida.GetLength(0) == 3);
        }

        [Fact]
        public void CalcularCofator1x1Test()
        {
            var _matriz = new Matriz(new int[,] { { 2, 1, 2 }, { -3, 4, 1 }, { 3, 2, 5 } });
            var _cofator = _matriz.CalcularCofator(1,1, _matriz.GetMatrizValue());
            Assert.True(_cofator == 18);
        }

        [Fact]
        public void CalcularCofator1x2Test()
        {
            var _matriz = new Matriz(new int[,] { { 2, 1, 2 }, { -3, 4, 1 }, { 3, 2, 5 } });
            var _cofator = _matriz.CalcularCofator(1, 2, _matriz.GetMatrizValue());
            Assert.True(_cofator == 18);
        }

        [Fact]
        public void CalcularCofator1x3Test()
        {
            var _matriz = new Matriz(new int[,] { { 2, 1, 2 }, { -3, 4, 1 }, { 3, 2, 5 } });
            var _cofator = _matriz.CalcularCofator(1, 3, _matriz.GetMatrizValue());
            Assert.True(_cofator == -18);
        }

        [Fact]
        public void CalcularDeterminanteLaplace3x3()
        {
            var _matriz = new Matriz(new int[,] { { 2, 1, 2 }, { -3, 4, 1 }, { 3, 2, 5 } });
            var determinante = _matriz.CalcularLaplace3x3(_matriz.GetMatrizValue(),1);
            Assert.True(determinante == 18);
        }

        [Fact]
        public void CalcularDeterminante3x3()
        {
            var _matriz = new Matriz(new int[,] { { 2, 1, 2 }, { -3, 4, 1 }, { 3, 2, 5 } });
            var determinante = _matriz.CalcularDeterminanteNxN(_matriz.GetMatrizValue(), 1);
            Assert.True(determinante == 18);
        }

        [Fact]
        public void CalcularDeterminante4x4()
        {
            var _matriz = new Matriz(new int[,] { { 4, 5, -3, 0 }, { 2, -1, 3, 1 }, { 1, -3, 2, 1 }, { 0, 2, -2, 5 } });
            var determinante = _matriz.CalcularDeterminanteNxN(_matriz.GetMatrizValue(), 1);
            Assert.True(determinante == 210);
        }

        [Fact]
        public void CalcularDeterminane5x5()
        {
            var _matriz = new Matriz(new int[,] { { 1,2,3,-3,1 }, { 0, 4, 0, 0, 0 }, { 0, 1, 0, 1, 1 }, { 0, -6, 6, 1, 3 }, { 0, 2, 0, -1, 1 } });
            var determinante = _matriz.CalcularDeterminanteNxN(_matriz.GetMatrizValue(), 1);
            Assert.True(determinante == -48);
        }

        [Fact]
        public void Print2dTest()
        {
            var _matriz = new Matriz(new int[,] { { 4, 5, -3, 0 }, { 2, -1, 3, 1 }, { 1, -3, 2, 1 }, { 0, 2, -2, 5 } });
            _matriz.print2DMatriz(_matriz.GetMatrizValue());
            Assert.True(true);
        }
    }
}
