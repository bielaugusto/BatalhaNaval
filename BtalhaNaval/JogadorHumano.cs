using BatalhaNaval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval
{
    class JogadorHumano
    {
        private TabuleiroBatalhaNaval tabuleiro;
        private int pontuacao;
        private Posicao[] posTirosDados;
        private int contadorDeTiros = 0;

        public JogadorHumano(int numLinhas, int numColunas)
        {
            posTirosDados = new Posicao[100];
            tabuleiro = new TabuleiroBatalhaNaval(numLinhas, numColunas);
            pontuacao = 0;

            //this.contadorDeTiros = 0;
        }

        //escolher local dos tiros
        private Posicao EscolherAtaque()
        {
            //int contador = 0;
            bool condicao = false;
            int linha, coluna;

            do
            {
                condicao = false;

                Console.WriteLine("Coloque a posicao da linha");
                linha = int.Parse(Console.ReadLine());
                Console.WriteLine("Coloque a Coluna");
                coluna = int.Parse(Console.ReadLine());

                for (int i = 0; i < contadorDeTiros; i++)
                {
                    if (posTirosDados[i].Linha == linha && posTirosDados[i].Coluna == coluna)
                    {
                        condicao = true;
                        Console.WriteLine("Posição já utilizada anteriomente!");
                        break;
                    }

                    if (linha < 0 && linha >= tabuleiro.NumLinhas && coluna < 0 && coluna >= tabuleiro.NumColunas)
                    {
                        condicao = true;
                        Console.WriteLine("Posição invalida!");
                        break;
                    }
                }

            } while (condicao);

            Posicao posicao = new Posicao(linha, coluna);
            posTirosDados[contadorDeTiros] = posicao;

            contadorDeTiros++;
            return this.posTirosDados[contadorDeTiros - 1];
        }

        public bool ReceberAtaque(Posicao posicao)
        {
            // Atualiza o tabuleiro com o tiro recebido
            bool atingiuEmbarcacao = tabuleiro.RecebeuAtaque(posicao);

            // Se alguma embarcação foi atingida, incrementa a pontuação
            if (atingiuEmbarcacao)
            {
                pontuacao++;
            }

            return atingiuEmbarcacao;
        }

    }
}
