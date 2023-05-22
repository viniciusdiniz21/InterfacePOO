using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePOO
{
    interface IConta
    {
        public Cliente Cliente { get; set; }
        public int Numero { get; set; } 
        public double Saldo { get; set; }
        void Sacar(double valor);
        void Depositar(double valor);
    }
}
