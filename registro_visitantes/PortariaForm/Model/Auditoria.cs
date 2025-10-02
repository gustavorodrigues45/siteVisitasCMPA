namespace Registro_de_Visitantes.Model
{
    /// <summary>
    /// Classe <c>Auditoria</c> representa a tabela <c>dbo.auditoria</c> do Banco de Dados.
    /// </summary>
    public class Auditoria
    {
        #region Propriedades
        /// <summary>
        /// Retorna ou Define propriedade <c>Id</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Id</c> representa o campo <c>id</c> da tabela <c>dbo.auditoria</c> do Banco de dados.</para>
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>PessoaId</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>PessoaId</c> representa o campo <c>pessoa_id</c> da tabela <c>dbo.auditoria</c> do Banco de dados.</para>
        /// <para>Essa propriedade é vinculada ao <c>id</c> da <c>pessoa</c> que teve seu <c>nome</c> alterado.</para>
        /// </value>
        public int PessoaId { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>Criacao</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Criacao</c> representa o campo <c>created_at</c> da tabela <c>dbo.auditoria</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa a data e hora de alteração do nome de pessoa.</para>
        /// </value>
        public DateTime Criacao { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>NomeAnterior</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>NomeAnterior</c> representa o campo <c>nome_anterior</c> da tabela <c>dbo.auditoria</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa o nome anterior de pessoa após sua alteração</para>
        /// </value>
        public string NomeAnterior { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>NomeAlterado</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>NomeAlterado</c> representa o campo <c>nome_alterado</c> da tabela <c>dbo.auditoria</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa o nome de pessoa após sua alteração</para>
        /// </value>
        public string NomeAlterado { get; set; }
        #endregion
    }
}
