using System.Globalization;

namespace PortariaForm.Model
{
    /// <summary>
    /// Classe <c>Pessoa</c> representa a tabela <c>dbo.pessoas</c> do Banco de Dados.
    /// </summary>
    public class Pessoa
    {
        #region Propriedades
        /// <summary>
        /// Retorna ou Define propriedade <c>Id</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Id</c> representa o campo <c>id</c> da tabela <c>dbo.pessoas</c> do Banco de dados.</para>
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>Nome</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Nome</c> representa o campo <c>nome</c> da tabela <c>dbo.pessoas</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa o nome da pessoa. Aplica função <c>CapNome</c> para o valor passado.</para>
        /// </value>
        public string? Nome
        {
            get => this._nome;
            set => this._nome = Pessoa.CapNome(value);
        }
        private string? _nome;
        /// <summary>
        /// Retorna ou Define propriedade <c>Criacao</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Criacao</c> representa o campo <c>created_at</c> da tabela <c>dbo.pessoas</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa a data e hora de primeiro cadastro de pessoa com o documento apresentado.</para>
        /// </value>
        public DateTime Criacao { get; set; }
        /// <summary>
        /// Retorna ou Define propriedade <c>Documento</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>Documento</c> representa o campo <c>documento</c> da tabela <c>dbo.pessoas</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa o documento de pessoa/visitante.</para>
        /// </value>
        public string? Documento
        {
            get => this._documento;
            set => this._documento = /*Pessoa.CpfValido(value) ?*/ value.Trim().Replace(".", "").Replace("-", "") /*: throw new ArgumentException("CPF inválido.")*/;
        }
        private string? _documento;
        /// <summary>
        /// Retorna ou Define propriedade <c>TipoDocumento</c>.
        /// </summary>
        /// <value>
        /// <para>Propriedade <c>TipoDocumento</c> representa o campo <c>tipo_documento</c> da tabela <c>dbo.pessoas</c> do Banco de dados.</para>
        /// <para>Essa propriedade representa o tipo de documento apresentado pela pesssoa ao visitar. Ex: CPF.</para>
        /// </value>
        public string? TipoDocumento
        {
            get => this._tipDocumento;
            set => this._tipDocumento = (string.IsNullOrEmpty(value)) ? null : value.TrimStart().TrimEnd().ToUpper();
        }
        private string? _tipDocumento;
        #endregion

        //TODO: Não upper em palavras - da, do, das, dos
        /// <summary>
        /// Essa função capitaliza a primeira letra de cada palavra de <paramref name="texto"/>.
        /// </summary>
        /// <param name="texto">A variável que terá suas primeiras letras capitalizadas.</param>
        /// <returns>
        /// String com primeiras letras capitalizadas.   
        /// </returns>
        public static string CapNome(string? texto)
        {
            TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;

            List<string> textoFrag = new(texto.ToLower().Split(" "));

            textInfo.ToTitleCase(String.Join(" ",
                textoFrag.Where(palavra =>
                    !palavra.Equals("da") && !palavra.Equals("das") && !palavra.Equals("do") && !palavra.Equals("dos")).ToList()
            ));

            textoFrag.RemoveAll(tex => tex.Equals(""));

            return textInfo.ToTitleCase(String.Join(" ", textoFrag));
        }

        /// <summary>
        /// Essa função verifica validade de <paramref name="cpf"/> como documento.
        /// </summary>
        /// <param name="cpf">A variável que será validada.</param>
        /// <returns>
        /// Bool que informa se CPF é valido.   
        /// </returns>
        public static bool CpfValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf[..9];
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Essa função verifica validade de <paramref name="rg"/> como documento.
        /// </summary>
        /// <param name="rg">A variável que será validada.</param>
        /// <returns>
        /// Bool que informa se RG é valido.   
        /// </returns>
        public static bool RgValido(string rg)
        {
            //string digitos = rg.Trim().Replace(".", "").Replace("-", "");

            //if (digitos.Length < 6 || digitos.Length > 9) return false;

            //TODO: Pesquisar formas de validar RG

            return true;
        }

        /// <summary>
        /// Essa função verifica validade de <paramref name="cnh"/> como documento.
        /// </summary>
        /// <param name="cnh">A variável que será validada.</param>
        /// <returns>
        /// Bool que informa se CNH é valida.   
        /// </returns>
        public static bool CnhValido(string cnh)
        {
            cnh = cnh.Trim().Replace(".", "").Replace("-", "");

            if (cnh.Length < 11 && !cnh.Equals("11111111111")) return false;

            int dsc = 0;
            int soma = 0;

            for (int i = 0, j = 9; i < 9; i++, j--)
            {
                soma += (Convert.ToInt32(cnh[i].ToString()) * j);
            }

            int dig1 = soma % 11;

            if (dig1 >= 10)
            {
                dig1 = 0;
                dsc = 2;
            }

            soma = 0;

            for (int i = 0, j = 1; i < 9; ++i, ++j)
            {
                soma += (Convert.ToInt32(cnh[i].ToString()) * j);
            }

            int x = soma % 11;

            int dig2 = (x >= 10) ? 0 : x - dsc;

            return dig1.ToString() + dig2.ToString() == cnh.Substring(cnh.Length - 2, 2);
        }
    }
}
