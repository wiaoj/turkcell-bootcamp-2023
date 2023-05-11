namespace Movies.WinForms;

partial class Form1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.panel1 = new Panel();
        this.dataGridViewMovies = new DataGridView();
        this.panel2 = new Panel();
        this.buttonGetAllMovies = new Button();
        this.buttonAddMovie = new Button();
        this.button2 = new Button();
        this.buttonDirector = new Button();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.dataGridViewMovies).BeginInit();
        this.panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel1
        // 
        this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.panel1.Controls.Add(this.dataGridViewMovies);
        this.panel1.Location = new Point(1, -2);
        this.panel1.Name = "panel1";
        this.panel1.Size = new Size(798, 198);
        this.panel1.TabIndex = 2;
        // 
        // dataGridViewMovies
        // 
        this.dataGridViewMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridViewMovies.Dock = DockStyle.Fill;
        this.dataGridViewMovies.Location = new Point(0, 0);
        this.dataGridViewMovies.Name = "dataGridViewMovies";
        this.dataGridViewMovies.RowTemplate.Height = 25;
        this.dataGridViewMovies.Size = new Size(798, 198);
        this.dataGridViewMovies.TabIndex = 3;
        // 
        // panel2
        // 
        this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.panel2.Controls.Add(this.buttonGetAllMovies);
        this.panel2.Controls.Add(this.buttonAddMovie);
        this.panel2.Controls.Add(this.button2);
        this.panel2.Controls.Add(this.buttonDirector);
        this.panel2.Location = new Point(1, 227);
        this.panel2.Name = "panel2";
        this.panel2.Size = new Size(798, 222);
        this.panel2.TabIndex = 3;
        // 
        // buttonGetAllMovies
        // 
        this.buttonGetAllMovies.Location = new Point(42, 16);
        this.buttonGetAllMovies.Name = "buttonGetAllMovies";
        this.buttonGetAllMovies.Size = new Size(79, 26);
        this.buttonGetAllMovies.TabIndex = 3;
        this.buttonGetAllMovies.Text = "Yenile";
        this.buttonGetAllMovies.UseVisualStyleBackColor = true;
        this.buttonGetAllMovies.Click += this.buttonGetAllMovies_Click;
        // 
        // buttonAddMovie
        // 
        this.buttonAddMovie.Location = new Point(42, 159);
        this.buttonAddMovie.Name = "buttonAddMovie";
        this.buttonAddMovie.Size = new Size(167, 31);
        this.buttonAddMovie.TabIndex = 2;
        this.buttonAddMovie.Text = "Yeni Film Ekle";
        this.buttonAddMovie.UseVisualStyleBackColor = true;
        this.buttonAddMovie.Click += this.buttonAddMovie_Click;
        // 
        // button2
        // 
        this.button2.Location = new Point(42, 106);
        this.button2.Name = "button2";
        this.button2.Size = new Size(167, 30);
        this.button2.TabIndex = 1;
        this.button2.Text = "Oyuncu İşlemleri";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += this.buttonPlayer_Click;
        // 
        // buttonDirector
        // 
        this.buttonDirector.Location = new Point(42, 60);
        this.buttonDirector.Name = "buttonDirector";
        this.buttonDirector.Size = new Size(167, 30);
        this.buttonDirector.TabIndex = 0;
        this.buttonDirector.Text = "Yönetmen İşlemleri";
        this.buttonDirector.UseVisualStyleBackColor = true;
        this.buttonDirector.Click += this.buttonDirector_Click;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.panel2);
        this.Controls.Add(this.panel1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.Load += this.Form1_Load;
        this.panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.dataGridViewMovies).EndInit();
        this.panel2.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion
    private Panel panel1;
    private DataGridView dataGridViewMovies;
    private Panel panel2;
    private Button button2;
    private Button buttonDirector;
    private Button buttonGetAllMovies;
    private Button buttonAddMovie;
}
