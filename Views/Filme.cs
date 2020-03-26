using System;
using Models;
using Controllers;
using System.Collections;
using System.Linq;

namespace View {
    public class FilmeView {
        /// <summary>
        /// This method is responsible for creating the movies
        /// </summary>
        public static void InserirFilme () {
            Console.WriteLine ("Informações sobre o filme: ");
            Console.WriteLine ("Informe o nome: ");
            String nome = Console.ReadLine ();
            Console.WriteLine ("Informe a data de lançamento (dd/mm/yyyy): ");
            String sDtLancamento = Console.ReadLine ();
            Console.WriteLine ("Informe a Sinopse: ");
            String cpf = Console.ReadLine ();
            Console.WriteLine ("Informe o valor para locação: ");
            double valor = Convert.ToDouble (Console.ReadLine ());
            Console.WriteLine ("Informe a quantidade em estoque: ");
            int estoque = Convert.ToInt32 (Console.ReadLine ());
            
            FilmeController.InserirFilme (
                nome,
                sDtLancamento,
                cpf,
                valor,
                estoque
            );
        }

        /// <summary>
        /// This method is responsible for listing the movies
        /// </summary>
        public static void ListarFilmes () {
            Console.WriteLine ("Lista de Filmes: ");
            FilmeController.GetFilmes().ForEach (filme => Console.WriteLine (filme.ToString (true)));
        }

        /// <summary>
        /// This method is responsible for consulting a movie
        /// </summary>

        public static void ConsultarFilme () {
            Filme filme;

            // Search the movie with id
            do {
                Console.WriteLine ("Informe o filme que deseja consultar: ");
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
            } while (filme == null);
            Console.WriteLine (filme.ToString ());
        }

        public static void ConsultarFilmeLINQ(){
            Console.WriteLine("Digite o ID do Filme: ");
            int id = Convert.ToInt32 (Console.ReadLine());
            IEnumerable filmeQuerry = from filme in FilmeController.GetFilmes() 
                                         where filme.IdFilme == id select filme;
            foreach (Filme filme in filmeQuerry){ 
                Console.WriteLine(filme.NomeFilme); 
            }
        }

        /// <sumary>This method access db import.</sumary>
        public static void Importar () {
            FilmeController.Importar ();
            Console.WriteLine("======= IMPORTAÇÃO DE FILMES CONCLUÍDA COM SUCESSO =======");
        }
    }
}