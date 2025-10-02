using System.Data.Odbc;
using PortariaForm.Factory;
using Registro_de_Visitantes.Model;

namespace Registro_de_Visitantes.DAO
{
    /// <summary>
    /// Classe <c>AuditoriaDAO</c> efetua o CRUD na tabela <c>dbo.auditoria</c> do Banco de dados.
    /// </summary>
    class AuditoriaDAO
    {
        /// <summary>
        /// Essa função insere <paramref name="auditoria"/> na tabela <c>dbo.auditoria</c>.
        /// </summary>
        /// <param name="auditoria">A auditoria que será inserida na tabela <c>dbo.auditoria</c>.</param>
        /// <returns>
        /// <c>Id</c> gerado pelo Banco de dados para <paramref name="auditoria"/>.
        /// </returns>
        public static int Inserir(Auditoria auditoria)
        {
            string query = "INSERT INTO [auditoria] (pessoa_id, created_at, nome_anterior, nome_alterado) VALUES(?, ?, ?, ?) SELECT SCOPE_IDENTITY()";

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@pessoa_id", OdbcType.Int).Value = auditoria.PessoaId;
            cmd.Parameters.Add("@created_at", OdbcType.DateTime).Value = auditoria.Criacao;
            cmd.Parameters.Add("@nome_anterior", OdbcType.VarChar).Value = auditoria.NomeAnterior;
            cmd.Parameters.Add("@nome_alterado", OdbcType.VarChar).Value = auditoria.NomeAlterado;

            try
            {
                conexao.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir na tabela Auditoria no Banco de Dados.\n" + ex.Message);
            }
        }
    }
}
