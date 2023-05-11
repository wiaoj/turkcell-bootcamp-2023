namespace Movies.WinForms;

partial class FormPlayers {
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
        this.buttonAddPlayer = new Button();
        this.label2 = new Label();
        this.label1 = new Label();
        this.textBoxPlayerLastName = new TextBox();
        this.textBoxPlayerName = new TextBox();
        this.splitContainer1 = new SplitContainer();
        this.buttonUpdatePlayer = new Button();
        this.dataGridView1 = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
        this.splitContainer1.Panel1.SuspendLayout();
        this.splitContainer1.Panel2.SuspendLayout();
        this.splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
        this.SuspendLayout();
        // 
        // buttonAddPlayer
        // 
        this.buttonAddPlayer.Location = new Point(68, 270);
        this.buttonAddPlayer.Name = "buttonAddPlayer";
        this.buttonAddPlayer.Size = new Size(113, 35);
        this.buttonAddPlayer.TabIndex = 15;
        this.buttonAddPlayer.Text = "Oyuncu Ekle";
        this.buttonAddPlayer.UseVisualStyleBackColor = true;
        this.buttonAddPlayer.Click += this.buttonAddPlayer_Click;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new Point(110, 141);
        this.label2.Name = "label2";
        this.label2.Size = new Size(39, 15);
        this.label2.TabIndex = 13;
        this.label2.Text = "Soyad";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new Point(110, 80);
        this.label1.Name = "label1";
        this.label1.Size = new Size(22, 15);
        this.label1.TabIndex = 12;
        this.label1.Text = "Ad";
        // 
        // textBoxPlayerLastName
        // 
        this.textBoxPlayerLastName.Location = new Point(53, 159);
        this.textBoxPlayerLastName.Name = "textBoxPlayerLastName";
        this.textBoxPlayerLastName.Size = new Size(150, 23);
        this.textBoxPlayerLastName.TabIndex = 10;
        // 
        // textBoxPlayerName
        // 
        this.textBoxPlayerName.Location = new Point(53, 98);
        this.textBoxPlayerName.Name = "textBoxPlayerName";
        this.textBoxPlayerName.Size = new Size(150, 23);
        this.textBoxPlayerName.TabIndex = 9;
        // 
        // splitContainer1
        // 
        this.splitContainer1.Dock = DockStyle.Fill;
        this.splitContainer1.Location = new Point(0, 0);
        this.splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        this.splitContainer1.Panel1.Controls.Add(this.buttonUpdatePlayer);
        this.splitContainer1.Panel1.Controls.Add(this.buttonAddPlayer);
        this.splitContainer1.Panel1.Controls.Add(this.label2);
        this.splitContainer1.Panel1.Controls.Add(this.label1);
        this.splitContainer1.Panel1.Controls.Add(this.textBoxPlayerLastName);
        this.splitContainer1.Panel1.Controls.Add(this.textBoxPlayerName);
        // 
        // splitContainer1.Panel2
        // 
        this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
        this.splitContainer1.Size = new Size(800, 450);
        this.splitContainer1.SplitterDistance = 266;
        this.splitContainer1.TabIndex = 1;
        // 
        // buttonUpdatePlayer
        // 
        this.buttonUpdatePlayer.Location = new Point(53, 311);
        this.buttonUpdatePlayer.Name = "buttonUpdatePlayer";
        this.buttonUpdatePlayer.Size = new Size(143, 35);
        this.buttonUpdatePlayer.TabIndex = 16;
        this.buttonUpdatePlayer.Text = "Oyuncuyu Güncelle";
        this.buttonUpdatePlayer.UseVisualStyleBackColor = true;
        // 
        // dataGridView1
        // 
        this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Dock = DockStyle.Fill;
        this.dataGridView1.Location = new Point(0, 0);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.Size = new Size(530, 450);
        this.dataGridView1.TabIndex = 0;
        // 
        // FormPlayers
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.splitContainer1);
        this.Name = "FormPlayers";
        this.Text = "FormPlayers";
        this.Load += this.FormPlayers_Load;
        this.splitContainer1.Panel1.ResumeLayout(false);
        this.splitContainer1.Panel1.PerformLayout();
        this.splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
        this.splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private Button buttonAddPlayer;
    private Label label2;
    private Label label1;
    private TextBox textBoxPlayerLastName;
    private TextBox textBoxPlayerName;
    private SplitContainer splitContainer1;
    private Button buttonUpdatePlayer;
    private DataGridView dataGridView1;
}