namespace PortariaForm
{
    partial class CadastroVisitanteForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroVisitanteForm));
            this.buscarDocumentoBtn = new System.Windows.Forms.Button();
            this.documentoLabel = new System.Windows.Forms.Label();
            this.tipoDocumentoComboBox = new System.Windows.Forms.ComboBox();
            this.documentoInvalidoLabel = new System.Windows.Forms.Label();
            this.documentoTextBox = new System.Windows.Forms.TextBox();
            this.documentoLabelBg = new System.Windows.Forms.Label();
            this.timerForm = new System.Windows.Forms.Timer(this.components);
            this.nomeLabelBg = new System.Windows.Forms.Label();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.nomeLabel = new System.Windows.Forms.Label();
            this.cadastrarVisitaBtn = new System.Windows.Forms.Button();
            this.nomeInvalidoLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cpfLabel = new System.Windows.Forms.Label();
            this.cpfTextBox = new System.Windows.Forms.TextBox();
            this.outroDocumentoCheckBox = new System.Windows.Forms.CheckBox();
            this.tipoDocumentoLabel = new System.Windows.Forms.Label();
            this.numeroDocumentoLabel = new System.Windows.Forms.Label();
            this.destinoLabel = new System.Windows.Forms.Label();
            this.dataVisitaLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cpfInvalidoLabel = new System.Windows.Forms.Label();
            this.cpfInvalidoLabelBg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.destinoInvalidoLabel = new System.Windows.Forms.Label();
            this.dataVisitaDateTimePick = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataCheckBox = new System.Windows.Forms.CheckBox();
            this.destinoComboBox = new System.Windows.Forms.ComboBox();
            this.destinoLabelBg = new System.Windows.Forms.Label();
            this.portariaLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buscarDocumentoBtn
            // 
            resources.ApplyResources(this.buscarDocumentoBtn, "buscarDocumentoBtn");
            this.buscarDocumentoBtn.Name = "buscarDocumentoBtn";
            this.toolTip.SetToolTip(this.buscarDocumentoBtn, resources.GetString("buscarDocumentoBtn.ToolTip"));
            this.buscarDocumentoBtn.UseVisualStyleBackColor = true;
            this.buscarDocumentoBtn.Click += new System.EventHandler(this.BuscarDocumentoBtn_Click);
            // 
            // documentoLabel
            // 
            resources.ApplyResources(this.documentoLabel, "documentoLabel");
            this.documentoLabel.Name = "documentoLabel";
            this.toolTip.SetToolTip(this.documentoLabel, resources.GetString("documentoLabel.ToolTip"));
            this.documentoLabel.Click += new System.EventHandler(this.DocumentoLabel_Click);
            // 
            // tipoDocumentoComboBox
            // 
            this.tipoDocumentoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tipoDocumentoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.tipoDocumentoComboBox, "tipoDocumentoComboBox");
            this.tipoDocumentoComboBox.FormattingEnabled = true;
            this.tipoDocumentoComboBox.Items.AddRange(new object[] {
            resources.GetString("tipoDocumentoComboBox.Items"),
            resources.GetString("tipoDocumentoComboBox.Items1")});
            this.tipoDocumentoComboBox.Name = "tipoDocumentoComboBox";
            this.tipoDocumentoComboBox.Sorted = true;
            this.tipoDocumentoComboBox.TabStop = false;
            this.toolTip.SetToolTip(this.tipoDocumentoComboBox, resources.GetString("tipoDocumentoComboBox.ToolTip"));
            this.tipoDocumentoComboBox.TextChanged += new System.EventHandler(this.DocumentoComboBox_TextChanged);
            this.tipoDocumentoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DocumentoComboBox_KeyPress);
            // 
            // documentoInvalidoLabel
            // 
            resources.ApplyResources(this.documentoInvalidoLabel, "documentoInvalidoLabel");
            this.documentoInvalidoLabel.ForeColor = System.Drawing.Color.Red;
            this.documentoInvalidoLabel.Name = "documentoInvalidoLabel";
            // 
            // documentoTextBox
            // 
            resources.ApplyResources(this.documentoTextBox, "documentoTextBox");
            this.documentoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.documentoTextBox.Name = "documentoTextBox";
            this.documentoTextBox.ShortcutsEnabled = false;
            this.documentoTextBox.TabStop = false;
            this.toolTip.SetToolTip(this.documentoTextBox, resources.GetString("documentoTextBox.ToolTip"));
            this.documentoTextBox.TextChanged += new System.EventHandler(this.DocumentoTextBox_TextChanged);
            this.documentoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DocumentoTextBox_KeyPress);
            this.documentoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DocumentoTextBox_KeyUp);
            this.documentoTextBox.Leave += new System.EventHandler(this.DocumentoTextBox_Leave);
            // 
            // documentoLabelBg
            // 
            resources.ApplyResources(this.documentoLabelBg, "documentoLabelBg");
            this.documentoLabelBg.BackColor = System.Drawing.Color.Red;
            this.documentoLabelBg.Name = "documentoLabelBg";
            // 
            // timerForm
            // 
            this.timerForm.Enabled = true;
            this.timerForm.Interval = 1000;
            this.timerForm.Tick += new System.EventHandler(this.TimerForm_Tick);
            // 
            // nomeLabelBg
            // 
            resources.ApplyResources(this.nomeLabelBg, "nomeLabelBg");
            this.nomeLabelBg.BackColor = System.Drawing.Color.Red;
            this.nomeLabelBg.Name = "nomeLabelBg";
            // 
            // nomeTextBox
            // 
            resources.ApplyResources(this.nomeTextBox, "nomeTextBox");
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.TextChanged += new System.EventHandler(this.NomeTextBox_TextChanged);
            this.nomeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NomeTextBox_KeyPress);
            this.nomeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NomeTextBox_KeyUp);
            // 
            // nomeLabel
            // 
            resources.ApplyResources(this.nomeLabel, "nomeLabel");
            this.nomeLabel.Name = "nomeLabel";
            this.toolTip.SetToolTip(this.nomeLabel, resources.GetString("nomeLabel.ToolTip"));
            this.nomeLabel.Click += new System.EventHandler(this.NomeLabel_Click);
            // 
            // cadastrarVisitaBtn
            // 
            resources.ApplyResources(this.cadastrarVisitaBtn, "cadastrarVisitaBtn");
            this.cadastrarVisitaBtn.Name = "cadastrarVisitaBtn";
            this.toolTip.SetToolTip(this.cadastrarVisitaBtn, resources.GetString("cadastrarVisitaBtn.ToolTip"));
            this.cadastrarVisitaBtn.UseVisualStyleBackColor = true;
            this.cadastrarVisitaBtn.Click += new System.EventHandler(this.CadastrarVisitaBtn_Click);
            // 
            // nomeInvalidoLabel
            // 
            resources.ApplyResources(this.nomeInvalidoLabel, "nomeInvalidoLabel");
            this.nomeInvalidoLabel.ForeColor = System.Drawing.Color.Red;
            this.nomeInvalidoLabel.Name = "nomeInvalidoLabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // cpfLabel
            // 
            resources.ApplyResources(this.cpfLabel, "cpfLabel");
            this.cpfLabel.BackColor = System.Drawing.SystemColors.Window;
            this.cpfLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpfLabel.Name = "cpfLabel";
            this.toolTip.SetToolTip(this.cpfLabel, resources.GetString("cpfLabel.ToolTip"));
            this.cpfLabel.Click += new System.EventHandler(this.CpfLabel_Click);
            // 
            // cpfTextBox
            // 
            resources.ApplyResources(this.cpfTextBox, "cpfTextBox");
            this.cpfTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpfTextBox.Name = "cpfTextBox";
            this.cpfTextBox.ShortcutsEnabled = false;
            this.toolTip.SetToolTip(this.cpfTextBox, resources.GetString("cpfTextBox.ToolTip"));
            this.cpfTextBox.TextChanged += new System.EventHandler(this.CpfTextBox_TextChanged);
            this.cpfTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CpfTextBox_KeyPress);
            this.cpfTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DocumentoTextBox_KeyUp);
            this.cpfTextBox.Leave += new System.EventHandler(this.CpfTextBox_Leave);
            // 
            // outroDocumentoCheckBox
            // 
            resources.ApplyResources(this.outroDocumentoCheckBox, "outroDocumentoCheckBox");
            this.outroDocumentoCheckBox.Name = "outroDocumentoCheckBox";
            this.toolTip.SetToolTip(this.outroDocumentoCheckBox, resources.GetString("outroDocumentoCheckBox.ToolTip"));
            this.outroDocumentoCheckBox.UseVisualStyleBackColor = true;
            this.outroDocumentoCheckBox.CheckedChanged += new System.EventHandler(this.OutroDocumentoCheckBox_CheckedChanged);
            // 
            // tipoDocumentoLabel
            // 
            resources.ApplyResources(this.tipoDocumentoLabel, "tipoDocumentoLabel");
            this.tipoDocumentoLabel.BackColor = System.Drawing.SystemColors.Window;
            this.tipoDocumentoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            this.toolTip.SetToolTip(this.tipoDocumentoLabel, resources.GetString("tipoDocumentoLabel.ToolTip"));
            this.tipoDocumentoLabel.Click += new System.EventHandler(this.TipoDocumentoLabel_Click);
            // 
            // numeroDocumentoLabel
            // 
            resources.ApplyResources(this.numeroDocumentoLabel, "numeroDocumentoLabel");
            this.numeroDocumentoLabel.BackColor = System.Drawing.SystemColors.Window;
            this.numeroDocumentoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numeroDocumentoLabel.Name = "numeroDocumentoLabel";
            this.toolTip.SetToolTip(this.numeroDocumentoLabel, resources.GetString("numeroDocumentoLabel.ToolTip"));
            this.numeroDocumentoLabel.Click += new System.EventHandler(this.NumeroDocumentoLabel_Click);
            // 
            // destinoLabel
            // 
            resources.ApplyResources(this.destinoLabel, "destinoLabel");
            this.destinoLabel.Name = "destinoLabel";
            this.toolTip.SetToolTip(this.destinoLabel, resources.GetString("destinoLabel.ToolTip"));
            this.destinoLabel.Click += new System.EventHandler(this.DestinoLabel_Click);
            // 
            // dataVisitaLabel
            // 
            resources.ApplyResources(this.dataVisitaLabel, "dataVisitaLabel");
            this.dataVisitaLabel.Name = "dataVisitaLabel";
            this.toolTip.SetToolTip(this.dataVisitaLabel, resources.GetString("dataVisitaLabel.ToolTip"));
            this.dataVisitaLabel.Click += new System.EventHandler(this.DataVisitaLabel_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cpfInvalidoLabel);
            this.panel1.Controls.Add(this.documentoInvalidoLabel);
            this.panel1.Controls.Add(this.numeroDocumentoLabel);
            this.panel1.Controls.Add(this.tipoDocumentoLabel);
            this.panel1.Controls.Add(this.outroDocumentoCheckBox);
            this.panel1.Controls.Add(this.cpfLabel);
            this.panel1.Controls.Add(this.tipoDocumentoComboBox);
            this.panel1.Controls.Add(this.documentoLabel);
            this.panel1.Controls.Add(this.buscarDocumentoBtn);
            this.panel1.Controls.Add(this.documentoTextBox);
            this.panel1.Controls.Add(this.documentoLabelBg);
            this.panel1.Controls.Add(this.cpfTextBox);
            this.panel1.Controls.Add(this.cpfInvalidoLabelBg);
            this.panel1.Name = "panel1";
            // 
            // cpfInvalidoLabel
            // 
            resources.ApplyResources(this.cpfInvalidoLabel, "cpfInvalidoLabel");
            this.cpfInvalidoLabel.ForeColor = System.Drawing.Color.Red;
            this.cpfInvalidoLabel.Name = "cpfInvalidoLabel";
            // 
            // cpfInvalidoLabelBg
            // 
            resources.ApplyResources(this.cpfInvalidoLabelBg, "cpfInvalidoLabelBg");
            this.cpfInvalidoLabelBg.BackColor = System.Drawing.Color.Red;
            this.cpfInvalidoLabelBg.Name = "cpfInvalidoLabelBg";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.destinoLabel);
            this.panel2.Controls.Add(this.destinoInvalidoLabel);
            this.panel2.Controls.Add(this.dataVisitaDateTimePick);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataCheckBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.nomeInvalidoLabel);
            this.panel2.Controls.Add(this.dataVisitaLabel);
            this.panel2.Controls.Add(this.destinoComboBox);
            this.panel2.Controls.Add(this.destinoLabelBg);
            this.panel2.Controls.Add(this.nomeTextBox);
            this.panel2.Controls.Add(this.nomeLabelBg);
            this.panel2.Controls.Add(this.nomeLabel);
            this.panel2.Name = "panel2";
            // 
            // destinoInvalidoLabel
            // 
            resources.ApplyResources(this.destinoInvalidoLabel, "destinoInvalidoLabel");
            this.destinoInvalidoLabel.ForeColor = System.Drawing.Color.Red;
            this.destinoInvalidoLabel.Name = "destinoInvalidoLabel";
            // 
            // dataVisitaDateTimePick
            // 
            resources.ApplyResources(this.dataVisitaDateTimePick, "dataVisitaDateTimePick");
            this.dataVisitaDateTimePick.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataVisitaDateTimePick.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dataVisitaDateTimePick.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dataVisitaDateTimePick.Name = "dataVisitaDateTimePick";
            this.dataVisitaDateTimePick.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // dataCheckBox
            // 
            resources.ApplyResources(this.dataCheckBox, "dataCheckBox");
            this.dataCheckBox.Name = "dataCheckBox";
            this.dataCheckBox.TabStop = false;
            this.dataCheckBox.UseVisualStyleBackColor = true;
            this.dataCheckBox.CheckedChanged += new System.EventHandler(this.DataCheckBox_CheckedChanged);
            // 
            // destinoComboBox
            // 
            resources.ApplyResources(this.destinoComboBox, "destinoComboBox");
            this.destinoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.destinoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.destinoComboBox.DropDownHeight = 170;
            this.destinoComboBox.FormattingEnabled = true;
            this.destinoComboBox.Name = "destinoComboBox";
            this.destinoComboBox.Sorted = true;
            this.destinoComboBox.TextChanged += new System.EventHandler(this.DestinoComboBox_TextChanged);
            this.destinoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DestinoComboBox_KeyPress);
            this.destinoComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DestinoComboBox_KeyUp);
            // 
            // destinoLabelBg
            // 
            resources.ApplyResources(this.destinoLabelBg, "destinoLabelBg");
            this.destinoLabelBg.BackColor = System.Drawing.Color.Red;
            this.destinoLabelBg.Name = "destinoLabelBg";
            // 
            // portariaLabel
            // 
            resources.ApplyResources(this.portariaLabel, "portariaLabel");
            this.portariaLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.portariaLabel.Name = "portariaLabel";
            // 
            // CadastroVisitanteForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cadastrarVisitaBtn);
            this.Controls.Add(this.portariaLabel);
            this.Controls.Add(this.panel2);
            this.Name = "CadastroVisitanteForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.CadastroVisitanteForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buscarDocumentoBtn;
        private Label documentoLabel;
        private TextBox documentoTextBox;
        private System.Windows.Forms.Timer timerForm;
        private Label documentoLabelBg;
        private Label documentoInvalidoLabel;
        private ComboBox tipoDocumentoComboBox;
        private Label nomeLabelBg;
        private TextBox nomeTextBox;
        private Label nomeLabel;
        private Button cadastrarVisitaBtn;
        private Label nomeInvalidoLabel;
        private Label label2;
        private ToolTip toolTip;
        private Panel panel1;
        private Panel panel2;
        private Label cpfLabel;
        private TextBox cpfTextBox;
        private CheckBox outroDocumentoCheckBox;
        private Label numeroDocumentoLabel;
        private Label tipoDocumentoLabel;
        private Label cpfInvalidoLabel;
        private Label cpfInvalidoLabelBg;
        private Label portariaLabel;
        private Label destinoLabelBg;
        private ComboBox destinoComboBox;
        private Label label1;
        private Label destinoLabel;
        private Label destinoInvalidoLabel;
        private DateTimePicker dataVisitaDateTimePick;
        private CheckBox dataCheckBox;
        private Label dataVisitaLabel;
    }
}