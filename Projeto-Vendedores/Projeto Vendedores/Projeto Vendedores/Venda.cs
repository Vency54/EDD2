using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendedores
{
    internal class Venda
    {
        private int qtde;
        private double valor;

        public Venda(int qtde, double valor)
        {
            this.qtde = qtde;
            this.valor = valor;
        }

        public double valorMedio()
        {
            if(qtde == 0)
            {
                return 0;
            }

            return valor / qtde;
        }

        public int QTDE { get => qtde; set => qtde = value; }
        public double Valor { get => valor; set => valor = value; }
    }
}
