using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using BatalhaNaval;

namespace BatalhaNaval1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            TabuleiroBatalhaNaval teste = new TabuleiroBatalhaNaval(10,10);

            char[,] a = new char[10, 10];

            teste.imprimirTabuleiroJogador(a);

            

            Console.ReadLine();


        }
    }
}