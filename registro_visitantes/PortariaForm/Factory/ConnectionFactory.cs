using System.Data.Odbc;

namespace PortariaForm.Factory
{
    /// <summary>
    /// Classe <c>ConnectionFactory</c> cria conexão com o Banco de dados.
    /// </summary>
    static class ConnectionFactory
    {
        /// <summary>
        /// Essa função cria conexão com o banco de dados.
        /// </summary>
        /// <returns>
        /// Objeto para efetuar operações no banco.
        /// </returns>
        public static OdbcConnection CriarConexao()
        {
            string txtConexao = "Driver={SQL Server};Server=recepcao.servidor.local;DataBase=portaria;Uid=recepcao;Pwd=R3c3pc20@2022;"; //Autenticacao SQL Server [portaria_t]

            OdbcConnection conexao;

            try
            {
                conexao = new OdbcConnection(txtConexao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao Banco de Dados.\n" + ex.Message);
            }

            return conexao;
        }
    }
}