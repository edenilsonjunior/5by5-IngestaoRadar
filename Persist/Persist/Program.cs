namespace Persist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            


            Console.Clear();
            Console.WriteLine("=====|Gravar dados no SQL SERVER|=====");
            Console.WriteLine("1- Carregar os dados do JSON");
            Console.WriteLine("2 Inserir os dados no SQL SERVER");
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
                    
                    break;
                case 2:
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }








            // Leitura dos dados JSON
            // Ingestao no sql server

        }



    }
}
