namespace SingleResponsibility;

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
        this.textBoxName = new TextBox();
        this.textBoxPrice = new TextBox();
        this.buttonAddProduct = new Button();
        this.SuspendLayout();
        // 
        // textBoxName
        // 
        this.textBoxName.Location = new Point(154, 80);
        this.textBoxName.Name = "textBoxName";
        this.textBoxName.Size = new Size(167, 23);
        this.textBoxName.TabIndex = 0;
        // 
        // textBoxPrice
        // 
        this.textBoxPrice.Location = new Point(154, 129);
        this.textBoxPrice.Name = "textBoxPrice";
        this.textBoxPrice.Size = new Size(167, 23);
        this.textBoxPrice.TabIndex = 1;
        // 
        // buttonAddProduct
        // 
        this.buttonAddProduct.Location = new Point(203, 186);
        this.buttonAddProduct.Name = "buttonAddProduct";
        this.buttonAddProduct.Size = new Size(75, 23);
        this.buttonAddProduct.TabIndex = 2;
        this.buttonAddProduct.Text = "Ürün Ekle";
        this.buttonAddProduct.UseVisualStyleBackColor = true;
        this.buttonAddProduct.Click += this.buttonAddProduct_Click;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(488, 351);
        this.Controls.Add(this.buttonAddProduct);
        this.Controls.Add(this.textBoxPrice);
        this.Controls.Add(this.textBoxName);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private TextBox textBoxName;
    private TextBox textBoxPrice;
    private Button buttonAddProduct;
}
