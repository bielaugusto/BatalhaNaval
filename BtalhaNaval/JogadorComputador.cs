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
                    navio = vet[0];
                    lin = int.Parse(vet[1]);
                    col = int.Parse(vet[2]);
                    //Falta adicionar lin e col para o tabuleiro do computador
                    linha = reader.ReadLine();
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex}");
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
        public bool PosiValida(Posicao posicao)
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

        public Posicao EscolherAtaqueComputador()
        {
            Random random = new Random();
            Posicao posicao = PosiAleatoria(random);
            while(PosiValida(posicao))
            {
                posicao = PosiAleatoria(random);
            }
            //Falta colocar posicao na array posTirosDados
            return posicao;

        }

        //Método para levar o tiro
        public bool ReceberAtaqueComputador(Posicao posicao)
        {
            for(int i = 0; i < tabuleiro.NumLinhas; i++)
            {
                for(int j = 0; j < tabuleiro.NumColunas; j++)
                {
                    if (tabuleiro[i, j] != 'A')
                    {
                        //Falta atualizar o tabuleiro e colocar a Array correta.
                        return true;
                    }
                }
            } return false;
        }
        


    }
    
} 