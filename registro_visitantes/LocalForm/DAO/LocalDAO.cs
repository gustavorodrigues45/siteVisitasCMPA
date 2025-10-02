using LocalForm.Model;
using LocalForm.Factory;
using System.Data.Odbc;

namespace LocalFomr.DAO
{
    /// <summary>
    /// Classe <c>LocalDAO</c> efetua o CRUD na tabela <c>dbo.locais</c> do Banco de dados.
    /// </summary>
    public static class LocalDAO
    {
        /// <summary>
        /// Essa função insere <paramref name="local"/> na tabela <c>dbo.locais</c>.
        /// </summary>
        /// <param name="local">O local que será inserido na tabela <c>dbo.locais</c>.</param>
        public static void Inserir(Local local)
        {
            string query = "INSERT INTO [locais] (nome, ativo) VALUES (RTRIM(?), 1)";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@nome", OdbcType.Char).Value = local.Nome;

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir local no Banco de Dados.\n" + ex.Message + "\n" + ex.GetType().Name);
            }
        }

        /// <summary>
        /// Essa função atualiza o nome de uma pessoa que possua a propriedade <c>id</c> igual ao de <paramref name="local"/> na tabela <c>dbo.pessoas</c>.
        /// </summary>
        /// <param name="local">Local com alterações para atualizar dados na tabela <c>dbo.locais</c>.</param>
        public static void Atualizar(Local local)
        {
            string query = "UPDATE [locais] SET nome = RTRIM(?), ativo = ? WHERE id = ?";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);
            
            if (local == null) throw new ArgumentException("Argumento local está nulo.");

            cmd.Parameters.Add("@nome", OdbcType.Char).Value = local.Nome;
            cmd.Parameters.Add("@ativo", OdbcType.Bit).Value = local.Ativo;
            cmd.Parameters.Add("@id", OdbcType.Int).Value = local.Id;

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar nome de local no Banco de Dados.\n" + ex.Message + "\n" + ex.GetType().Name);
            }
        }

        /// <summary>
        /// Essa função efetua a busca de todos os locais cadastrados na tabela <c>dbo.locais</c>.
        /// </summary>
        /// <returns>
        /// Uma lista com todos os locais cadastrados no sistema.   
        /// </returns>
        public static List<Local> BuscarTodos()
        {
            string query = "SELECT id, nome, ativo FROM [locais]";
            List<Local> lista = new();

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Local local = new()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Ativo = reader.GetBoolean(2)
                    };

                    lista.Add(local);
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
        /// <param name="nome">Nome do local a ser buscado na tabela <c>dbo.locais</c>.</param>
        /// <returns>
        /// <c>Local</c> encontrado no Banco de dados com os dados correspondentes passados como parâmetro.   
        /// </returns>
        public static Local BuscarLocalPorNome(string? nome)
        {
            string query = "SELECT id, ativo FROM [locais] WHERE nome = ?";
            Local local = new()
            {
                Id = -1
            };

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@nome", OdbcType.Char).Value = nome.TrimStart().TrimEnd();

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    local.Id = reader.GetInt32(0);
                    local.Ativo = reader.GetBoolean(1);
                    local.Nome = nome;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao Banco de Dados.\n" + ex.Message + "\n" + ex.GetType());
            }

            return local;
        }

        /// <summary>
        /// Essa função deleta local com o <paramref name="id"/> na tabela <c>dbo.locais</c>.
        /// </summary>
        /// <param name="id">Id de local a ser deletado na tabela <c>dbo.locais</c>.</param>
        public static void Delete(int id)
        {
            string query = "DELETE FROM [locais] WHERE id = ?";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@nome", OdbcType.Int).Value = id;

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar local no Banco de Dados.\n" + ex.Message + "\n" + ex.GetType());
            }
        }
    }
}
