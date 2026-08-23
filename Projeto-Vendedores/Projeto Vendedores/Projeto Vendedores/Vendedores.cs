using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendedores
{
    internal class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public int Max { get => max; }
        public int Qtde { get => qtde; }
        internal Vendedor[] OsVendedores { get => osVendedores; }

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
        }


        public bool addVendedor(Vendedor v)
        {
            if (this.qtde < this.max && searchVendedor(v) == null)
            {
                this.osVendedores[this.qtde++] = v;
                return true;
            }
            return false;
        }


        public bool delVendedor(Vendedor v)
        {
            for (int i = 0; i < qtde; i++)
            {
                Vendedor vend = this.osVendedores[i];

                if (vend.Id == v.Id)
                {
                    if (!vend.AsVendas.Any(v => v != null))
                    {
                        for (int j = i; j < qtde - 1; j++)
                        {
                            this.osVendedores[j] = this.osVendedores[j + 1];
                        }

                        this.osVendedores[qtde - 1] = null;
                        qtde--;

                        return true;
                    }
                }
            }

            return false;

        }
        public Vendedor searchVendedor(Vendedor v)
        {
            for (int i = 0; i < this.qtde; i++)
            {
                if (this.osVendedores[i].Id == v.Id)
                {
                    return this.osVendedores[i];
                }
            }

            return null;
        }

        public double valorVendas()
        {
            double totalVendas = 0;
            foreach (Vendedor v in this.osVendedores)
            {
                if (v != null)
                {
                    totalVendas += v.valorVendas();
                }
            }
            return totalVendas;
        }

        public double valorComissao()
        {
            double totalComissao = 0;
            foreach (Vendedor v in this.osVendedores)
            {
                if (v != null)
                {
                    totalComissao += v.valorComissao();
                }
            }
            return totalComissao;
        }

    }
}
