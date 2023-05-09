namespace Movies.WinForms;

partial class FormDirectors {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if(disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.splitContainer1 = new SplitContainer();
        this.buttonUpdateDirector = new Button();
        this.buttonAddDirector = new Button();
        this.label3 = new Label();
        this.label2 = new Label();
        this.label1 = new Label();
        this.textBoxDirectorInfo = new TextBox();
        this.textBoxDirectorLastName = new TextBox();
        this.textBoxDirectorName = new TextBox();
        this.dataGridView1 = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
        this.splitContainer1.Panel1.SuspendLayout();
        this.splitContainer1.Panel2.SuspendLayout();
        this.splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
        this.SuspendLayout();
        // 
        // splitContainer1
        // 
        this.splitContainer1.Dock = DockStyle.Fill;
        this.splitContainer1.Location = new Point(0, 0);
        this.splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        this.splitContainer1.Panel1.Controls.Add(this.buttonUpdateDirector);
        this.splitContainer1.Panel1.Controls.Add(this.buttonAddDirector);
        this.splitContainer1.Panel1.Controls.Add(this.label3);
        this.splitContainer1.Panel1.Controls.Add(this.label2);
        this.splitContainer1.Panel1.Controls.Add(this.label1);
        this.splitContainer1.Panel1.Controls.Add(this.textBoxDirectorInfo);
        this.splitContainer1.Panel1.Controls.Add(this.textBoxDirectorLastName);
        this.splitContainer1.Panel1.Controls.Add(this.textBoxDirectorName);
        // 
        // splitContainer1.Panel2
        // 
        this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
        this.splitContainer1.Size = new Size(800, 450);
        this.splitContainer1.SplitterDistance = 266;
        this.splitContainer1.TabIndex = 0;
        // 
        // buttonUpdateDirector
        // 
        this.buttonUpdateDirector.Location = new Point(53, 311);
        this.buttonUpdateDirector.Name = "buttonUpdateDirector";
        this.buttonUpdateDirector.Size = new Size(143, 35);
        this.buttonUpdateDirector.TabIndex = 16;
        this.buttonUpdateDirector.Text = "Yönetmeni Güncelle";
        this.buttonUpdateDirector.UseVisualStyleBackColor = true;
        this.buttonUpdateDirector.Click += this.buttonUpdateDirector_Click;
        // 
        // buttonAddDirector
        // 
        this.buttonAddDirector.Location = new Point(68, 270);
        this.buttonAddDirector.Name = "buttonAddDirector";
        this.buttonAddDirector.Size = new Size(113, 35);
        this.buttonAddDirector.TabIndex = 15;
        this.buttonAddDirector.Text = "Yönetmen Ekle";
        this.buttonAddDirector.UseVisualStyleBackColor = true;
        this.buttonAddDirector.Click += this.buttonAddDirector_Click;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new Point(103, 180);
        this.label3.Name = "label3";
        this.label3.Size = new Size(28, 15);
        this.label3.TabIndex = 14;
        this.label3.Text = "Info";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new Point(103, 123);
        this.label2.Name = "label2";
        this.label2.Size = new Size(39, 15);
        this.label2.TabIndex = 13;
        this.label2.Text = "Soyad";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new Point(103, 62);
        this.label1.Name = "label1";
        this.label1.Size = new Size(22, 15);
        this.label1.TabIndex = 12;
        this.label1.Text = "Ad";
        // 
        // textBoxDirectorInfo
        // 
        this.textBoxDirectorInfo.Location = new Point(46, 198);
        this.textBoxDirectorInfo.Name = "textBoxDirectorInfo";
        this.textBoxDirectorInfo.Size = new Size(150, 23);
        this.textBoxDirectorInfo.TabIndex = 11;
        // 
        // textBoxDirectorLastName
        // 
        this.textBoxDirectorLastName.Location = new Point(46, 141);
        this.textBoxDirectorLastName.Name = "textBoxDirectorLastName";
        this.textBoxDirectorLastName.Size = new Size(150, 23);
        this.textBoxDirectorLastName.TabIndex = 10;
        // 
        // textBoxDirectorName
        // 
        this.textBoxDirectorName.Location = new Point(46, 80);
        this.textBoxDirectorName.Name = "textBoxDirectorName";
        this.textBoxDirectorName.Size = new Size(150, 23);
        this.textBoxDirectorName.TabIndex = 9;
        // 
        // dataGridView1
        // 
        this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Dock = DockStyle.Fill;
        this.dataGridView1.Location = new Point(0, 0);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.Size = new Size(530, 450);
        this.dataGridView1.TabIndex = 0;
        this.dataGridView1.CellContentDoubleClick += this.dataGridView1_CellContentDoubleClick;
        // 
        // FormDirectors
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.splitContainer1);
        this.Name = "FormDirectors";
        this.Text = "FormDirectors";
        this.Load += this.FormDirectors_Load;
        this.splitContainer1.Panel1.ResumeLayout(false);
        this.splitContainer1.Panel1.PerformLayout();
        this.splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
        this.splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private Button buttonAddDirector;
    private Label label3;
    private Label label2;
    private Label label1;
    private TextBox textBoxDirectorInfo;
    private TextBox textBoxDirectorLastName;
    private TextBox textBoxDirectorName;
    private DataGridView dataGridView1;
    private Button buttonUpdateDirector;
}