using System.Data.Odbc;
using PortariaForm.Model;
using PortariaForm.Factory;

namespace PortariaForm.DAO
{
    /// <summary>
    /// Classe <c>VisitaDAO</c> efetua o CRUD na tabela <c>dbo.visitas</c> do Banco de dados.
    /// </summary>
    class VisitaDAO
    {
        /// <summary>
        /// Essa função insere <paramref name="visita"/> na tabela <c>dbo.visitas</c>.
        /// </summary>
        /// <param name="visita">A visita que será inserida na tabela <c>dbo.visitas</c>.</param>
        /// <returns>
        /// <c>Id</c> gerado pelo Banco de dados para <paramref name="visita"/>.
        /// </returns>
        public static int Inserir(Visita visita)
        {
            string query = "INSERT INTO [visitas] (created_at, pessoa_id, destino_id, portaria_nome, recepcionista) VALUES (?, ?, ?, ?, RTRIM(?)) SELECT SCOPE_IDENTITY()";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@created_at", OdbcType.DateTime).Value = visita.Criacao;
            cmd.Parameters.Add("@pessoa_id", OdbcType.Int).Value = visita.PessoaId;
            cmd.Parameters.Add("@destino_id", OdbcType.Int).Value = visita.DestinoId;
            cmd.Parameters.Add("@portaria_nome", OdbcType.Char).Value = visita.PortariaNome;
            cmd.Parameters.Add("@recepcionista", OdbcType.Char).Value = visita.Recepcionista;

            try
            {
                conexao.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            } 
            catch(Exception ex)
            {
                throw new Exception("Não foi possível inserir visita no Banco de Dados.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Essa função efetua a busca de <paramref name="id"/> no Banco de dados.
        /// </summary>
        /// <param name="id">Id da visita a ser buscada na tabela <c>dbo.visitas</c>.</param>
        /// <returns>
        /// <c>Visita</c> encontrada no Banco de dados.   
        /// </returns>
        public static Visita BuscarVisitaPorPessoaId(int id) // Busca última visita usando pessoa_id
        {
            string query = "SELECT TOP 1 id, created_at, destino_id, portaria_nome, recepcionista FROM [visitas] WHERE pessoa_id = ? ORDER BY created_at desc";
            
            Visita visita = new()
            {
                Id = -1
            };

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@pessoa_id", OdbcType.Int).Value = id;

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    visita.Id = reader.GetInt32(0);
                    visita.Criacao = reader.GetDateTime(1);
                    visita.DestinoId = reader.GetInt32(2);
                    visita.PortariaNome = reader.GetString(3);
                    visita.Recepcionista = reader.GetString(4);
                    visita.PessoaId = id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao Banco de Dados.\n" + ex.Message);
            }

            return visita;
        }
    }
}
