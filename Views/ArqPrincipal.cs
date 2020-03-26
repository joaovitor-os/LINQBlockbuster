using System;
using View;

namespace LINQBLOCKBUSTER
{
    class ArqPrincipal
    {
        /*
            The Main class
            The entrance of the system
        */
        static void Main (string[] args) {
            Console.WriteLine ("============ Blockbuster! ============ ");
            int opt = 0;
            do {
                // Show menu options
                Console.WriteLine ("+-------------------------+");
                Console.WriteLine ("| Digite a opção desejada      |");
                Console.WriteLine ("|  1 - Cadastrar Cliente       |");
                Console.WriteLine ("|  2 - Cadastrar Filme         |");
                Console.WriteLine ("|  3 - Cadastrar Locação       |");
                Console.WriteLine ("|  4 - Listar Clientes         |");
                Console.WriteLine ("|  5 - Consultar Cliente       |");
                Console.WriteLine ("|  6 - Consultar Cliente LINQ  |");
                Console.WriteLine ("|  7 - Listar Filmes           |");
                Console.WriteLine ("|  8 - Consultar Filme         |");
                Console.WriteLine ("|  9 - Consultar Filme LINQ    |");
                Console.WriteLine ("| 10 - Consultar Locação       |");
                Console.WriteLine ("| 11 - Consultar Locação LINQ  |");
                Console.WriteLine ("| 12 - Importar Dados          |");
                Console.WriteLine ("|  0 - Sair                    |");
                Console.WriteLine ("+-------------------------+");

                try {
                    opt = Convert.ToInt32 (Console.ReadLine ());
                } catch {
                    Console.WriteLine ("Opção inválida");
                    opt = 99;
                }

                // Checks the selected option
                switch (opt) {
                    case 1:
                        ClienteView.InserirCliente ();
                        break;
                    case 2:
                        FilmeView.InserirFilme ();
                        break;
                    case 3:
                        LocacaoView.InserirLocacao ();
                        break;
                    case 4:
                        ClienteView.ListarClientes ();
                        break;
                    case 5:
                        ClienteView.ConsultarCliente ();
                        break;
                    case 6:
                        ClienteView.ConsultarClienteLINQ ();
                        break;
                    case 7:
                        FilmeView.ListarFilmes ();
                        break;
                    case 8:
                        FilmeView.ConsultarFilme ();
                        break;
                    case 9:
                        FilmeView.ConsultarFilmeLINQ ();
                        break;
                    case 10:
                        LocacaoView.ConsultarLocacao ();
                        break;
                    case 11:
                        LocacaoView.ConsultarLocacoesClienteLINQ ();
                        break;
                    case 12:
                        FilmeView.Importar();
                        ClienteView.Importar();
                        break;
                }
            } while (opt != 0);

        }
    }
}