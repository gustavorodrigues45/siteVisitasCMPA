using LocalForm.Model;
using LocalFomr.DAO;
using System.Data;
using System.Text;

namespace LocalForm
{
    /// <summary>
    /// Classe que define os eventos a serem acionados na interface de Controle de Local.
    /// </summary>
    public partial class LocalForm : Form
    {
        /// <summary>
        /// Lista de locais mostrados na interface.
        /// </summary>
        private List<Local> _locais;

        /// <summary>
        /// Enum que representa as colunas.
        /// </summary>
        private enum Colunas
        {
            Deletar = 0,
            Id = 1,
            Ativo = 2,
            Nome = 3
        }

        /// <summary>
        /// Cria objeto da Classe <c>LocalForm</c>.
        /// </summary>
        public LocalForm()
        {
            this._locais = new();
            InitializeComponent();
        }

        /// <summary>
        /// Função acionada ao carregar interface
        /// </summary>
        private void LocalForm_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn btnDeletar = new()
            {
                HeaderText = "",
                Name = "Deletar",
                Text = "x",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            btnDeletar.DefaultCellStyle.ForeColor = Color.White;
            btnDeletar.DefaultCellStyle.BackColor = Color.IndianRed;

            localDataGridView.Columns.Insert((int)Colunas.Deletar, btnDeletar);

            localDataGridView.Columns[(int)Colunas.Deletar].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            this.AtualizarTabela();
        }

