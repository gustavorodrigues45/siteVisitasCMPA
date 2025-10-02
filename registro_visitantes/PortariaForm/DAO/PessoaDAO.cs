using PortariaForm.Model;
using PortariaForm.Factory;
using System.Data.Odbc;

namespace PortariaForm.DAO
{
    /// <summary>
    /// Classe <c>PessoaDAO</c> efetua o CRUD na tabela <c>dbo.pessoas</c> do Banco de dados.
    /// </summary>
    class PessoaDAO
    {
        /// <summary>
        /// Essa função insere <paramref name="pesssoa"/> na tabela <c>dbo.pessoas</c>.
        /// </summary>
        /// <param name="pesssoa">A pessoa que será inserida na tabela <c>dbo.pessoas</c>.</param>
        /// <returns>
        /// <c>Id</c> gerado pelo Banco de dados para <paramref name="pesssoa"/>.
        /// </returns>
        public static int Inserir(Pessoa pesssoa)
        {
            string query = "INSERT INTO [pessoas] (tipo_documento, documento, nome, created_at) VALUES (RTRIM(?), ?, ?, ?) SELECT SCOPE_IDENTITY()";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@tipo_documento", OdbcType.Char).Value = !string.IsNullOrEmpty(pesssoa.TipoDocumento) ? pesssoa.TipoDocumento : DBNull.Value;
            cmd.Parameters.Add("@documento", OdbcType.Char).Value = !string.IsNullOrEmpty(pesssoa.Documento) ? pesssoa.Documento : DBNull.Value;
            cmd.Parameters.Add("@nome", OdbcType.VarChar).Value = pesssoa.Nome;
            cmd.Parameters.Add("@created_at", OdbcType.DateTime).Value = pesssoa.Criacao;
            
            try
            {
                conexao.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir pessoa no Banco de Dados.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Essa função atualiza o nome de uma pessoa que possua o <c>id</c> igual ao de <paramref name="pessoa"/> na tabela <c>dbo.pessoas</c>.
        /// </summary>
        /// <param name="pessoa">pessoa com o nome alterado para atualizar tabela <c>dbo.visitas</c>.</param>
        public static void AtualizarNome(Pessoa pessoa)
        {
            string query = "UPDATE [pessoas] SET nome = RTRIM(?) WHERE id = ?";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            if (pessoa == null) throw new ArgumentException("Argumento pessoa está nulo.");

            cmd.Parameters.Add("@nome", OdbcType.Char).Value = pessoa.Nome;
            cmd.Parameters.Add("@id", OdbcType.Int).Value = pessoa.Id;

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar nome de pessoa no Banco de Dados.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Essa função efetua a busca de <paramref name="tipoDocumento"/> e <paramref name="documento"/> na tabela <c>dbo.pessoas</c>.
        /// </summary>
        /// <param name="tipoDocumento">Tipo de documento a ser buscado na tabela <c>dbo.pessoas</c>.</param>
        /// <param name="documento">Documento a ser buscado na tabela <c>dbo.pessoas</c>.</param>
        /// <returns>
        /// <c>Pessoa</c> encontrada no Banco de dados com os dados correspondentes passados como parâmetro.   
        /// </returns>
        public static Pessoa BuscarDocumento(string tipoDocumento, string documento)
        {
            string query = "SELECT id, documento, tipo_documento, nome, created_at FROM [pessoas] WHERE documento = ? and tipo_documento = ?";
            Pessoa pessoa = new()
            {
                Id = -1
            };

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@documento", OdbcType.Char).Value = documento.Trim();
            cmd.Parameters.Add("@documento", OdbcType.Char).Value = tipoDocumento.TrimStart().TrimEnd();

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pessoa.Id = reader.GetInt32(0);
                    pessoa.Documento = reader.GetString(1);
                    pessoa.TipoDocumento = reader.GetString(2);
                    pessoa.Nome = reader.GetString(3);
                    pessoa.Criacao = reader.GetDateTime(4);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar pessoa no Banco de Dados.\n" + ex.Message);
            }

            return pessoa;
        }

        /// <summary>
        /// Essa função efetua a busca de <paramref name="documento"/> na tabela <c>dbo.pessoas</c>.
        /// </summary>
        /// <param name="documento">Documento a ser buscado na tabela <c>dbo.pessoas</c>.</param>
        /// <returns>
        /// <c>Pessoa</c> encontrada no Banco de dados com os dado correspondente passado como parâmetro.   
        /// </returns>
        public static Pessoa BuscarDocumento(string documento)
        {
            string query = "SELECT id, documento, tipo_documento, nome, created_at FROM [pessoas] WHERE documento = ?";
            Pessoa pessoa = new()
            {
                Id = -1
            };

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@documento", OdbcType.Char).Value = documento.Trim();

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pessoa.Id = reader.GetInt32(0);
                    pessoa.Documento = reader.GetString(1);
                    pessoa.TipoDocumento = reader.GetString(2);
                    pessoa.Nome = reader.GetString(3);
                    pessoa.Criacao = reader.GetDateTime(4);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar pessoa no Banco de Dados.\n" + ex.Message);
            }

            return pessoa;
        }
    }
}
