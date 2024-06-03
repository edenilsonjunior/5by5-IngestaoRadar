using Controllers;
using Repositories;
using Models;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new ReadController(new MongoRepository()).LoadData();

            Console.WriteLine(new FileGeneratorController().GenerateCsv(list));
            Console.WriteLine(new FileGeneratorController().GenerateJson(list));
            Console.WriteLine(new FileGeneratorController().GenerateXml(list));


            bool exit = false;

            var list = new List<Radar>();

            while (!exit)
            {
                switch (ChooseRecordType())
                {
                    case 1:
                        GenerateCsv();
                        break;
                    case 2:
                        GenerateJson();
                        break;
                    case 3:
                        GenerateXml();
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
            Console.WriteLine("1- Carregar os dados do JSON");
            Console.WriteLine("2- Carregar os dados do SQL SERVER");
            Console.WriteLine("0- Sair");
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
