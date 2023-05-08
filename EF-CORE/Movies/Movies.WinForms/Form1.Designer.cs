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
        this.buttonGetMovies = new Button();
        this.listBoxMovies = new ListBox();
        this.SuspendLayout();
        // 
        // buttonGetMovies
        // 
        this.buttonGetMovies.Location = new Point(298, 177);
        this.buttonGetMovies.Name = "buttonGetMovies";
        this.buttonGetMovies.Size = new Size(217, 48);
        this.buttonGetMovies.TabIndex = 0;
        this.buttonGetMovies.Text = "button1";
        this.buttonGetMovies.UseVisualStyleBackColor = true;
        this.buttonGetMovies.Click += this.buttonGetMovies_Click;
        // 
        // listBoxMovies
        // 
        this.listBoxMovies.FormattingEnabled = true;
        this.listBoxMovies.ItemHeight = 15;
        this.listBoxMovies.Location = new Point(557, 99);
        this.listBoxMovies.Name = "listBoxMovies";
        this.listBoxMovies.Size = new Size(120, 94);
        this.listBoxMovies.TabIndex = 1;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.listBoxMovies);
        this.Controls.Add(this.buttonGetMovies);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);
    }

    #endregion

    private Button buttonGetMovies;
    private ListBox listBoxMovies;
}
