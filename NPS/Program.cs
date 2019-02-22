using System;
using System.Globalization;

namespace NPS
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 1;
            while (opcao != 0)
            {
                try
                {
                    // Menu interativo
                    Console.Clear();
                    Console.WriteLine("0 - Sair");
                    Console.WriteLine("1 - Saber tamanho mínimo da amostra e quantidade mínima de disparos");
                    Console.WriteLine("2 - Indicadores sobre NPS");
                    Console.Write("Escolha uma opção: ");
                    opcao = int.Parse(Console.ReadLine());

                    if (opcao == 1)
                    {
                        // Entrada de dados: total de clientes
                        Console.Write("Total de clientes: ");
                        int total = int.Parse(Console.ReadLine());
                        
                        // Saída de dados
                        Console.Clear();
                        Console.WriteLine("Você precisará de uma amostra de " + Funcoes.Amostra(total).ToString() + " clientes");
                        Console.WriteLine("Também precisará de uma quantidade mínima de : " + Funcoes.Disparos(Funcoes.Amostra(total)).ToString() + " disparos");
                        Console.WriteLine();

                        Console.WriteLine("Digite qualquer tecla para voltar");
                        Console.ReadLine();
                    }
                    else if (opcao == 2)
                    {
                        // Entrada de dados: detratores, passivos ou neutros e promotores
                        Console.Write("Detratores: ");
                        int det = int.Parse(Console.ReadLine());
                        Console.Write("Neutros: ");
                        int neut = int.Parse(Console.ReadLine());
                        Console.Write("Promotores: ");
                        int prom = int.Parse(Console.ReadLine());

                        // Saída de dados
                        Console.Clear();
                        Console.WriteLine("NPS: " + Funcoes.NPS(det, neut, prom).ToString());
                        Console.WriteLine("Variância: " + Funcoes.VarNPS(det, neut, prom).ToString("F2"));
                        Console.WriteLine(Funcoes.IntervaloConfianca(det, neut, prom));

                        Console.WriteLine();
                        Console.WriteLine("Digite qualquer tecla para voltar");
                        Console.ReadLine();
                    }
                    else if (opcao == 0)
                    {
                        Console.WriteLine("Fim do programa");
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro inesperado: " + e.Message);
                }
              
            }
            
            Console.ReadKey();
        }
    }
}
