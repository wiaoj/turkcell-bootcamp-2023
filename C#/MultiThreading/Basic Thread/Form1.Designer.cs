namespace BasicThread;

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
        this.ButtonCounter = new Button();
        this.labelCounter = new Label();
        this.buttonTest = new Button();
        this.progressBar1 = new ProgressBar();
        this.SuspendLayout();
        // 
        // ButtonCounter
        // 
        this.ButtonCounter.Location = new Point(228, 71);
        this.ButtonCounter.Name = "ButtonCounter";
        this.ButtonCounter.Size = new Size(142, 23);
        this.ButtonCounter.TabIndex = 0;
        this.ButtonCounter.Text = "Sayacı Başlat";
        this.ButtonCounter.UseVisualStyleBackColor = true;
        this.ButtonCounter.Click += this.ButtonCounter_Click;
        // 
        // labelCounter
        // 
        this.labelCounter.AutoSize = true;
        this.labelCounter.Location = new Point(286, 122);
        this.labelCounter.Name = "labelCounter";
        this.labelCounter.Size = new Size(32, 15);
        this.labelCounter.TabIndex = 1;
        this.labelCounter.Text = "-----";
        // 
        // buttonTest
        // 
        this.buttonTest.Location = new Point(389, 71);
        this.buttonTest.Name = "buttonTest";
        this.buttonTest.Size = new Size(75, 23);
        this.buttonTest.TabIndex = 2;
        this.buttonTest.Text = "Göster";
        this.buttonTest.UseVisualStyleBackColor = true;
        this.buttonTest.Click += this.buttonTest_Click;
        // 
        // progressBar1
        // 
        this.progressBar1.Location = new Point(86, 180);
        this.progressBar1.Name = "progressBar1";
        this.progressBar1.Size = new Size(467, 23);
        this.progressBar1.TabIndex = 3;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(618, 352);
        this.Controls.Add(this.progressBar1);
        this.Controls.Add(this.buttonTest);
        this.Controls.Add(this.labelCounter);
        this.Controls.Add(this.ButtonCounter);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Button ButtonCounter;
    private Label labelCounter;
    private Button buttonTest;
    private ProgressBar progressBar1;
}
