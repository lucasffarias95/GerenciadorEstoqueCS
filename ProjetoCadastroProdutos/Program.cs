using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjetoCadastroProdutos
{
    //Criaçao de uma classe simples para representar o PRODUTO
    class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public double ValorTotalEmEstoque()
        {
            return Preco * Quantidade;
        }

        public override string ToString()
        {
            return $"{Nome.PadRight(15)} | Preço: R$ {Preco.ToString("F2")} | Quantidade: {Quantidade.ToString().PadRight(5)} | Total: R$ {ValorTotalEmEstoque().ToString("F2")}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
            // Lista para armazenar todos os produtos que forem cadastrados
            List<Produto> listaDeProdutos = new List<Produto>();

            string continuarSistema = "s";

            while (continuarSistema.ToLower() == "s")
            {
                Console.Clear();
                Console.WriteLine("--- NOVO CADASTRO DE PRODUTO ---");

                Produto p = new Produto(); // Criamos um novo objeto produto

                Console.Write("Nome: ");
                p.Nome = Console.ReadLine();
                Console.Write("Preço unitário: ");
                p.Preco = double.Parse(Console.ReadLine(), CI);
                Console.Write("Quantidade inicial: ");
                p.Quantidade = int.Parse(Console.ReadLine());

                // Adicionamos o produto na nossa lista "memória"
                listaDeProdutos.Add(p);

                int opcaoMenu = 0;
                while (opcaoMenu != 4)
                {
                    Console.WriteLine($"\nGERENCIANDO: {p.Nome.ToUpper()}");
                    Console.WriteLine("1 - Adicionar | 2 - Remover | 3 - Ver Este Item | 4 - Finalizar Item");
                    Console.Write("Opção: ");
                    opcaoMenu = int.Parse(Console.ReadLine());

                    if (opcaoMenu == 1)
                    {
                        Console.Write("Quantidade a adicionar: ");
                        p.Quantidade += int.Parse(Console.ReadLine());
                    }
                    else if (opcaoMenu == 2)
                    {
                        Console.Write("Quantidade a remover: ");
                        int qte = int.Parse(Console.ReadLine());
                        if (qte <= p.Quantidade) p.Quantidade -= qte;
                        else Console.WriteLine("Saldo insuficiente!");
                    }
                    else if (opcaoMenu == 3)
                    {
                        Console.WriteLine(p);
                    }
                }

                Console.Write("\nDeseja cadastrar outro produto? (s/n): ");
                continuarSistema = Console.ReadLine();
            }

            // --- RELATÓRIO FINAL ---
            Console.Clear();
            Console.WriteLine("======= RELATÓRIO GERAL DE ESTOQUE =======");
            double totalGeral = 0;

            foreach (Produto item in listaDeProdutos)
            {
                Console.WriteLine(item);
                totalGeral += item.ValorTotalEmEstoque();
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"VALOR TOTAL PATRIMONIAL: R$ {totalGeral.ToString("F2", CI)}");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}