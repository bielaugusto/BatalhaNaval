using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BatalhaNaval
{
    class Embarcacao
    {
        private string nome;
        private int tamanho;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }
           
        
        //construtor da classe Embarcacao
        public Embarcacao(string nome, int tamanho)
        {
            this.nome = nome;
            this.tamanho = tamanho;
        }


    }
}
