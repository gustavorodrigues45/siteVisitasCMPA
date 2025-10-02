using PortariaForm.Model;
using PortariaForm.DAO;
using System.Text;
using Registro_de_Visitantes.Model;
using Registro_de_Visitantes.DAO;

namespace PortariaForm
{
    public partial class CadastroVisitanteForm : Form
    {
        private static string? s_portariaNome;
        private static string? s_usuarioNome;
        private static List<Destino>? s_list;

        public CadastroVisitanteForm()
        {
            InitializeComponent();
        }

        private void CadastroVisitanteForm_Load(object sender, EventArgs e)
        {
            CompPortaria? comp = null;

            try
            {
                comp = CompPortariaDAO.BuscarPorComputador(Environment.MachineName); //Procura Computador no Banco de dados
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (comp.Id != -1)
            {
                s_portariaNome = comp.Nome;
                this.Text += "Portaria " + Pessoa.CapNome(s_portariaNome);
                portariaLabel.Text += " " + s_portariaNome.ToUpper();
            }
            else
            {
                MessageBox.Show("Computador não cadastrado no sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            s_usuarioNome = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;

            this.CarregarDestinoComboBox();
        }

        private void TimerForm_Tick(object sender, EventArgs e)
        {
            dataVisitaDateTimePick.Value = DateTime.Now;
        }

        private void BuscarDocumentoBtn_Click(object sender, EventArgs e)
        {
            Pessoa pessoa;
            string documento = cpfTextBox.Text.Trim();
            string tipoDocumento = "CPF";
            bool valDocumento = this.ValidarDocumento();

            if (!valDocumento)
            {
                //DataCheckBox.Enabled = false;

                if (outroDocumentoCheckBox.Checked)
                {
                    documentoInvalidoLabel.Visible = !string.IsNullOrWhiteSpace(documentoTextBox.Text);
                    //documentoLabelBg.Visible = true;
                    //documentoTextBox.Focus();

                    return;
                }

                cpfInvalidoLabel.Visible = true;
                //cpfInvalidoLabelBg.Visible = true;

                return;
            }

            if (outroDocumentoCheckBox.Checked)
            {
                documento = documentoTextBox.Text.Trim();
                tipoDocumento = tipoDocumentoComboBox.Text.Trim();
            }
            try
            {
                pessoa = PessoaDAO.BuscarDocumento(tipoDocumento, documento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pessoa.Id != -1) // Adiciona o nome da pessoa e seu último destino caso já exista no BD
            {

                nomeTextBox.Text = pessoa.Nome;

                try
                {
                    int destinoId = VisitaDAO.BuscarVisitaPorPessoaId(pessoa.Id).DestinoId;
                    Destino destino = DestinoDAO.BuscarId(destinoId);

                    if (destino.Id != -1) destinoComboBox.Text = destino.Nome;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            pessoa = PessoaDAO.BuscarDocumento(documento);

            if (pessoa.Id != -1) // Caso pessoa já esteja cadastrada no Sistema com outro tipo de documento
            {
                MessageBox.Show("Já existe um vistante cadastrado com esse documento mas utilizando outro tipo de documento." +
                    $"\n{pessoa.TipoDocumento} {pessoa.Documento}",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }

        private void CpfTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DocumentoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            //this.ApagarCampos();
        }

        private void DocumentoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buscarDocumentoBtn.PerformClick();
        }

        private void NomeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cadastrarVisitaBtn.PerformClick();
        }

        private void DestinoComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cadastrarVisitaBtn.PerformClick();
        }

        private void NomeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar) && !char.IsSymbol(e.KeyChar);
        }

        private void DestinoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar) && !char.IsSymbol(e.KeyChar)
                && !char.IsPunctuation(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void DocumentoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void CadastrarVisitaBtn_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new("Visita incluída com sucesso!\n");
            Visita visita = new();
            Pessoa pessoa;
            Destino destino;
            Auditoria auditoria;
            string documento = (outroDocumentoCheckBox.Checked) ? documentoTextBox.Text : cpfTextBox.Text;
            string tipoDocumento = (outroDocumentoCheckBox).Checked ? tipoDocumentoComboBox.Text : "CPF";

            if (!this.ValidarCampos()) return;

            destino = s_list.Find(d =>
                d.Nome.Replace(" ", "").Equals(destinoComboBox.Text.Replace(" ", ""), StringComparison.OrdinalIgnoreCase));

            if (destino != null && !destino.Ativo) // Checa se destino esta ativo no BD
            {
                //destinoLabelBg.Visible = true;
                destinoInvalidoLabel.Visible = true;

                MessageBox.Show("Destino inativo no Sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            try
            {
                pessoa = PessoaDAO.BuscarDocumento(tipoDocumento, documento);

                destino = DestinoDAO.BuscarNome(destinoComboBox.Text);

                visita.Criacao = dataVisitaDateTimePick.Value;

                if (pessoa.Id == -1) // Insere pessoa na tabela pessoas no BD caso pessoa não exista
                {
                    pessoa = PessoaDAO.BuscarDocumento(documento);

                    if (pessoa.Id != -1) // Caso pessoa já esteja cadastrada no Sistema com outro tipo de documento
                    {
                        MessageBox.Show("Já existe um vistante cadastrado com esse documento mas utilizando outro tipo documento." +
                            $"\n{pessoa.TipoDocumento} {pessoa.Documento}",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }

                    pessoa.Documento = documento;
                    pessoa.TipoDocumento = (string.IsNullOrEmpty(pessoa.Documento)) ? null : tipoDocumento;
                    pessoa.Nome = nomeTextBox.Text;
                    pessoa.Criacao = dataVisitaDateTimePick.Value;

                    pessoa.Id = PessoaDAO.Inserir(pessoa);
                }
                else if (!pessoa.Nome.ToLower().Equals(nomeTextBox.Text.TrimStart().TrimEnd().ToLower())) // Atualiza coluna nome da tabela pessoas
                {
                    auditoria = new() // Auditoria
                    {
                        PessoaId = pessoa.Id,
                        Criacao = visita.Criacao,
                        NomeAnterior = pessoa.Nome,
                        NomeAlterado = Pessoa.CapNome(nomeTextBox.Text)
                    };

                    AuditoriaDAO.Inserir(auditoria);

                    pessoa.Nome = nomeTextBox.Text;
                    PessoaDAO.AtualizarNome(pessoa);

                    msg.Append($"Nome de visitante vinculado a {pessoa.TipoDocumento} {pessoa.Documento} foi alterado para \"{pessoa.Nome}\".\n");
                }

                if (destino.Id == -1) // Insere destino na tabela locais no BD caso destino não exista na tabela do BD
                {
                    destino.Nome = destinoComboBox.Text;

                    destino.Id = DestinoDAO.Inserir(destino);

                    msg.Append($"Adicionado novo destino \"{destino.Nome}\" no Sistema.\n");
                }

                visita.PessoaId = pessoa.Id;
                //visita.Criacao = dataVisitaDateTimePick.Value;
                visita.PortariaNome = s_portariaNome;

                visita.DestinoId = destino.Id;

                visita.Recepcionista = s_usuarioNome;

                VisitaDAO.Inserir(visita);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cpfTextBox.Clear();

            outroDocumentoCheckBox.Checked = false;

            this.ApagarCampos();

            MessageBox.Show(msg.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cpfTextBox.Focus();

            this.CarregarDestinoComboBox();
        }

        private void DataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //dataVisitaDateTimePick.Enabled = dataCheckBox.Checked;

            //if (dataCheckBox.Checked)
            //{
            //    TimerForm.Stop();
            //}
            //else
            //{
            //    TimerForm.Start();
            //    dataVisitaDateTimePick.Value = DateTime.Now;
            //}
        }

        private void NomeLabel_Click(object sender, EventArgs e)
        {
            nomeTextBox.Focus();
        }

        private void DataVisitaLabel_Click(object sender, EventArgs e)
        {
            dataVisitaDateTimePick.Focus();
        }

        private void DestinoLabel_Click(object sender, EventArgs e)
        {
            destinoComboBox.Focus();
        }

        private void DocumentoLabel_Click(object sender, EventArgs e)
        {
            cpfTextBox.Focus();
        }

        private void ApagarCampos()
        {
            nomeTextBox.Clear();

            //DataVisitaDateTimePick.Enabled = false;

            //DataCheckBox.Checked = false;
            //DataCheckBox.Enabled = false;

            destinoComboBox.Text = "";

            //CadastrarVisitaBtn.Enabled = false;
        }

        private bool ValidarCampos()
        {
            bool valNome = (nomeTextBox.Text.Trim().Length > 0);
            bool valDestino = destinoComboBox.Text.Trim().Length > 0;
            bool valDocumento = (string.IsNullOrEmpty(documentoTextBox.Text) && string.IsNullOrEmpty(cpfTextBox.Text)) || this.ValidarDocumento();

            //nomeLabelBg.Visible = !valNome;
            nomeInvalidoLabel.Visible = !valNome;

            //destinoLabelBg.Visible = !valDestino;
            destinoInvalidoLabel.Visible = !valDestino;

            //documentoLabelBg.Visible = !valDocumento;
            documentoInvalidoLabel.Visible = !valDocumento;

            return valNome && valDocumento && valDestino;
        }

        private bool ValidarDocumento()
        {
            bool valDocumento = true;

            if (!outroDocumentoCheckBox.Checked)
            {
                return Pessoa.CpfValido(cpfTextBox.Text);
            }

            if ((tipoDocumentoComboBox.Text.Trim().Length == 0) || 
                (documentoTextBox.Text.Trim().Length == 0)) 
                return false;

            switch (tipoDocumentoComboBox.Text)
            {
                case "CNH":
                    valDocumento = Pessoa.CnhValido(documentoTextBox.Text);
                    break;
                case "RG":
                    valDocumento = Pessoa.RgValido(documentoTextBox.Text);
                    break;
                case "CPF":
                    valDocumento = Pessoa.CpfValido(documentoTextBox.Text);
                    break;
            }

            return valDocumento;
        }

        private void CarregarDestinoComboBox()
        {
            try
            {
                s_list = DestinoDAO.BuscarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            destinoComboBox.Items.Clear();

            s_list.ForEach(delegate (Destino destino)
            {
                if (destino.Ativo) destinoComboBox.Items.Add(destino.Nome);
            });
        }

        private void DocumentoTextBox_TextChanged(object sender, EventArgs e)
        {
            documentoLabelBg.Visible = false;
            documentoInvalidoLabel.Visible = false;

            cpfInvalidoLabelBg.Visible = false;
            cpfInvalidoLabel.Visible = false;

            this.ApagarCampos();
        }

        private void DestinoComboBox_TextChanged(object sender, EventArgs e)
        {
            destinoLabelBg.Visible = false;
            destinoInvalidoLabel.Visible = false;
        }

        /// <summary>
        /// Deixa label que afirma nome invalido invisível
        /// </summary>
        private void NomeTextBox_TextChanged(object sender, EventArgs e)
        {
            nomeLabelBg.Visible = false;
            nomeInvalidoLabel.Visible = false;
        }

        /// <summary>
        /// Essa função apaga campos <c>Nome</c> e <c>Destino</c> quando campo Número Documento ter texto alterado.
        /// </summary>
        private void DocumentoComboBox_TextChanged(object sender, EventArgs e)
        {
            documentoLabelBg.Visible = false;
            documentoInvalidoLabel.Visible = false;

            this.ApagarCampos();
        }

        /// <summary>
        /// Essa função foca no campo <c>Tipo de documento</c> ao clicar no <c>label Tipo de documento</c>.
        /// </summary>
        private void TipoDocumentoLabel_Click(object sender, EventArgs e)
        {
            tipoDocumentoComboBox.Focus();
        }

        /// <summary>
        /// Essa função foca no campo <c>Documento</c> ao clicar no <c>label Núm</c>.
        /// </summary>
        private void NumeroDocumentoLabel_Click(object sender, EventArgs e)
        {
            documentoTextBox.Focus();
        }

        /// <summary>
        /// Essa função foca no campo <c>CPF</c> ao clicar no <c>label CPF</c>.
        /// </summary>
        private void CpfLabel_Click(object sender, EventArgs e)
        {
            cpfTextBox.Focus();
        }

        /// <summary>
        /// Essa função habilita edição dos campos <c>Tipo</c> e <c>Documento</c>.
        /// </summary>
        private void OutroDocumentoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            tipoDocumentoComboBox.Enabled = outroDocumentoCheckBox.Checked;
            documentoTextBox.Enabled = outroDocumentoCheckBox.Checked;

            documentoTextBox.TabStop = outroDocumentoCheckBox.Checked;

            tipoDocumentoComboBox.Text = "";
            tipoDocumentoComboBox.TabStop = outroDocumentoCheckBox.Checked;

            documentoTextBox.Clear();

            if (outroDocumentoCheckBox.Checked)
            {
                cpfInvalidoLabel.Visible = false;
            }

            //documentoInvalidoLabel.Visible = false;
            //documentoLabelBg.Visible = false;

            this.ApagarCampos();
        }

        /// <summary>
        /// Essa função desmarca a caixa <c>Outro documento</c> e apaga campos <c>Nome</c> e <c>Destino</c> quando campo Número Documento ter texto alterado.
        /// </summary>
        private void CpfTextBox_TextChanged(object sender, EventArgs e)
        {
            outroDocumentoCheckBox.Checked = false;

            cpfInvalidoLabelBg.Visible = false;
            cpfInvalidoLabel.Visible = false;

            this.ApagarCampos();
        }

        /// <summary>
        /// Essa função efetua a busca de <c>CPF</c> no BD ao usuário tirar foco do campo de inserção de CPF.
        /// </summary>
        private void CpfTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cpfTextBox.Text.Trim())) buscarDocumentoBtn.PerformClick();
        }

        /// <summary>
        /// Essa função efetua a busca de <c>documento</c> no BD ao usuário tirar foco do campo de inserção de documento.
        /// </summary>
        private void DocumentoTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(documentoTextBox.Text.Trim())) buscarDocumentoBtn.PerformClick();
        }

    }
}