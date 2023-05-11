namespace Movies.WinForms;

partial class FormMovies {
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
        this.comboBoxDirectors = new ComboBox();
        this.textBoxTitle = new TextBox();
        this.labelMovieTitle = new Label();
        this.labelPublishDate = new Label();
        this.dateTimePickerPublishDate = new DateTimePicker();
        this.labelDuration = new Label();
        this.textBoxDuration = new TextBox();
        this.labelDirector = new Label();
        this.listBoxPlayers = new ListBox();
        this.groupBoxPlayers = new GroupBox();
        this.buttonAdd = new Button();
        this.groupBoxPlayers.SuspendLayout();
        this.SuspendLayout();
        // 
        // comboBoxDirectors
        // 
        this.comboBoxDirectors.FormattingEnabled = true;
        this.comboBoxDirectors.Location = new Point(439, 271);
        this.comboBoxDirectors.Name = "comboBoxDirectors";
        this.comboBoxDirectors.Size = new Size(308, 23);
        this.comboBoxDirectors.TabIndex = 0;
        // 
        // textBoxTitle
        // 
        this.textBoxTitle.Location = new Point(439, 81);
        this.textBoxTitle.Name = "textBoxTitle";
        this.textBoxTitle.Size = new Size(235, 23);
        this.textBoxTitle.TabIndex = 1;
        // 
        // labelMovieTitle
        // 
        this.labelMovieTitle.AutoSize = true;
        this.labelMovieTitle.Location = new Point(439, 63);
        this.labelMovieTitle.Name = "labelMovieTitle";
        this.labelMovieTitle.Size = new Size(51, 15);
        this.labelMovieTitle.TabIndex = 2;
        this.labelMovieTitle.Text = "Film Adı";
        // 
        // labelPublishDate
        // 
        this.labelPublishDate.AutoSize = true;
        this.labelPublishDate.Location = new Point(439, 116);
        this.labelPublishDate.Name = "labelPublishDate";
        this.labelPublishDate.Size = new Size(66, 15);
        this.labelPublishDate.TabIndex = 4;
        this.labelPublishDate.Text = "Yayın Tarihi";
        // 
        // dateTimePickerPublishDate
        // 
        this.dateTimePickerPublishDate.Format = DateTimePickerFormat.Short;
        this.dateTimePickerPublishDate.Location = new Point(439, 134);
        this.dateTimePickerPublishDate.Name = "dateTimePickerPublishDate";
        this.dateTimePickerPublishDate.Size = new Size(200, 23);
        this.dateTimePickerPublishDate.TabIndex = 5;
        // 
        // labelDuration
        // 
        this.labelDuration.AutoSize = true;
        this.labelDuration.Location = new Point(439, 175);
        this.labelDuration.Name = "labelDuration";
        this.labelDuration.Size = new Size(64, 15);
        this.labelDuration.TabIndex = 7;
        this.labelDuration.Text = "Film Süresi";
        // 
        // textBoxDuration
        // 
        this.textBoxDuration.Location = new Point(439, 193);
        this.textBoxDuration.Name = "textBoxDuration";
        this.textBoxDuration.Size = new Size(235, 23);
        this.textBoxDuration.TabIndex = 6;
        // 
        // labelDirector
        // 
        this.labelDirector.AutoSize = true;
        this.labelDirector.Location = new Point(442, 247);
        this.labelDirector.Name = "labelDirector";
        this.labelDirector.Size = new Size(61, 15);
        this.labelDirector.TabIndex = 8;
        this.labelDirector.Text = "Yönetmen";
        // 
        // listBoxPlayers
        // 
        this.listBoxPlayers.FormattingEnabled = true;
        this.listBoxPlayers.ItemHeight = 15;
        this.listBoxPlayers.Location = new Point(6, 22);
        this.listBoxPlayers.Name = "listBoxPlayers";
        this.listBoxPlayers.Size = new Size(360, 379);
        this.listBoxPlayers.TabIndex = 9;
        // 
        // groupBoxPlayers
        // 
        this.groupBoxPlayers.Controls.Add(this.listBoxPlayers);
        this.groupBoxPlayers.Location = new Point(12, 12);
        this.groupBoxPlayers.Name = "groupBoxPlayers";
        this.groupBoxPlayers.Size = new Size(384, 409);
        this.groupBoxPlayers.TabIndex = 10;
        this.groupBoxPlayers.TabStop = false;
        this.groupBoxPlayers.Text = "Oyuncular";
        // 
        // buttonAdd
        // 
        this.buttonAdd.Location = new Point(466, 353);
        this.buttonAdd.Name = "buttonAdd";
        this.buttonAdd.Size = new Size(208, 33);
        this.buttonAdd.TabIndex = 11;
        this.buttonAdd.Text = "Filmi Ekle";
        this.buttonAdd.UseVisualStyleBackColor = true;
        this.buttonAdd.Click += this.buttonAdd_Click;
        // 
        // FormMovies
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.buttonAdd);
        this.Controls.Add(this.groupBoxPlayers);
        this.Controls.Add(this.labelDirector);
        this.Controls.Add(this.labelDuration);
        this.Controls.Add(this.textBoxDuration);
        this.Controls.Add(this.dateTimePickerPublishDate);
        this.Controls.Add(this.labelPublishDate);
        this.Controls.Add(this.labelMovieTitle);
        this.Controls.Add(this.textBoxTitle);
        this.Controls.Add(this.comboBoxDirectors);
        this.Name = "FormMovies";
        this.Text = "FormMovies";
        this.Load += this.FormMovies_Load;
        this.groupBoxPlayers.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private ComboBox comboBoxDirectors;
    private TextBox textBoxTitle;
    private Label labelMovieTitle;
    private Label labelPublishDate;
    private DateTimePicker dateTimePickerPublishDate;
    private Label labelDuration;
    private TextBox textBoxDuration;
    private Label labelDirector;
    private ListBox listBoxPlayers;
    private GroupBox groupBoxPlayers;
    private Button buttonAdd;
}