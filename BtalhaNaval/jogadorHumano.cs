using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtalhaNaval
{
    internal class JogadorHumano
    {
        //tabuleiro
        private TabuleiroBatalhaNaval tabuleiro;

        //pontuacao do jogador computador
        private int pontuacao;

        //posiçoes dos tiros já dados
        private Posicao[] posTirosDados;

        private int contadorDeTiros;

        //escolher local dos tiros
        private Posicao EscolherAtaque()
        {
            int contador = 0;

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
                    if (posTirosDados[i].Linha == linha && posTirosDados[i].Coluna == coluna && linha < 0 && coluna < 0 && linha >= tabuleiro.numLinhas)
                    {
                        condicao = true;
                        Console.WriteLine("Posição invalida!");
                        break;
                    }
                }

            } while (condicao);

            Posicao teste = new Posicao(linha, coluna);

            posTirosDados[contadorDeTiros] = teste;

            contadorDeTiros++;

            return this.posTirosDados[contadorDeTiros - 1];
        }

        public JogadorHumano(int linha, int coluna)
        {
            posTirosDados = new Posicao[100];

            tabuleiro = new TabuleiroBatalhaNaval(linha, coluna);

            this.pontuacao = 0;

            this.contadorDeTiros = 0;
        }
    }
}
