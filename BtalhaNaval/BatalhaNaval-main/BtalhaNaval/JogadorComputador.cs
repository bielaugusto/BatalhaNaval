using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace BatalhaNaval
{
    class JogadorComputador
    {
        char[,] computador = new char[10, 10];

        public void leitorArquivo()
        {
            StreamReader str = new StreamReader("C:\\Users\\gusta\\OneDrive\\Documentos\\Coding\\C#\\lista1\\BatalhaNaval\\BatalhaNaval\\frotaComputador", Encoding.UTF8);
            string linha = str.ReadLine();
        }


        //método para criar a matriz do computador

        public void matrizComputador()
        {
            for (int i = 0; i < computador.Length; i++) 
            {
                
            }
        }
        

    }
}
