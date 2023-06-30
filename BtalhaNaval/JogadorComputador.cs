using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

 namespace BatalhaNaval
{
    class JogadorComputador
    {
        private TabuleiroBatalhaNaval tabuleiro;
        private int pontuacao;
        private Posicao posicao;
        private Posicao[] posTirosDados;
        Random rdn = new Random();

        public int Pontuacao
        {
            get { return pontuacao; }
            set { pontuacao = value; }
        }

         public TabuleiroBatalhaNaval Tabuleiro 
         {
            get {return tabuleiro;}
            set {tabuleiro = value;}         
         }

        //Construtor da classe

       public JogadorComputador(int numLinhas, int numColunas)
        {
            try
            {
                string[] vet = new string[3];
                int lin, col;
                string navio;
                pontuacao = 0;

                //Lê o arquivo e já pega a linha e coluna de cada navio enquanto preenche o tabuleiro.
                StreamReader reader = new StreamReader("C:\\Users\\gusta\\OneDrive\\Área de Trabalho\\arquivo.txt", Encoding.UTF8);
                string linha = reader.ReadLine();
                while (linha != null)
                {
                    vet = linha.Split(';');
                    navio = vet[0]; //Nome dos navios
                    tabuleiro.NumLinhas = int.Parse(vet[1]); //posição da linha
                    tabuleiro.NumColunas = int.Parse(vet[2]); //posição da coluna
                    Posicao novaPosicao = new Posicao(tabuleiro.NumLinhas, tabuleiro.NumColunas);
                    posicao = novaPosicao;
                    linha = reader.ReadLine();
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);
            }
            
        }

        //Método para gerar uma posição aleatória
        public Posicao PosiAleatoria(Random random)
        {
            int linha = rdn.Next(0, 10);
            int col = rdn.Next(0, 10);
            return new Posicao(linha, col);
        }

        //Método para checar se a posição já foi usada ou não
        public bool PosiInvalida(Posicao posicao)
        {
            foreach(Posicao pos in posTirosDados) { 
                if (pos.Linha == posicao.Linha && pos.Coluna == posicao.Coluna)
                {
                    return true;
                }
            }
            return false;
        } 


        //Método para efetuar o tiro

        public Posicao EscolherAtaque()
        {
            Random random = new Random();
            Posicao posicao = PosiAleatoria(random);
            int contPosicao = 0;
            //Checa se já usou aquela posição antes
            while(PosiInvalida(posicao))
            {
                posicao = PosiAleatoria(random);
            }
            //Caso a posição não seja repetida, adiciona aquela posição nova ao vetor posTirosDados
            while(contPosicao <= 100)
            {
                posTirosDados[contPosicao] = posicao;
            }
            contPosicao++;
            pontuacao++;
            return posicao;

        }

        //Método para levar o tiro
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
