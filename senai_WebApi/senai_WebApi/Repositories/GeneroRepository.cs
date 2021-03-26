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
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que vai atribuir valores conforme escrito abaixo ao nome e id - coluna e variavel
                string queryUpdateIdBody = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                using(SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            //Declara a sQL connection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryUpdateUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                //Declara a sql Command cmd passando a query que será executada e a conexao como parametro
                using(SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// busca o id do genero q sera atualizado
        /// </summary>
        /// <returns></returns>
        public GeneroDomain BuscarPorId()
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @ID";

                con.Open();

                //lê os dados do bco e armazena como variavel c#
                SqlDataReader rdr;

            using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // cmd.Parameters.AddWithValue("@ID",id);
                    cmd.Parameters.AddWithValue("@ID",id);

                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se a busca retornou algum resultado( se tinha algo para ler lá)
                    if (rdr.Read())
                    {
                        //se sim, instancia um novo objeto chamado generobuscado do tipo generodomain
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            //atribui à propriedade idGenero o valor da coluna idGenero da tabela do bco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            //atribui à propriedade Nome o valor da coluna Nome da tabela do bco de dados.
                            nome = rdr["Nome"].ToString()

                        };
                        return generoBuscado;
                    }
                    return null;
                }
            }
        }

    

        public void Cadastrar(GeneroDomain novoGenero)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            { 
                //Declara a query que será inserida
                string queryInsert = "INSERT INTO Generos(Nome) VALUES(@Nome)";
                //VALUES(@Nome) para inserir nome com apostrofe

                //passo a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);
                }
            }
        }

        /// <summary>
        /// Deleta um genero através do seu id
        /// </summary>
        /// <param name="id">id do genero que será deletado</param>
        public void Deletar(int id)
        {
            //Declara a sqlConection con passando a string de conex~~ao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query passando o id como parametro
                string queryDelete = "DELETE FROM Generos Where idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Atribui o valor recebido do id como o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    //Abre a conexao com o bco de dados
                    con.Open();

                //executa a query
                cmd.ExecuteNonQuery();
                }
            }
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
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
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
                            nome = rdr[1].ToString()
                        };
                        listaGeneros.Add(genero);
                    }

                }
    }
          return listaGeneros;

        }
    }
} 
