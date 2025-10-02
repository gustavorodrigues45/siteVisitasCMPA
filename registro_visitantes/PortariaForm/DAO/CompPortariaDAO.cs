using PortariaForm.Model;
using PortariaForm.Factory;
using System.Data.Odbc;

namespace PortariaForm.DAO
{
    /// <summary>
    /// Classe <c>CompPortariaDAO</c> efetua o CRUD na tabela <c>dbo.computadores_portaria</c> do Banco de dados.
    /// </summary>
    public class CompPortariaDAO
    {
        /// <summary>
        /// Essa função efetua a busca de <paramref name="computador"/> na tabela <c>dbo.computadores_portaria</c>.
        /// </summary>
        /// <param name="computador">Nome do computador a ser buscado na tabela <c>dbo.computadores_portaria</c>.</param>
        /// <returns>
        /// <c>CompPortaria</c> com o nome do computador correspondente ao passado como parâmetro.   
        /// </returns>
        public static CompPortaria BuscarPorComputador(string computador)
        {
            string query = "SELECT id, computador, nome FROM [computadores_portaria] WHERE computador = ?";
            CompPortaria comp = new()
            {
                Id = -1
            };

            using OdbcConnection conexao = ConnectionFactory.CriarConexao();
            using OdbcCommand cmd = new(query, conexao);

            cmd.Parameters.Add("@computador", OdbcType.Char).Value = computador.Trim();

            try
            {
                conexao.Open();

                using OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    comp.Id = reader.GetInt32(0);
                    comp.Computador = reader.GetString(1);
                    comp.Nome = reader.GetString(2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao Banco de Dados.\n" + ex.Message);
            }

            return comp;
        }
    }
}
