using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendedores
{
    internal class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas = new Venda[31];

        public int Id { get => id; set => id = value; }

        public string Nome { get => nome; set => nome = value; }

        public double PercComissao { get => percComissao; set => percComissao = value; }

        internal Venda[] AsVendas { get => asVendas; }


        public Vendedor(int id, string nome,double percComissao)
        {
            this.Id = id;
            this.Nome = nome;
            this.PercComissao = percComissao;

        }

        public void registrarVenda(int dia, Venda venda)
        {
            this.asVendas[dia - 1] = venda;
        }

        public double valorMedioVendas()
        {
            double total = 0;
            int dias = 0;

            foreach (Venda venda in asVendas)
            {
                if (venda != null)
                {
                    total += venda.valorMedio();
                    dias++;
                }
            }

            if (dias == 0)
            {
                return 0;
            }

            return total / dias;
        }


        public double valorVendas()
        {
            return this.asVendas.Sum(v => v != null ? v.Valor : 0); 
        }
        public double valorComissao()
        {
            return this.valorVendas() * (this.PercComissao / 100);
        }

    }
}
