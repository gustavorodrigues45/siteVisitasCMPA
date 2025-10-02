namespace LocalForm
{
    partial class LocalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalForm));
            this.localDataGridView = new System.Windows.Forms.DataGridView();
            this.nomeLabel = new System.Windows.Forms.Label();
            this.cadastrarButton = new System.Windows.Forms.Button();
            this.nomeInvalidoLabel = new System.Windows.Forms.Label();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.atualizarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.localDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // localDataGridView
            // 
            this.localDataGridView.AllowUserToAddRows = false;
            this.localDataGridView.AllowUserToDeleteRows = false;
            this.localDataGridView.AllowUserToResizeColumns = false;
            this.localDataGridView.AllowUserToResizeRows = false;
            this.localDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.localDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.localDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.localDataGridView.Location = new System.Drawing.Point(0, 43);
            this.localDataGridView.Name = "localDataGridView";
            this.localDataGridView.RowHeadersVisible = false;
            this.localDataGridView.RowTemplate.Height = 25;
            this.localDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.localDataGridView.Size = new System.Drawing.Size(534, 418);
            this.localDataGridView.TabIndex = 2;
            this.localDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LocalDataGridView_CellContentClick);
            this.localDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.LocalDataGridView_CellValueChanged);
            this.localDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LocalDataGridView_ColumnHeaderMouseClick);
            this.localDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LocalDataGridView_MouseUp);
            // 
            // nomeLabel
            // 
            this.nomeLabel.AutoSize = true;
            this.nomeLabel.BackColor = System.Drawing.SystemColors.Menu;
            this.nomeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nomeLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nomeLabel.Location = new System.Drawing.Point(13, 11);
            this.nomeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nomeLabel.MinimumSize = new System.Drawing.Size(69, 27);
            this.nomeLabel.Name = "nomeLabel";
            this.nomeLabel.Size = new System.Drawing.Size(69, 27);
            this.nomeLabel.TabIndex = 7;
            this.nomeLabel.Text = "Nome";
            this.nomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nomeLabel.Click += new System.EventHandler(this.NomeLabel_Click);
            // 
            // cadastrarButton
            // 
            this.cadastrarButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cadastrarButton.Location = new System.Drawing.Point(420, 11);
            this.cadastrarButton.Name = "cadastrarButton";
            this.cadastrarButton.Size = new System.Drawing.Size(70, 27);
            this.cadastrarButton.TabIndex = 1;
            this.cadastrarButton.Text = "Inserir";
            this.cadastrarButton.UseVisualStyleBackColor = true;
            this.cadastrarButton.Click += new System.EventHandler(this.CadastrarButton_Click);
            // 
            // nomeInvalidoLabel
            // 
            this.nomeInvalidoLabel.AutoSize = true;
            this.nomeInvalidoLabel.BackColor = System.Drawing.Color.Red;
            this.nomeInvalidoLabel.Location = new System.Drawing.Point(12, 10);
            this.nomeInvalidoLabel.MinimumSize = new System.Drawing.Size(403, 29);
            this.nomeInvalidoLabel.Name = "nomeInvalidoLabel";
            this.nomeInvalidoLabel.Size = new System.Drawing.Size(403, 29);
            this.nomeInvalidoLabel.TabIndex = 8;
            this.nomeInvalidoLabel.Visible = false;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nomeTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nomeTextBox.Location = new System.Drawing.Point(5, 1);
            this.nomeTextBox.MinimumSize = new System.Drawing.Size(0, 24);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(329, 24);
            this.nomeTextBox.TabIndex = 0;
            this.nomeTextBox.TextChanged += new System.EventHandler(this.NomeTextBox_TextChanged);
            this.nomeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NomeTextBox_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.nomeTextBox);
            this.panel1.Location = new System.Drawing.Point(73, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 27);
            this.panel1.TabIndex = 9;
            // 
            // atualizarBtn
            // 
            this.atualizarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atualizarBtn.Image = global::Controle_de_Local.Properties.Resources.refresh;
            this.atualizarBtn.Location = new System.Drawing.Point(496, 11);
            this.atualizarBtn.Name = "atualizarBtn";
            this.atualizarBtn.Size = new System.Drawing.Size(27, 27);
            this.atualizarBtn.TabIndex = 10;
            this.atualizarBtn.TabStop = false;
            this.atualizarBtn.UseVisualStyleBackColor = true;
            this.atualizarBtn.Click += new System.EventHandler(this.AtualizarButton_Click);
            // 
            // LocalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.atualizarBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cadastrarButton);
            this.Controls.Add(this.localDataGridView);
            this.Controls.Add(this.nomeLabel);
            this.Controls.Add(this.nomeInvalidoLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 500);
            this.Name = "LocalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LocalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.localDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView localDataGridView;
        private Label nomeLabel;
        private Button cadastrarButton;
        private Label nomeInvalidoLabel;
        private TextBox nomeTextBox;
        private Panel panel1;
        private Button atualizarBtn;
    }
}