using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval
{
    class Posicao
    {
        private int linha, coluna;

        public int Linha
        {
            get { return linha; }
            set { linha = value; }
        }

        public int Coluna
        {
            get { return coluna; }
            set { linha = value; }
        }

        public Posicao(int linha, int coluna) {
            this.coluna = coluna;
            this.linha = linha;

        }
    }
}
