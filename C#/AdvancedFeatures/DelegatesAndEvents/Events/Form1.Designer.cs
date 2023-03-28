namespace Events;

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
        this.textBox1 = new TextBox();
        this.linkLabel1 = new LinkLabel();
        this.SuspendLayout();
        // 
        // textBox1
        // 
        this.textBox1.Location = new Point(274, 53);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new Size(248, 23);
        this.textBox1.TabIndex = 0;
        this.textBox1.KeyDown += this.textBox1_KeyDown;
        // 
        // linkLabel1
        // 
        this.linkLabel1.AutoSize = true;
        this.linkLabel1.Location = new Point(357, 165);
        this.linkLabel1.Name = "linkLabel1";
        this.linkLabel1.Size = new Size(60, 15);
        this.linkLabel1.TabIndex = 1;
        this.linkLabel1.TabStop = true;
        this.linkLabel1.Text = "linkLabel1";
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.linkLabel1);
        this.Controls.Add(this.textBox1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.Load += this.Form1_Load;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private TextBox textBox1;
    private LinkLabel linkLabel1;
}
