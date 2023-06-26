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

        //Função para zerar o tabuleiro e settar como padrão 'A' para todas as posições
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

        //Funções para imprimir os tabuleiros para os jogadores
        public char[,] imprimirTabuleiroJogador(char[,] tabuleiro) {
            for (int i = 0; i <= tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j <= tabuleiro.GetLength(1); j++)
                {
                    Console.WriteLine(tabuleiro[i, j]);
                }
            }Console.WriteLine(" ");
            return tabuleiro;
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
            return tabuleiro;
        }

        public bool AdicionarEmbarcacao(Embarcacao embarcacao, Posicao posicao)
        {
            // Verifica se a embarcação ultrapassa as dimensões do tabuleiro
            if (posicao.Linha + embarcacao.Tamanho > numLinhas || posicao.Coluna + embarcacao.Tamanho > numColunas)
                return false;

            // Verifica se as posições onde a embarcação será adicionada já estão ocupadas
            for (int i = 0; i < embarcacao.Tamanho; i++)
            {
                if (tabuleiro[posicao.Linha, posicao.Coluna + i] != 'A')
                    return false;
            }

            // Adiciona a embarcação no tabuleiro
            for (int i = 0; i < embarcacao.Tamanho; i++)
            {
                tabuleiro[posicao.Linha, posicao.Coluna + i] = 'B'; // 'B' representa barco
            }

            return true;
        }
    }
}
