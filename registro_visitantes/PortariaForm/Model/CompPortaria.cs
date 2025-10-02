namespace PortariaForm.Model
{
    /// <summary>
    /// Classe <c>CompPortaria</c> representa a tabela <c>dbo.computadores_portaria</c> do Banco de Dados.
    /// </summary>
    public class CompPortaria
    {
        #region Propriedades
        /// <summary>
        /// Retorna ou Define propriedade <c>Id</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Id</c> representa o campo <c>id</c> da tabela <c>dbo.computadores_portaria</c> do Banco de dados.</para>
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>Computador</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Computador</c> representa o campo <c>computador</c> da tabela <c>dbo.computadores_portaria</c> do Banco de dados.</para>
        /// <para>Essa propriedade seria o nome do Computador. Ex: INFO-D04.</para>
        /// </value>
        public string Computador { 
            get => this._computador; 
            set => this._computador = value.Trim().ToLower(); //Apaga os espaços em branco e deixa a string somente com letras minúsculas.
        }
        private string _computador;
        /// <summary>
        /// Retorna ou Define propriedade <c>Nome</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Nome</c> representa o campo <c>nome</c> da tabela <c>dbo.computadores_portaria</c> do Banco de dados.</para>
        /// <para>Essa propriedade seria o local em que o computador está presente. Ex: Ala Sul, Ala Norte e Rampa.</para>
        /// </value>
        public string Nome { 
            get => this._nome; 
            set => this._nome = value.Trim().ToLower(); //Apaga os espaços em branco e deixa a string somente com letras minúsculas.
        }
        private string _nome;
        #endregion
    }
}
