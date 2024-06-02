using Models;
using Controllers;

namespace ReadAndPersist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            var list = new List<Radar>();
            bool dadosCarregadosSQL = false;
            bool dadosInseridosMongo = false;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=====|Recuperar dados do SQL e inserir no Mongo|=====");
                Console.WriteLine("1- Carregar os dados do SQL");
                Console.WriteLine("2- Inserir os dados no Mongo");
                Console.WriteLine("0- Sair");
                Console.WriteLine("======================================");
                Console.Write("R: ");

                while (int.TryParse(Console.ReadLine(), out opcao) == false)
                {
                    Console.WriteLine("Voce deve digitar um numero!");
                    Console.Write("Tente novamente: ");
                }

                switch (opcao)
                {
                    case 1:
                        if (dadosCarregadosSQL)
                            Console.WriteLine("Os dados ja foram carregados!");
                        else
                        {
                            Console.WriteLine("Carregando os dados...");
                            list = new ReadAndPersistController().LoadData();

                            if (list == null)
                            {
                                Console.WriteLine("Nao foi possivel carregar os dados!");
                                list = new();
                            }
                            else
                            {
                                Console.WriteLine("***Dados carregados com sucesso!***");
                                dadosCarregadosSQL = true;

                                foreach (var item in list)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                        }

                        break;
                    case 2:
                        if (!dadosCarregadosSQL)
                            Console.WriteLine("Os dados ainda nao foram carregados! Nao foi possivel inserir.");
                        else
                        {
                            if (dadosInseridosMongo)
                                Console.WriteLine("Os dados ja foram inseridos!");
                            else
                            {
                                Console.WriteLine("Inserindo os dados...");
                                dadosInseridosMongo = new ReadAndPersistController().InsertData(list);
                                Console.WriteLine(dadosInseridosMongo ? "Dados inseridos no bancos!" : "Nao foi possivel inserir os dados!");
                            }
                        }
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        exit = true;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }

        }
    }

}
