using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePOO
{
    public class Corrente : IConta
    {
        public Cliente Cliente { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; set; }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente.");
            }
            else
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado com sucesso.");
            }
        }
    }
}
