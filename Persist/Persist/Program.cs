using Controllers;
using Models;

namespace Persist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            var list = new List<Radar>();
            bool dadosCarregados = false;
            bool dadosInseridos = false;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=====|Gravar dados no SQL SERVER|=====");
                Console.WriteLine("1- Carregar os dados do JSON");
                Console.WriteLine("2- Inserir os dados no SQL SERVER");
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
                        if (dadosCarregados)
                            Console.WriteLine("Os dados ja foram carregados!");
                        else
                        {
                            Console.WriteLine("Carregando os dados...");
                            list = new PersistController().LoadData();

                            if (list == null)
                            {
                                Console.WriteLine("Nao foi possivel carregar os dados!");
                                list = new();
                            }
                            else
                            {
                                Console.WriteLine("***Dados carregados com sucesso!***");
                                dadosCarregados = true;
                            }
                        }

                        break;
                    case 2:
                        if (!dadosCarregados)
                            Console.WriteLine("Os dados ainda nao foram carregados! Nao foi possivel inserir.");
                        else
                        {
                            if (dadosInseridos)
                                Console.WriteLine("Os dados ja foram inseridos!");
                            else
                            {
                                Console.WriteLine("Inserindo os dados...");
                                dadosInseridos = new PersistController().Insert(list);
                                Console.WriteLine(dadosInseridos ? "Dados inseridos no bancos!" : "Nao foi possivel inserir os dados!");
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
