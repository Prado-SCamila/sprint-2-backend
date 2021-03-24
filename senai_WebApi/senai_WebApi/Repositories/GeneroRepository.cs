using senai_WebApi.Domains;
using senai_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_WebApi.Repositories
{

    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de Conexão com o banco de dados que recebe os parametros.
        /// </summary>
        /// <param name="genero"></param>
        /// Aqui eu logo pelo pelo meu servidor
        private string stringConexao = "Data Source=DESKTOP-840P8H6;initial catalog=Filmes; user Id=sa;pwd=miladori23";
        //aqui eu autentico pelo windows
        //private string stringConexao = "Data Source=DESKTOP-840P8H6;initial catalog=Filmes; integrated security=true";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de generos onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //estou criando um objeto con que irá permitir uma conexão com o BD
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser executada- Busca os atributos idGenero e Nome da Classe genero no BD
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                //estou conectando de fato com o BD
                con.Open();

                //Lê a tabela do bco de dados
                SqlDataReader rdr;

                //Estou criando um comando passando a instrução e o obj de conexão como parametros.
                using (SqlCommand cmd) = new SqlCommand(querySelectAll, con)
                {

                    //executa a query e armazena os dados no rdr( mando o leitor rdr executar o comando cmd)
                    rdr = cmd.ExecuteReader();

                //enquanto houver registros para serem lidos no rdr, o laço se repete
                while (rdr.Read())
                {
                    //instancio um objeto do generodomain(classe)
                    GeneroDomain genero = new GeneroDomain()
                    {
                        //converte um objeto em um numero inteiro e armazeno no id Genero
                        //atrivui a propriedade idgenero o valor da primeira coluna do bd
                        idGenero = Convert.ToInt32(rdr[0]),
                        //atribui à propriedade nome o valor da segunda coluna da tabela do bd
                        nome = rdr[1].ToString();
                    };
                listaGeneros.Add(genero);
            } 
          
        }
    }
          return listaGeneros;

        }
    }
} 
