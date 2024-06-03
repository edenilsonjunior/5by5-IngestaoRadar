using Controllers;
using Repositories;
using Models;
using System.Collections.Generic;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            var mongo = new MongoRepository();
            var sql = new SqlRepository();

            while (!exit)
            {
                switch (ChooseDatabase())
                {
                    case 1:
                        GenerateCsv(mongo);
                        Console.WriteLine("Pressione qualquer tecla para ir para o proximo relatorio...");
                        Console.ReadLine();

                        GenerateJson(mongo);
                        Console.WriteLine("Pressione qualquer tecla para ir para o proximo relatorio...");
                        Console.ReadLine();

                        GenerateXml(mongo);
                        break;
                    case 2:
                        GenerateCsv(sql);
                        Console.WriteLine("Pressione qualquer tecla para ir para o proximo relatorio...");
                        Console.ReadLine();

                        GenerateJson(sql);
                        Console.WriteLine("Pressione qualquer tecla para ir para o proximo relatorio...");
                        Console.ReadLine();

                        GenerateXml(sql);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcao invalida!");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
        }


        static void GenerateCsv(IDatabaseRepository repository)
        {
            var list = new ReadController(repository).LoadData();
            Console.WriteLine(new FileGeneratorController().GenerateCsv(list));
        }

        static void GenerateJson(IDatabaseRepository repository)
        {
            var list = new ReadController(repository).LoadData();
            Console.WriteLine(new FileGeneratorController().GenerateJson(list));
        }

        static void GenerateXml(IDatabaseRepository repository)
        {
            var list = new ReadController(repository).LoadData();
            Console.WriteLine(new FileGeneratorController().GenerateXml(list));
        }


        static int ChooseRecordType()
        {
            Console.Clear();
            Console.WriteLine("=====|Gerar relatorios|=====");
            Console.WriteLine("1- Gerar relatorio CSV");
            Console.WriteLine("2- Gerar relatorio JSON");
            Console.WriteLine("3- Gerar relatorio XML");
            Console.WriteLine("0- Sair");
            Console.WriteLine("======================================");
            Console.Write("R: ");

            return ReadInt();
        }

        static int ChooseDatabase()
        {
            Console.Clear();
            Console.WriteLine("=====|Gerar relatorios|=====");
            Console.WriteLine("1- Gerar relatorios atraves do Mongo");
            Console.WriteLine("2- Gerar relatorios atraves do SQL SERVER");
            Console.WriteLine("0- Sair");
            Console.WriteLine(@"OBS: Após a inserção, os dados gerados podem ser encontrados em: 'C:\Radar'");
            Console.WriteLine("======================================");
            Console.Write("R: ");

            return ReadInt();
        }

        static int ReadInt()
        {
            int option;

            while (int.TryParse(Console.ReadLine(), out option) == false)
            {
                Console.WriteLine("Voce deve digitar um numero!");
                Console.Write("Tente novamente: ");
            }
            return option;
        }
    }
}
