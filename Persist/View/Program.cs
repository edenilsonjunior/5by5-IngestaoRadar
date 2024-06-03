using Models;
using Controllers;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Radar>();
            bool load = false;
            bool insert = false;
            bool exit = false;

            while (!exit)
            {
                switch (Menu())
                {
                    case 1:
                        if (load)
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
                                load = true;
                            }
                        }

                        break;
                    case 2:
                        if (!load)
                            Console.WriteLine("Os dados ainda nao foram carregados! Nao foi possivel inserir.");
                        else if (insert)
                            Console.WriteLine("Os dados ja foram inseridos!");
                        else
                        {
                            Console.WriteLine("Inserindo os dados...");
                            insert = new PersistController().Insert(list);
                            Console.WriteLine(insert ? "Dados inseridos no banco!" : "Nao foi possivel inserir os dados!");
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



        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("=====|Gravar dados no SQL SERVER|=====");
            Console.WriteLine("1- Carregar os dados do JSON");
            Console.WriteLine("2- Inserir os dados no SQL SERVER");
            Console.WriteLine("0- Sair");
            Console.WriteLine("======================================");
            Console.Write("R: ");

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
