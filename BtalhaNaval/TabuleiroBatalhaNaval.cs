using System;
using System.Collections.Generic;
using System.Text;

namespace BatalhaNaval
{
    class TabuleiroBatalhaNaval
    {
        private int numLinhas;
        private int numColunas;
        private char[,] tabuleiro;
        private void zeraMatriz(char[,] tabuleiro) {
            for (int i = 0; i <= tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j <= tabuleiro.GetLength(1); j++)
                {
                    tabuleiro[i, j] = 'A';
                }
            }
        }


        public TabuleiroBatalhaNaval(int numLinhas, int numColunas)
        {
            this.numLinhas = numLinhas;
            this.numColunas = numColunas;
            tabuleiro = new char[numLinhas, numColunas];

            zeraMatriz(tabuleiro);
        }

        public int NumLinhas {
            get { return numLinhas; }
            set { numLinhas = value; }
        }
        public int NumColunas { 
            get { return numColunas; }
            set { numColunas = value; }
        }

        public char[,] imprimirTabuleiroJogador(char[,] tabuleiro) {
            for (int i = 0; i <= tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j <= tabuleiro.GetLength(1); j++)
                {
                    Console.WriteLine(tabuleiro[i, j]);
                }
            }Console.WriteLine(" ");
        }

        public char[,] imprimirTabuleiroAdversario(char[,] tabuleiro)
        {
            for (int i = 0; i <= tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j <= tabuleiro.GetLength(1); j++)
                {
                    Console.WriteLine(tabuleiro[i, j]);
                }
            }
        }
    }
}
