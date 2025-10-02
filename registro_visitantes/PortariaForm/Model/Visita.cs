namespace PortariaForm.Model
{
    /// <summary>
    /// Classe <c>Visita</c> representa a tabela <c>dbo.visitas</c> do Banco de Dados.
    /// </summary>
    public class Visita
    {
        #region Propriedades
        /// <summary>
        /// Retorna ou Define propriedade <c>Id</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Id</c> representa o campo <c>id</c> da tabela <c>dbo.visitas</c> do Banco de dados.</para>
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>Criacao</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Criacao</c> representa o campo <c>created_at</c> da tabela <c>dbo.visitas</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa a data e hora da visita.</para>
        /// </value>
        public DateTime Criacao { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>PessoaId</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>PessoaId</c> representa o campo <c>pessoa_id</c> da tabela <c>dbo.visitas</c> do Banco de dados.</para>
        /// <para>Essa propriedade é vinculada ao <c>id</c> da <c>pessoa</c> que efetuou a visita.</para>
        /// </value>
        public int PessoaId { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>DestinoId</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>DestinoId</c> representa o campo <c>destino_id</c> da tabela <c>dbo.visitas</c> do Banco de dados.</para>
        /// <para>Essa propriedade é vinculada ao <c>id</c> de <c>local</c> que pessoa irá visitar.</para>
        /// </value>
        public int DestinoId { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>PortariaNome</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>PortariaNome</c> representa o campo <c>portaria_nome</c> da tabela <c>dbo.visitas</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa o local em que pessoa efetuou cadastramento para visita. Ex: Ala Sul.</para>
        /// </value>
        public string PortariaNome { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>Recepcionista</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Recepcionista</c> representa o campo <c>recepcionista</c> da tabela <c>dbo.visitas</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa o nome da pessoa que cadastrou a visita no sistema.</para>
        /// </value>
        public string Recepcionista { get; set; }
        #endregion
    }
}
