using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendedores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha;
            bool sair = false;
            Vendedores meusVendedores = new Vendedores(10);

            while (sair == false)
            {
                Console.WriteLine("Bem-vindo ao sistema de gerenciamento de vendedores!");

                Console.WriteLine("O que deseja fazer: ");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Cadastrar vendedor");
                Console.WriteLine("2 - Consultar  vendedor");
                Console.WriteLine("3 - Excluir vendedor");
                Console.WriteLine("4 - Registrar vendas");
                Console.WriteLine("5 - Listar vendedores");


                switch (escolha = int.Parse(Console.ReadLine()))
                {
                    case 0:
                        {
                            Console.WriteLine("Saindo do sistema...");
                            sair = true;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("Digite o ID do vendedor: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o nome do vendedor: ");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Digite o percentual de comissão:");
                            double percComissao = double.Parse(Console.ReadLine());
                            Vendedor novoVendedor = new Vendedor(id, nome, percComissao);
                            if (meusVendedores.addVendedor(novoVendedor))
                            {
                                Console.WriteLine("Vendedor adicionado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível adicionar o vendedor. Limite atingido.");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Digite o ID do vendedor: ");
                            int id = int.Parse(Console.ReadLine());
                            Vendedor procurar = new Vendedor(id, " ", 0);
                            Vendedor vendedorEncontrado = meusVendedores.searchVendedor(procurar);
                            Console.WriteLine();
                            if (vendedorEncontrado != null)
                            {
                                Console.WriteLine("Vendedor encontrado:");
                                Console.WriteLine($"Id: {vendedorEncontrado.Id}");
                                Console.WriteLine($"Nome: {vendedorEncontrado.Nome}");
                                Console.WriteLine($"Valor total das vendas: R$ {vendedorEncontrado.valorVendas():F2}");
                                Console.WriteLine($"Valor da comissão: R$ {vendedorEncontrado.valorComissao():F2}");
                                Console.WriteLine($"Valor médio das vendas diárias: R$ {vendedorEncontrado.valorMedioVendas():F2}");

                            }
                            else
                            {
                                Console.WriteLine("Vendedor não encontrado.");
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Digite o ID do vendedor: ");
                            int id = int.Parse(Console.ReadLine());
                            Vendedor procurar = new Vendedor(id, " ", 0);
                            bool achou = meusVendedores.delVendedor(procurar);
                            if (achou)
                            {
                                Console.WriteLine("Vendedor excluído com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível excluir o vendedor. Ele pode ter vendas registradas ou não existir.");
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Digite o ID do vendedor: ");
                            int id = int.Parse(Console.ReadLine());
                            Vendedor procurar = new Vendedor(id, " ", 0);
                            Vendedor vendedorEncontrado = meusVendedores.searchVendedor(procurar);
                            if (vendedorEncontrado != null)
                            {
                                Console.WriteLine("Digite o dia da venda: ");
                                int dia = int.Parse(Console.ReadLine());
                                Console.WriteLine("Digite a quantidade de vendas: ");
                                int quantidade = int.Parse(Console.ReadLine());
                                Console.WriteLine("Digite o valora total: ");
                                double valor = double.Parse(Console.ReadLine());
                                Venda novaVenda = new Venda(quantidade, valor);
                                vendedorEncontrado.registrarVenda(dia, novaVenda);
                            }
                            else
                            {
                                Console.WriteLine("Vendedor não encontrado para registrar venda.");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Lista de vendedores:");
                        foreach (Vendedor v in meusVendedores.OsVendedores)
                        {
                            if (v != null)
                            {
                                Console.WriteLine($"Id: {v.Id}");
                                Console.WriteLine($"Nome: {v.Nome}");
                                Console.WriteLine($"Total das vendas: R$ {v.valorVendas():F2}");
                                Console.WriteLine($"Valor da comissão: R$ {v.valorComissao():F2}");
                            Console.WriteLine();
                            }
                        }
                        Console.WriteLine("Resumo geral:");
                        Console.WriteLine($"Total das vendas: {meusVendedores.valorVendas():F2}");
                        Console.WriteLine($"Total das comissões: {meusVendedores.valorComissao():F2}");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
