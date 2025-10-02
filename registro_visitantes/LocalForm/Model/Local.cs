namespace LocalForm.Model
{
    /// <summary>
    /// Classe <c>Local</c> representa a tabela <c>dbo.locais</c> do Banco de Dados.
    /// </summary>
    public class Local
    {
        #region Propriedades
        /// <summary>
        /// Retorna ou Define propriedade <c>Id</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Id</c> representa o campo <c>id</c> da tabela <c>dbo.locais</c> do Banco de dados.</para>
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>Ativo</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Ativo</c> representa o campo <c>ativo</c> da tabela <c>dbo.locais</c> do Banco de dados.</para>
        /// </value>
        public bool Ativo { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>Nome</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Nome</c> representa o campo <c>nome</c> da tabela <c>dbo.locais</c> do Banco de dados.</para>
        /// </value>
        public string? Nome { 
            get => this._nome; 
            set => this._nome = value.TrimStart().TrimEnd(); 
        }
        private string? _nome;
        #endregion
    }
}
