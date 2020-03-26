using System;
using Models;
using Controllers;
using System.Collections;
using System.Linq;

namespace View {
    public class LocacaoView {
         /// <summary>
        /// This method is responsible for creating the rents
        /// </summary>
        public static void InserirLocacao () {
            Console.WriteLine ("Informações sobre a locação: ");
            Cliente cliente;
            Filme filme;

            // Search the costumer with id
            do {
                Console.WriteLine ("Informe o id do cliente: ");
                int idCliente = Convert.ToInt32 (Console.ReadLine ());
                cliente = null; // Reset the value to avoid garbage

                // Try to locate the information in the collection
                try {
                    cliente = ClienteController.GetCliente(idCliente);
                    if (cliente == null) { // If the information is not present, a message is returned
                        Console.WriteLine ("Cliente não localizado, favor digitar outro id.");
                    }
                } catch {
                    Console.WriteLine ("Cliente não localizado, favor digitar outro id.");
                }

            } while (cliente == null);

            // Insert the rent to the costumer
            Locacao locacao = LocacaoController.InserirLocacao(cliente);

            // Search the movie with id
            int filmOpt = 0;
            do {
                Console.WriteLine ("Informe o id do filme alugado: ");
                int idFilme = Convert.ToInt32 (Console.ReadLine ());
                filme = null; // Reset the value to avoid garbage

                // Try to locate the information in the collection
                try {
                    filme = FilmeController.GetFilme(idFilme);
                    if (filme == null) { // If the information is not present, a message is returned
                        Console.WriteLine ("Filme não localizado, favor digitar outro id.");
                    }
                } catch {
                    Console.WriteLine ("Filme não localizado, favor digitar outro id.");
                }

                if (filme != null) {
                    // Insert the movie on the rent
                    LocacaoController.InserirFilme (locacao, filme);
                    Console.WriteLine ("Deseja informar outro filme? " +
                        "Informar 1 para Não ou qualquer outro valor para Sim.");
                    filmOpt = Convert.ToInt32 (Console.ReadLine ());
                }
            } while (filmOpt != 1);
        }

        /// <summary>
        /// This method is responsible for consulting a rent
        /// </summary>
        public static void ConsultarLocacao () {
            Locacao locacao;

            // Search the rent with id
            do {
                Console.WriteLine ("Informe a locacao que deseja consultar: ");
                int idLocacao = Convert.ToInt32 (Console.ReadLine ());
                locacao = null; // Reset the value to avoid garbage

                // Try to locate the information in the collection
                try {
                    locacao = LocacaoController.GetLocacao(idLocacao);
                    if (locacao == null) { // If the information is not present, a message is returned
                        Console.WriteLine ("Locação não localizada, favor digitar outro id.");
                    }
                } catch {
                    Console.WriteLine ("Locação não localizada, favor digitar outro id.");
                }
            } while (locacao == null);
            Console.WriteLine (locacao.ToString ());
        }

        public static void ConsultarLocacoesClienteLINQ(){
            Console.WriteLine("Digite o ID do cliente: ");
            int id = Convert.ToInt32 (Console.ReadLine());
            IEnumerable clienteQuerry = from cliente in ClienteController.GetClientes() 
                                         where cliente.IdCliente == id select cliente;
            foreach (Cliente cliente in clienteQuerry){ 
                Console.WriteLine(cliente.Nome); 
                Console.WriteLine(" ------ Locação Realizada -----");
                foreach (Locacao locacao in cliente.Locacoes){ 
                    Console.WriteLine(locacao); 
                    Console.WriteLine("------ Filmes locados -----");
                    foreach (Filme filme in locacao.Filmes){ 
                        Console.WriteLine(filme);
                    }
                    Console.WriteLine("------ Fim Filmes -----");
                }
                 Console.WriteLine(" ------ Fim Locação  -----");
            }
        }
    }
}