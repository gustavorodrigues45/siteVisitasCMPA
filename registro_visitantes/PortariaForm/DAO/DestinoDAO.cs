using PortariaForm.Model;
using PortariaForm.Factory;
using System.Data.Odbc;

namespace PortariaForm.DAO
{
    /// <summary>
    /// Classe <c>DestinoDAO</c> efetua o CRUD na tabela <c>dbo.locais</c> do Banco de dados.
    /// </summary>
    public class DestinoDAO
    {
        /// <summary>
        /// Essa função efetua a busca de todos os destinos na tabela <c>dbo.locais</c>.
        /// </summary>
        /// <returns>
        /// Uma lista com todos os locais cadastrados no sistema.   
        /// </returns>
        public static List<Destino> BuscarTodos()
        {
            string query = "SELECT id, nome, ativo FROM [locais]";
            List<Destino> lista = new();

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Destino destino = new()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Ativo = reader.GetBoolean(2)
                    };

                    lista.Add(destino);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao Banco de Dados.\n" + ex.Message);
            }

            return lista;
        }

        /// <summary>
        /// Essa função efetua a busca de <paramref name="nome"/> na tabela <c>dbo.locais</c>.
        /// </summary>
        /// <param name="nome">Nome de um local a ser buscado na tabela <c>dbo.locais</c>.</param>
        /// <returns>
        /// <c>Destino</c> com o nome correspondente ao passado como parâmetro.   
        /// </returns>
        public static Destino BuscarNome(string nome)
        {
            Destino destino = new()
            {
                Id = -1,
                Nome = nome
            };

            string query = "SELECT id, ativo FROM [locais] WHERE nome = ?";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@nome", OdbcType.Char).Value = destino.Nome;

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    destino.Id = reader.GetInt32(0);
                    destino.Ativo = reader.GetBoolean(1);
                } 
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao Banco de Dados.\n" + ex.Message);
            }

            return destino;
        }

        /// <summary>
        /// Essa função efetua a busca de <paramref name="id"/> na tabela <c>dbo.locais</c>.
        /// </summary>
        /// <param name="id">Id de um local a ser buscado na tabela <c>dbo.locais</c>.</param>
        /// <returns>
        /// <c>Destino</c> com o id correspondente ao passado como parâmetro.   
        /// </returns>
        public static Destino BuscarId(int id)
        {
            Destino destino = new()
            {
                Id = -1
            };

            string query = "SELECT nome, ativo FROM [locais] WHERE id = ?";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@nome", OdbcType.Int).Value = id;

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    destino.Id = id;
                    destino.Nome = reader.GetString(0);
                    destino.Ativo = reader.GetBoolean(1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao Banco de Dados.\n" + ex.Message);
            }

            return destino;
        }

        /// <summary>
        /// Essa função insere <paramref name="destino"/> na tabela <c>dbo.locais</c>.
        /// </summary>
        /// <param name="destino">O destino que será inserido na tabela <c>dbo.locais</c>.</param>
        /// <returns>
        /// <c>Id</c> gerado pelo Banco de dados para <paramref name="destino"/>.
        /// </returns>
        public static int Inserir(Destino destino)
        {
            string query = "INSERT INTO [locais] (nome, ativo) VALUES (RTRIM(?), 1) SELECT SCOPE_IDENTITY()";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@nome", OdbcType.Char).Value = destino.Nome;

            try
            {
                conexao.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir destino no Banco de Dados.\n" + ex.Message);
            }
        }
    }
}
