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
        private int numLinhas;
        private int numColunas;
        TabuleiroBatalhaNaval tab1 = new TabuleiroBatalhaNaval(10, 10);
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
           this.numLinhas = numLinhas;
           this.numColunas = numColunas;
            
        }


        public void LerArquivo()
        {
            try
            {
                string[] vet;
                string navio;
                int tamanho = 0;
                pontuacao = 0;
               

                //Lê o arquivo e já pega a linha e coluna de cada navio enquanto preenche o tabuleiro.
                StreamReader reader = new StreamReader("C:\\Users\\gusta\\OneDrive\\Área de Trabalho\\frotaComputador.txt", Encoding.UTF8);
                string linha = reader.ReadLine();

                //Loop que lê o arquivo e preenche o tabuleiro
                while (linha != null)
                {
                    vet = linha.Split(';');
                    navio = vet[0]; //Nome dos navios
                    numLinhas = int.Parse(vet[1]); //posição da linha
                    numColunas = int.Parse(vet[2]); //posição da coluna
                    //Pega os dados para a classe Posicao
                    Posicao novaPosicao = new Posicao(numLinhas, numColunas);
                    posicao = novaPosicao;
                    //Pega os dados para a classe Embarcacao
                    if(navio == "Porta-aviões")
                    {
                        tamanho = 5;
                    } else if(navio == "Encouraçado")
                    {
                        tamanho = 4;
                    } else if(navio == "Cruzador")
                    {
                        tamanho = 3;
                    } else if(navio == "Hidroavião")
                    {
                        tamanho = 2;
                    } else if(navio == "Submarino")
                    {
                        tamanho = 1;
                    }
                    Embarcacao embarcacao = new Embarcacao(navio, tamanho);
                    tab1.AdicionarEmbarcacao(embarcacao, posicao);


                    linha = reader.ReadLine();
                }

                reader.Close();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);
            }
        }

        //Imprime o tabuleiro do computador com a posição dos barcos para motivos de teste
        public void ImprimirTabComputador()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write(tab1.Tabuleiro[i, j] + " ");
                } Console.WriteLine();
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
            
            return posicao;

        }

        //Método para levar o tiro
        public bool ReceberAtaque(Posicao posicao)
        {
            // Atualiza o tabuleiro com o tiro recebido
            bool atingiuEmbarcacao = tab1.RecebeuAtaque(posicao);

            // Se alguma embarcação foi atingida, incrementa a pontuação
            if (atingiuEmbarcacao)
            {
                this.pontuacao++;
            }

            return atingiuEmbarcacao;
        }
        


    }
    
} 
            {
                
            }
        }
        

    }
}