        /// <summary>
        /// Função que atualiza dados da tabela contida na interface.
        /// </summary>
        private void AtualizarTabela()
        {
            try
            {
                this._locais = LocalDAO.BuscarTodos().OrderBy(local => local.Nome).ToList();

                localDataGridView.DataSource = this._locais;

                localDataGridView.Columns[(int)Colunas.Id].ReadOnly = true;

                localDataGridView.Columns[(int)Colunas.Id].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                localDataGridView.Columns[(int)Colunas.Ativo].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                localDataGridView.Columns[(int)Colunas.Nome].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                localDataGridView.Columns[(int)Colunas.Nome].DefaultCellStyle.DataSourceNullValue = "";

                localDataGridView.Columns[(int)Colunas.Ativo].SortMode = DataGridViewColumnSortMode.Programmatic;

                localDataGridView.Columns[(int)Colunas.Nome].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Função que insere um novo local no Banco de dados ao clicar no <c>cadastrarButton</c>.
        /// </summary>
        private void CadastrarButton_Click(object sender, EventArgs e)
        {
            Local local = new()
            {
                Nome = nomeTextBox.Text
            };

            if (string.IsNullOrEmpty(local.Nome))
            {
                nomeInvalidoLabel.Visible = true;
                return;
            }

            try
            {
                if (LocalDAO.BuscarLocalPorNome(local.Nome).Id != -1)
                {
                    nomeInvalidoLabel.Visible = true;
                    MessageBox.Show("Nome já existe no Sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                LocalDAO.Inserir(local);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            nomeTextBox.Clear();

            this.AtualizarTabela();
        }

        /// <summary>
        /// Função que atualiza <c>local</c> no Banco de dados.
        /// </summary>
        private void LocalDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Local local = new()
            {
                Id = Convert.ToInt32(localDataGridView[(int)LocalForm.Colunas.Id, e.RowIndex].Value),
                Nome = localDataGridView[(int)Colunas.Nome, e.RowIndex].Value.ToString(),
                Ativo = Convert.ToBoolean(localDataGridView[(int)LocalForm.Colunas.Ativo, e.RowIndex].Value)
            };

            if (string.IsNullOrEmpty(local.Nome.Trim()))
            {
                //MessageBox.Show("Nome não pode estar em branco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.AtualizarTabela();

                return;
            }

            try
            {
                Local localBd = LocalDAO.BuscarLocalPorNome(local.Nome);

                if (e.ColumnIndex.Equals((int)Colunas.Nome) &&
                    local.Id != localBd.Id &&
                    localBd.Id != -1)
                {
                    MessageBox.Show("Nome já existe no Sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.AtualizarTabela();
                    return;
                }

                LocalDAO.Atualizar(local);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //this.AtualizarTabela();
        }

        /// <summary>
        /// Faz com que ao clicar na tecla <c>Enter</c> quando estiver com foco no <c>nomeTextBox</c>. 
        /// </summary>
        private void NomeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cadastrarButton.PerformClick();
        }

        /// <summary>
        /// Ordena com base em qual títula da tabela clicado.
        /// </summary>
        private void LocalDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SortOrder sortOrder = localDataGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;
            List<Local> ds;

            if (e.ColumnIndex.Equals((int)Colunas.Deletar)) return;

            sortOrder = (sortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

            ds = (List<Local>)localDataGridView.DataSource;

            if (e.ColumnIndex.Equals((int)Colunas.Ativo))
            {
                ds = (sortOrder == SortOrder.Ascending) ?
                    ds.OrderBy(local => local.Ativo).ToList() :
                    ds.OrderByDescending(local => local.Ativo).ToList();
            }
            else if (e.ColumnIndex.Equals((int)Colunas.Id))
            {
                ds = (sortOrder == SortOrder.Ascending) ?
                    ds.OrderBy(local => local.Id).ToList() :
                    ds.OrderByDescending(local => local.Id).ToList();
            }
            else if (e.ColumnIndex.Equals((int)Colunas.Nome))
            {
                ds = (sortOrder == SortOrder.Ascending) ?
                    ds.OrderBy(local => local.Nome).ToList() :
                    ds.OrderByDescending(local => local.Nome).ToList();
            }

            localDataGridView.DataSource = ds;

            localDataGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortOrder;
        }

        /// <summary>
        /// Filtra a tabela com base no que estiver escrito no <c>nomeTextBox</c>.
        /// </summary>
        private void NomeTextBox_TextChanged(object sender, EventArgs e)
        {
            string novoTexto = nomeTextBox.Text.ToLower().TrimEnd().TrimStart();

            nomeInvalidoLabel.Visible = false;

            localDataGridView.DataSource = this._locais.Where(local => local.Nome.ToLower().Contains(novoTexto)).ToList();
            localDataGridView.Columns[(int)Colunas.Nome].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
        }

        /// <summary>
        /// Faz com que, ao clicar no label <c>Nome</c>, o foco fique no <c>nomeTextBox</c>. 
        /// </summary>
        private void NomeLabel_Click(object sender, EventArgs e)
        {
            nomeTextBox.Focus();
        }

        /// <summary>
        /// Ou deleta ou desativa local contido na tabela da interface e no Banco de dados ao clicar com o botão direito do mouse em cima.
        /// </summary>
        private void LocalDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right)) this.DeletarLocal();
        }

        /// <summary>
        /// Ou deleta ou desativa local contido na tabela da interface e no Banco de dados.
        /// </summary>
        private void DeletarLocal()
        {
            StringBuilder msg = new();
            List<Local> delLista = new();
            string nomes;

            foreach (DataGridViewRow i in localDataGridView.SelectedRows)
            {
                delLista.Add(new() { Nome = i.Cells["Nome"].Value.ToString() });
            }

            nomes = string.Join(", ", delLista.Select(local => local.Nome).OrderBy(nome => nome));

            DialogResult dr = MessageBox.Show($"Continuar com a exclusão dos seguintes Locais?\n\n{nomes}",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No) return;

            foreach (DataGridViewRow i in localDataGridView.SelectedRows)
            {
                try
                {
                    LocalDAO.Delete(Convert.ToInt32(localDataGridView[(int)Colunas.Id, i.Index].Value));
                }
                catch (Exception)
                {
                    msg.Append("- " + localDataGridView[(int)Colunas.Nome, i.Index].Value.ToString() + " ");
                    localDataGridView[(int)Colunas.Ativo, i.Index].Value = false;
                }
            }

            if (msg.Length > 0)
            {
                MessageBox.Show($"Os seguintes locais foram aplicados como destino de uma ou mais visitas.\n" +
                    $"Por esse motivo eles somente foram desativados:\n\n{msg}",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.AtualizarTabela();
        }

        /// <summary>
        /// Ou deleta ou desativa local contido na tabela da interface e no Banco de dados ao clicar em <c>X</c> em uma linha da tabela.
        /// </summary>
        private void LocalDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != (int)Colunas.Deletar) return;

            DataGridViewRow dgr = localDataGridView.Rows[e.RowIndex];

            DialogResult rs = MessageBox.Show($"Continuar com a exclusão de local - {dgr.Cells["Nome"].Value}?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs.Equals(DialogResult.No)) return;

            localDataGridView[(int)Colunas.Ativo, e.RowIndex].Value = false;

            try
            {
                LocalDAO.Delete(Convert.ToInt32(dgr.Cells["Id"].Value));
            }
            catch (Exception)
            {
                MessageBox.Show($"Não foi possível excluir {dgr.Cells["Nome"].Value}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.AtualizarTabela();
        }

        /// <summary>
        /// Função atualiza tabela de locais ao clicar no botão <c>atulizaBtn</c>.
        /// </summary>
        private void AtualizarButton_Click(object sender, EventArgs e)
        {
            this.AtualizarTabela();
        }
    }
}