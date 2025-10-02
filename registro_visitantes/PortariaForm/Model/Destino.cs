namespace PortariaForm.Model
{
    /// <summary>
    /// Classe <c>Destino</c> representa a tabela <c>dbo.locais</c> do Banco de Dados.
    /// </summary>
    public class Destino
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
        /// Retorna ou Define propriedade <c>Nome</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Nome</c> representa o campo <c>nome</c> da tabela <c>dbo.locais</c> do Banco de dados.</para>
        /// <para>Essa propriedade seria o nome do destino. Ex: Fotografia.</para>
        /// </value>
        public string? Nome { 
            get => this._nome; 
            set => this._nome = value.TrimStart().TrimEnd();  
        }
        private string? _nome;
        /// <summary>
        /// Retorna ou Define propriedade <c>ativo</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>ativo</c> representa o campo <c>id</c> da tabela <c>dbo.locais</c> do Banco de dados.</para>
        /// <para>Essa propriedade diz se local está ativo no sistema.</para>
        /// </value>
        public bool Ativo { get; set; }
        #endregion

        /// <summary>
        /// Cria objeto <c>Destino</c> com valor de propriedade <c>Ativo</c> como <c>true</c>.
        /// </summary>
        public Destino() {
            this.Ativo = true;
        }

        /// <summary>
        /// Verifica se objeto passado como parâmetro é igual ao objeto chamador da função.
        /// </summary>
        /// <returns>
        /// Um boolean que afirma se objeto é igual ao objeto passado como parâmetro.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (!ReferenceEquals(this, obj)) return false;

            Destino? d = obj as Destino;

            return d.Nome.ToLower().Equals(this.Nome.ToLower());
        }

        /// <summary>
        /// Cria o hash.
        /// </summary>
        /// <returns>
        /// O hash do objeto.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
